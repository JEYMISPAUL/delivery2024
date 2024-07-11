using Delivery.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.User
{
    public class DetalleComidaViewModel
    {
        public Comida ComidaEncontrada { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
