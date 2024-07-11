﻿using Delivery.Domain.Food;
using Delivery.Persistence.Data;
using Delivery.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Delivery.Repositories.Implementations
{
    public class ComidaBase : RepositoryBase<Comida>, IComidaRepository
    {
        private readonly DeliveryDBContext _Comidacontext;
        private readonly int ELEMENTOS_PAGINA = 4;
        public ComidaBase(DeliveryDBContext context) : base(context)
        {
            _Comidacontext = context;
        }

        public async Task Registrar_Comida_Log(string comidaLog, int IdPedido)
        {
            await _context.Comida_CaracteristicasPedido.AddAsync(new Comida_CaracteristicaPedido(comidaLog, IdPedido));
            await Guardar();
        }

        public async Task<List<Comida_CaracteristicaPedido>?> Obtener_ComidasPedido(Expression<Func<Comida_CaracteristicaPedido, bool>> filtro)
            => await _context.Comida_CaracteristicasPedido.Where(filtro).ToListAsync();

        public async Task<Comida_CaracteristicaPedido?> Obtener_comidaPedidoId(int idPedido)
            => await _context.Comida_CaracteristicasPedido.Where(x => x.IdPedido == idPedido).FirstOrDefaultAsync();


        #region Paginacion

        public IEnumerable<Comida> Obtener_comidas_paginado(IEnumerable<Comida> comidas, int page)
        {
            int indiceInicio = (page - 1) * ELEMENTOS_PAGINA;
            return comidas.Skip(indiceInicio).Take(ELEMENTOS_PAGINA).ToList();
        }

        public int PaginasTotales(IEnumerable<Comida> comidas)
        {
            int total_paginas = comidas.Count();
            return (int)Math.Ceiling((double)total_paginas / ELEMENTOS_PAGINA);
        }



        #endregion


        #region Caracteristicas Comida

        public async Task AgregarCaracteristica(CaracteristicaComida caracteristica)
		{
			await _context.CaracteristicaComidas.AddAsync(caracteristica);
			await _context.SaveChangesAsync();
		}
		public async Task<bool> CaracteristicaNombreUnico(string nombre)
		{

			CaracteristicaComida comprobar = await _context.CaracteristicaComidas.Where(c =>c.Nombre == nombre.Trim().ToLower()).FirstOrDefaultAsync();
			if (comprobar == null) return true;
			else return false;
		}
		public async Task ActualizarCaracteristica(CaracteristicaComida categoriaComida)
		{
			_Comidacontext.CaracteristicaComidas.Update(categoriaComida);
			await _context.SaveChangesAsync();
		}
		public async Task EliminarCaracteristica(CaracteristicaComida caracteristicaComida)
		{
            int id = caracteristicaComida.Id;

            var listado = await _context.Comida_CaracteristicasMenu.Where(x => x.IdCaracteristicaComida == id).ToListAsync();
            _context.Comida_CaracteristicasMenu.RemoveRange(listado);

            _Comidacontext.CaracteristicaComidas.Remove(caracteristicaComida);
			await _Comidacontext.SaveChangesAsync();
		}
		public async Task<CaracteristicaComida> ObtenerCaracteristicaPorID(int id)
		{
			return await _Comidacontext.CaracteristicaComidas.Where(c => c.Id == id).FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<CaracteristicaComida>> ObtenerCaracteristicasComidas()
		{
			return await _Comidacontext.CaracteristicaComidas.ToListAsync();
		}
        public async Task<IEnumerable<CaracteristicaComida>> ObtenerCaracteristicasPorComidaID(int id)
        {
            List<CaracteristicaComida> listaIndices = new List<CaracteristicaComida>();
            List<Comida_CaracteristicaMenu> listado = await _context.Comida_CaracteristicasMenu.Where(x => x.IdComida == id).ToListAsync();
            listado.ForEach(x =>
            {
                listaIndices.Add(x.CaracteristicaComida);
            });
            return listaIndices;
        }
        public async Task AgregarRelacionCaracteristicaComida(int idComida, int idCaracteristica)
        {
            await _context.Comida_CaracteristicasMenu.AddAsync(new Comida_CaracteristicaMenu(idComida, idCaracteristica));
        }

        #endregion

        #region Comida

        public async Task AgregarComida(Comida comida, string listaIndicescarac)
        {
            await Agregar(comida);
            await Guardar(); //Para que se genere su id o algo asi
            //Agregar la relación de características de comidas con Comidas
            //No se agrega nada si no hay nada en la lista
            List<int> listaIndices = JsonConvert.DeserializeObject<List<int>>(listaIndicescarac);
            foreach (int i in listaIndices)
            {
                await AgregarRelacionCaracteristicaComida(comida.ID, i);
            }
        }
        public async Task EditarComida(Comida comida, string listaIndicescara)
        {
            _context.Comidas.Update(comida);
            var listaIndices = JsonConvert.DeserializeObject<List<int>>(listaIndicescara);
            var listaIndicesBorrar = await _context.Comida_CaracteristicasMenu.Where(x => x.IdComida == comida.ID).ToListAsync();

            _context.Comida_CaracteristicasMenu.RemoveRange(listaIndicesBorrar); //Borrar registros previos
            foreach(var item in listaIndices)
            {
                await AgregarRelacionCaracteristicaComida(comida.ID, item);
            }
        }
        public async Task EditarComida(Comida comida)
        {
            _context.Comidas.Update(comida);
            await Guardar();
        }
        public async Task EliminarComida(Comida comida)
        {
            var listaIndicesBorrar = await _context.Comida_CaracteristicasMenu.Where(x => x.IdComida == comida.ID).ToListAsync();
            _context.Comida_CaracteristicasMenu.RemoveRange(listaIndicesBorrar);

            _context.Comidas.Remove(comida);
            await Guardar();
        }
        public async Task<IEnumerable<Comida>> ObtenerComidas()
        {
            return await _Comidacontext.Comidas.ToListAsync();
        }
        public string CargarImagen(HttpContext httpContext, IWebHostEnvironment _webHostEnvironment)
        {
            //Verificar la imagen enviada
            var files = httpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            string upload = webRootPath + @"\imagenes\Comida\";
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            //Cargar en el servidor
            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
            return fileName + extension;
        }
        public void EliminarImagen(string productURL, IWebHostEnvironment _webHostEnvironment)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string upload = webRootPath + @"\imagenes\Comida\";
            string ruta = upload + productURL;
            Console.WriteLine(ruta);
            System.IO.File.Delete(ruta);
        }

        #endregion
    }
}
