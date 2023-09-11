using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<Car> Get(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
