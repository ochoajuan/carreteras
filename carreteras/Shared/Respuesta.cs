using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carreteras.Shared
{
    public class Respuesta<T>
    {
        public int Ok { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }

    }
}
