using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carreteras.Server.Entidades.Respuesta
{
    public class Respuesta<T>
    {
        public int Ok { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }

        public Respuesta ()
        {
            this.Ok = 0;
        }
    }
}
