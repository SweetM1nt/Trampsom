
using System.Data.Entity;

namespace Web.Models.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<WebApplication.Models.Bicho> Bichoes { get; set; }
    }
}