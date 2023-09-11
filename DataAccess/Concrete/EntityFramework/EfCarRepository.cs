using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarRepository : EfEntityRepositoryBase<Car, ReCapContext>, ICarRepository
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             select new CarDetailsDto { CarId = c.Id, BrandName = b.Name, ColorName = col.Name, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }
    }
}
