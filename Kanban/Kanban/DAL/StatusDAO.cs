using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.Models;

namespace Kanban.DAL
{
    public class StatusDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        public static void Adicionar(Status status)
        {
            if (status != null)
            {
                contexto.Status.Add(status);
                contexto.SaveChanges();
            }
        }

        public static List<Status> ListarTodos()
        {
            return contexto.Status.ToList();
        }

        public static void Atualizar(Status status)
        {
            contexto.Entry(status).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public static void Remover(int id)
        {
            contexto.Status.Remove(BuscarPorID(id));
            contexto.SaveChanges();
        }

        public static Status BuscarPorID(int? id)
        {
            return contexto.Status.Find(id);
        }

        public static Status BuscarPorNome(string status)
        {
            return contexto.Status.FirstOrDefault(x => x.DescricaoStatus.ToLower().Contains(status.ToLower()));
        }
    
    }
}