using SistemaWeb.Models;
using SistemaWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        public ActionResult CadastrarProdutos(int? id)
        {
            Produtos produtos = new Produtos();
            if (id != 0 && id != null)
            {
                ProdutosDao pDao = new ProdutosDao();
                produtos = pDao.ListarProdutosId(Convert.ToInt32(id));
            }

            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Cadastrar(Produtos produtos)
        {
            ProdutosDao pDao = new ProdutosDao();
            if (produtos.Id == 0)
            {
                produtos.DataCadastro = DateTime.Now;
                pDao.Cadastrar(produtos);
                return RedirectToAction("CadastrarProdutos");
            }
            else
            {
                pDao.Edtar(produtos);
                return RedirectToAction("ListarProdutos");
            }
        }

        public ActionResult ListarProdutos()
        {
            ProdutosDao pDao = new ProdutosDao();
            ViewBag.Produtos = pDao.ListarProdutos();
            return View();
        }

        public ActionResult Deletar(int id)
        {
            ProdutosDao pDao = new ProdutosDao();
            pDao.Deletar(Convert.ToInt32(id));
            return Json(id);
        }
    }
}