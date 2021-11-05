using System;
using System.Collections.Generic;

#nullable disable

namespace carreteras.Server.Entidades
{
    public partial class Categoria
    {
        public Categoria()
        {
            Carreteras = new HashSet<Carretera>();
        }

        public long Id { get; set; }
        public string NombreCategoria { get; set; }

        public virtual ICollection<Carretera> Carreteras { get; set; }
    }
}
