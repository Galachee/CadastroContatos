using Microsoft.EntityFrameworkCore;
using System;
namespace CadastroMVC.Models;

public class BancoContext : DbContext 
{
    public BancoContext(DbContextOptions<BancoContext> options) : base (options)
    {

    }

    public DbSet<ContatoModel> Contato { get; set; }


}