using System;
using System.Collections.Generic;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class Tramo
    {
        public Tramo()
        {
            Tramoscomunas = new HashSet<Tramoscomuna>();
        }

        public long Id { get; set; }
        public long? CarreteraId { get; set; }
        public short? PrincipioCarretera { get; set; }
        public short? FinalCarretera { get; set; }
        public long? ConfluyeId { get; set; }

        public virtual Carretera Carretera { get; set; }
        public virtual Confluencia Confluye { get; set; }
        public virtual ICollection<Tramoscomuna> Tramoscomunas { get; set; }
    }
}
