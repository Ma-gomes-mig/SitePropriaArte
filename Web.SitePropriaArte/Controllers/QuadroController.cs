using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.SitePropriaArte.Models;
using Data.SitePropriaArte.Persistence;
using Util.SitePropriaArte;
using Data.SitePropriaArte.Entidades;

namespace Web.SitePropriaArte.Controllers
{
    [Authorize]
    public class QuadroController : Controller
    {
        //GET: Usuario/EspacoGaleria
        public ActionResult EspacoGaleria()
        {
            QuadroModelGaleria ListarQuadros = new QuadroModelGaleria();
                        
            return View(ListarQuadros); //page_load
        }

        //POST: Quadro/Cadastro
        [HttpPost]
        public ActionResult CadastrarQuadro(QuadroModelCadastro model)
        {

            //var imageTypes = new string[]{
            //        "image/gif",
            //        "image/jpeg",
            //        "image/pjpeg",
            //        "image/png"
            //    };
            //if (model.Imagem == null || model.Imagem.Length == 0)
            //{
            //    ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            //}
            //else if (!imageTypes.Contains(model.Imagem))
            //{
            //    ModelState.AddModelError("ImageUpload", "Escolha uma imagem GIF, JPG ou PNG.");
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    Quadro q = new Quadro() //entidade
                    {                        
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        DataCriacao = model.DataCriacao
                    };

                    QuadroData d = new QuadroData(); //Persistencia
                    d.Insert(q); //Gravando no banco de dados

                    ViewBag.Mensagem = "O Quadro " + q.Nome
                    + ", foi cadastrado com sucesso.";
                    ModelState.Clear(); //limpar o conteudo do formulario
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("EspacoGaleria"); //page_load
        }
    }
}
