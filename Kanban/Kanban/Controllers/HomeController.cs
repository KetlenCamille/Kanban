using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kanban.DAL;
using Kanban.Models;

namespace Kanban.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            if(StatusDAO.BuscarPorNome("A Fazer") == null)
            {
                Status statusAdd = new Status();
                statusAdd.DescricaoStatus = "A Fazer";
                StatusDAO.Adicionar(statusAdd);
            }
            if (StatusDAO.BuscarPorNome("Em Execução") == null)
            {
                Status statusAdd = new Status();
                statusAdd.DescricaoStatus = "Em Execução";
                StatusDAO.Adicionar(statusAdd);
            }
            if (StatusDAO.BuscarPorNome("Concluído") == null)
            {
                Status statusAdd = new Status();
                statusAdd.DescricaoStatus = "Concluído";
                StatusDAO.Adicionar(statusAdd);
            }
            ViewBag.Status = StatusDAO.ListarTodos();
            if(id == null)
            {
                return View(AtividadeDAO.ListarTodos());
                
            }
            return View(AtividadeDAO.BuscarAtividadePorStatus(id));
        }

        public ActionResult CadastrarAtividade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarAtividade(Atividade atividade)
        {
            if (StatusDAO.BuscarPorNome("A Fazer") != null)
            {
                atividade.Status = StatusDAO.BuscarPorNome("A Fazer");
            }
            AtividadeDAO.Adicionar(atividade);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ExcluirAtividade(int id)
        {
            AtividadeDAO.Remover(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ProximaEtapa(int id)
        {
            Atividade atividadeBusca = AtividadeDAO.BuscarPorID(id);
            if (atividadeBusca.RequisitoAtividade != 0)
            {
                Atividade atividadeDependente = AtividadeDAO.BuscarPorID(atividadeBusca.RequisitoAtividade);
                if (atividadeDependente.Status.DescricaoStatus.Equals("A Fazer") && atividadeBusca.Status.DescricaoStatus.Equals("A Fazer"))
                {
                    ViewBag.Erros = "Sua atividade é dependente. Efetue a atividade " + atividadeBusca.RequisitoAtividade + " primeiro";
                    return RedirectToAction("Index", "Home");
                }
                else if (atividadeDependente.Status.DescricaoStatus.Equals("Em Execução") && atividadeBusca.Status.DescricaoStatus.Equals("Em Execução"))
                {
                    ViewBag.Erros = "Sua atividade é dependente. Efetue a atividade " + atividadeBusca.RequisitoAtividade + " primeiro";
                    return RedirectToAction("Index", "Home");
                }

                if (atividadeBusca.Status.DescricaoStatus.Equals("A Fazer"))
                {
                    atividadeBusca.Status = StatusDAO.BuscarPorNome("Em Execução");
                    AtividadeDAO.Atualizar(atividadeBusca);
                }
                else if (atividadeBusca.Status.DescricaoStatus.Equals("Em Execução"))
                {
                    atividadeBusca.Status = StatusDAO.BuscarPorNome("Concluído");
                    AtividadeDAO.Atualizar(atividadeBusca);
                }
            }
            else
            {
                if (atividadeBusca.Status.DescricaoStatus.Equals("A Fazer"))
                {
                    atividadeBusca.Status = StatusDAO.BuscarPorNome("Em Execução");
                    AtividadeDAO.Atualizar(atividadeBusca);
                }
                else if (atividadeBusca.Status.DescricaoStatus.Equals("Em Execução"))
                {
                    atividadeBusca.Status = StatusDAO.BuscarPorNome("Concluído");
                    AtividadeDAO.Atualizar(atividadeBusca);
                }
            } 
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EtapaAnterior(int id)
        {
            Atividade atividadeBusca = AtividadeDAO.BuscarPorID(id);
            if(atividadeBusca.Status.DescricaoStatus.Equals("Em Execução"))
            {
                atividadeBusca.Status = StatusDAO.BuscarPorNome("A Fazer");
                AtividadeDAO.Atualizar(atividadeBusca);
            }
            else if (atividadeBusca.Status.DescricaoStatus.Equals("Concluído"))
            {
                atividadeBusca.Status = StatusDAO.BuscarPorNome("Em Execução");
                AtividadeDAO.Atualizar(atividadeBusca);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}