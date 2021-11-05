using System;
using System.Collections.Generic;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class Confluencia
    {
        public Confluencia()
        {
            Tramos = new HashSet<Tramo>();
        }

        public long Id { get; set; }
        public long? TramocomunaId { get; set; }
        public long? CarreteraId { get; set; }

        public virtual Carretera Carretera { get; set; }
        public virtual Tramoscomuna Tramocomuna { get; set; }
        public virtual ICollection<Tramo> Tramos { get; set; }
    }
}
