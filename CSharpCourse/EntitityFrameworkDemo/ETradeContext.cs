using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitityFrameworkDemo
{
    public class ETradeContext:DbContext
    {
        //Db deki tablo adiyla direkt baglanti kurmak icin
        public DbSet<Product> Products { get; set; }
    }
}
