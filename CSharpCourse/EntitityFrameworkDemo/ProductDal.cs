using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EntitityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            //using kullanilmasinin sebebi method ile isimiz bittiginde garbage collectoru beklemeye
            //gerek kalmadan aninda dispose etmektir.
            using (ETradeContext context = new ETradeContext())
            {
                //contexti kullanarak gereksiz kod yazmaktan kurtulduk ve datayi hizlica datasource a verdik
                //context app.config dosyasindaki connectionStringsde kendi adini arayacak ve connection baglatinisina ulasacak
                return context.Products.ToList();
            }
        }

        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //contexti kullanarak gereksiz kod yazmaktan kurtulduk ve datayi hizlica datasource a verdik
                //context app.config dosyasindaki connectionStringsde kendi adini arayacak ve connection baglatinisina ulasacak
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetByLowerUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //contexti kullanarak gereksiz kod yazmaktan kurtulduk ve datayi hizlica datasource a verdik
                //context app.config dosyasindaki connectionStringsde kendi adini arayacak ve connection baglatinisina ulasacak
                return context.Products.Where(p=>p.UnitPrice<=price).ToList();
            }
        }

        public List<Product> GetByBetweenUnitPrices(decimal minPrice, decimal maxPrice)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //contexti kullanarak gereksiz kod yazmaktan kurtulduk ve datayi hizlica datasource a verdik
                //context app.config dosyasindaki connectionStringsde kendi adini arayacak ve connection baglatinisina ulasacak
                return context.Products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice<= maxPrice).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //contexti kullanarak gereksiz kod yazmaktan kurtulduk ve datayi hizlica datasource a verdik
                //context app.config dosyasindaki connectionStringsde kendi adini arayacak ve connection baglatinisina ulasacak
                //return context.Products.Where(p => p.Id==id).FirstOrDefault(); bulamazsa null döner, eğer çok bulduysa ilkini alır
                return context.Products.Where(p => p.Id == id).SingleOrDefault(); //bulamazsa null döner, eğer çok bulduysa da hata verir
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using(ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
