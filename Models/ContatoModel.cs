using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroMVC.Models;


public class ContatoModel {

    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o nome do contato*")]
    public string Nome { get; set; }
    [Required (ErrorMessage = "Digite o email*")]
    [EmailAddress(ErrorMessage ="O E-mail fornecido é invalido*")]
    public string Email { get; set;}
    [Required (ErrorMessage ="Digite um número*")]
    [Phone(ErrorMessage ="O número fornecido é inválido*")]
    public string Celular { get; set;}





}
