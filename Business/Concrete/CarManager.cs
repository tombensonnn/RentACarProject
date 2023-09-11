using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarRepository _carRepository;  
        IBrandService _brandService;

        public CarManager(ICarRepository carRepository, IBrandService brandService)
        {
            _carRepository = carRepository;
            _brandService = brandService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            BusinessRules.Run(CheckIfCarCountForBrand(car.BrandId), CheckIfModelYearExists(car.ModelYear), CheckIfBrandLimitExceeded());

            _carRepository.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carRepository.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(c => c.Id == carId));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>((_carRepository.GetAll().ToList()));
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max).ToList());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            if(DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.SomethingWentWrong);      
            }

            return new SuccessDataResult<List<CarDetailsDto>>(_carRepository.GetCarDetails(), "Car details listed");

        }

        public IResult Update(Car car)
        {
            _carRepository.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }


        public IResult CheckIfCarCountForBrand(int brandId)
        {
           return _carRepository.GetAll(c => c.BrandId == brandId).Count() >= 10 ? new ErrorResult("You cannot add a new car for this brand") : new SuccessResult();
        }

        private IResult CheckIfModelYearExists(int modelYear)
        {
            return _carRepository.GetAll(c => c.ModelYear == modelYear).Any() ? new ErrorResult("This model year is exists") : new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceeded()
        {
            var result = _brandService.GetAll();

            if(result.Data.Count > 15)
            {
                return new ErrorResult("You cannot add new car data because of brand limit exceeded");
            }

            return new SuccessResult();
        }
    }
}
 