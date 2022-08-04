﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Mapeamento
using Web.SitePropriaArte.Validators;

namespace Web.SitePropriaArte.Models
{
    public class UsuarioModelLogin
    {
        [Required(ErrorMessage = "Por favor, informe o login de acesso.")]
        [Display(Name = "Informe seu Login:")] //label
        public string Login { get; set; } //campo

        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        [Display(Name = "Informe sua Senha:")] //label
        public string Senha { get; set; } //campo
    }

    public class UsuarioModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuario.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$",
        ErrorMessage = "Erro. Nome inválido.")]
        [Display(Name = "Informe seu Nome:")] //label
        public string Nome { get; set; } //campo


        [Required(ErrorMessage = "Por favor, informe o login do usuario.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
        ErrorMessage = "Erro. Login inválido.")]
        [Display(Name = "Login de Acesso:")] //label
        [LoginDisponivel(ErrorMessage = "Erro. Este login encontra-se indisponivel.Tente outro.")]
        public string Email { get; set; } //campo


        [Required(ErrorMessage = "Por favor, informe a senha do usuario.")]
        [RegularExpression("^[A-Za-z0-9@]{6,20}$",
        ErrorMessage = "Erro. Senha inválida.")]
        [Display(Name = "Senha de Acesso:")] //label
        public string Senha { get; set; } //campo

            
        [Required(ErrorMessage = "Por favor, confirme a senha do usuario.")]
        [Compare("Senha",
        ErrorMessage = "Erro. Confirme sua Senha corretamente.")]
        [Display(Name = "Confirme sua Senha:")] //label
        public string SenhaConfirm { get; set; } //campo
    }
}
