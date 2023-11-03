using SistemaWeb.Models;
using SistemaWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult CadastrarCategoria(int? id)
        {
            Categoria categoria = new Categoria();
            if (id != 0 && id != null)
            {
                CategoriaDao cDao = new CategoriaDao();
                categoria = cDao.ListarCategoriaId(id);
            }
            ViewBag.Categoria = categoria;

            return View();
        }

        public ActionResult Cadastrar(Categoria categoria)
        {
            CategoriaDao cDao = new CategoriaDao();
            if (categoria.Id == 0)
            {
                cDao.Cadastrar(categoria);
                return RedirectToAction("CadastrarCategoria");
            }
            else
            {
                cDao.Edtar(categoria);
                return RedirectToAction("ListarCategoria");
            }
        }

        public ActionResult ListarCategoria()
        {
            CategoriaDao cDao = new CategoriaDao();
            ViewBag.Categoria = cDao.ListarCategoria();
            return View();
        }

        public ActionResult Deletar(int id)
        {
            CategoriaDao cDao = new CategoriaDao();
            cDao.Deletar(Convert.ToInt32(id));
            return Json(id);
        }
    }
}