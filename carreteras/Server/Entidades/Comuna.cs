using System;
using System.Collections.Generic;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class Comuna
    {
        public Comuna()
        {
            Tramoscomunas = new HashSet<Tramoscomuna>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tramoscomuna> Tramoscomunas { get; set; }
    }
}
