using Delivery.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.User
{
    public class Comentario
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Comida Comida { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public Comentario()
        {
            
        }
    }
}
