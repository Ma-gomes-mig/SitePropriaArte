using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.SitePropriaArte.Models;
using Data.SitePropriaArte.Entities;
using Data.SitePropriaArte.Persistence;
using Util.SitePropriaArte;
using System.Web.Security;

namespace Web.SitePropriaArte.Controllers
{
    public class UsuarioController : Controller
    {
        //GET: /Index
        public ActionResult Index()
        {
            return View(); //Page_load
        }


        // GET: /Usuario/Cadastro
        public ActionResult Cadastro()
        {
            return View(); //page_load
        }

        //POST: /Usuario/CadastrarUsuario
        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario() //entidade
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = Criptografia.GetMD5Hash(model.Senha),
                        DataCadastro = DateTime.Now
                    };

                    UsuarioData d = new UsuarioData(); //persistencia
                    d.Insert(u); //gravando na base de dados...

                    ViewBag.Mensagem = "Usuario " + u.Nome
                    + ", cadastrado com sucesso.";
                    ModelState.Clear(); //limpar o conteudo do formulario
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro"); //page_load
        }

        
        // GET: /Usuario/Login
        public ActionResult Login()
        {
            return View(); //page_load
        }

        //POST: /Usuario/AutenticarUsuario
        [HttpPost]
        public ActionResult AutenticarUsuario(UsuarioModelLogin model)
        {
            //verificar se nao ocorreram erros de validação na model
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioData d = new UsuarioData(); //persistencia...
                    Usuario u = d.Authenticate(model.Login,
                   Criptografia.GetMD5Hash(model.Senha));
                    if (u != null) //usuario foi encontrado....
                    {
                        //Gerar um Ticket de Acesso para o usuario...
                        FormsAuthentication.SetAuthCookie(u.Email, false);
                        //Armazenar o objeto Usuario em sessão...
                        Session.Add("usuariologado", u);

                        //redirecionar para a Quadros   ...
                        return RedirectToAction("EspacoGaleria","Quadro" );
                    }
                    else //usuario nao encontrado...
                    {
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return RedirectToActionPermanent("EspacoGaleria", "Quadro"); //page_load
        }

        [Authorize]
        public ActionResult Logout()
        {
            //Passo 1) Remover o ticket de acesso criado..
            FormsAuthentication.SignOut();
            //Passo 2) Remover o usuario logado da sessão..
            Session.Remove("usuariologado");
            Session.Abandon(); //invalida a sessão..
            return View("Login");
        }

    }
}