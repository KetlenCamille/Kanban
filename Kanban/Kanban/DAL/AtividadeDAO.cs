using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.Models;

namespace Kanban.DAL
{
    public class AtividadeDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        public void Adicionar(Atividade atividade)
        {
            if (atividade != null)
            {
                contexto.Atividades.Add(atividade);
                contexto.SaveChanges();
            }
        }

        public List<Atividade> ListarTodos()
        {
            return contexto.Atividades.ToList();
        }

        public void Atualizar(Atividade atividade)
        {
            contexto.Entry(atividade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Remover(int id)
        {
            contexto.Atividades.Remove(BuscarPorID(id));
            contexto.SaveChanges();
        }

        public Atividade BuscarPorID(int? id)
        {
            return contexto.Atividades.Find(id);
        }

        public Atividade BuscarPorNome(string atividade)
        {
            return contexto.Atividades.FirstOrDefault(x => x.TituloAtividade.ToLower().Contains(atividade.ToLower()));
        }

        public static List<Atividade> BuscarAtividadePorStatus(int? id)
        {
            return contexto.Atividades.Include("Status").Where(x => x.Status.IDStatus == id).ToList();
        }
    }
}