using System;
using System.Collections.Generic;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class Tramoscomuna
    {
        public Tramoscomuna()
        {
            Confluencia = new HashSet<Confluencia>();
        }

        public long Id { get; set; }
        public long? TramoId { get; set; }
        public long? ComunaId { get; set; }
        public int? Kmubicacion { get; set; }

        public virtual Comuna Comuna { get; set; }
        public virtual Tramo Tramo { get; set; }
        public virtual ICollection<Confluencia> Confluencia { get; set; }
    }
}
