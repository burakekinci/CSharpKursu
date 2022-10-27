using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
        //Dal operasyonlarını generic olarak tanımladığımız için her bir entityFramewok DAL'ı için ayrıca implemantasyon yapmamıza gerek yok        
    }
}
