using System;
using System.Collections.Generic;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class Carretera
    {
        public Carretera()
        {
            Confluencia = new HashSet<Confluencia>();
            Tramos = new HashSet<Tramo>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public long? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Confluencia> Confluencia { get; set; }
        public virtual ICollection<Tramo> Tramos { get; set; }
    }
}
