using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DbKanban") { }

        public DbSet<Status> Status { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
    }
}