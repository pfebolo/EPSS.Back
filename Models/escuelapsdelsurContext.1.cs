using System;
using Microsoft.EntityFrameworkCore;
using EPSS.Settings;


namespace EPSS.Models
{
    public partial class escuelapsdelsurContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Console.WriteLine("Configurar Conexión de DB");
            optionsBuilder.UseSqlServer(settings.connectionStrings.DefaultConnection);
        }



    }
}