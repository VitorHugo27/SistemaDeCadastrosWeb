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
        // GET: Produtos
        public ActionResult CadastrarProdutos()
        {
            Produtos produtos;
            //ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Cadastrar(Produtos produtos)
        {
            produtos.DataCadastro = DateTime.Now;
            ProdutosDao pDao = new ProdutosDao();
            pDao.Cadastrar(produtos);
            return RedirectToAction("CadastrarProdutos");
        }

        public ActionResult ListarProdutos()
        {
            ProdutosDao pDao = new ProdutosDao();
            ViewBag.Produtos = pDao.ListarProdutos();
            return View();
        }


    }
}