using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageRepository _carImageRepository;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageRepository carImageRepository, IFileHelper fileHelper)
        {
            _carImageRepository = carImageRepository;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfThereAreMoreThanFiveImage(carImage.CarId)); // if there are more than five images returns error mesage 

            if (result != null)
            {
                return result;
            }
            
            if(carImage.ImagePath == null)
            {
                carImage.ImagePath = _fileHelper.UseDefaultImage(formFile);
            }
            carImage.ImagePath = _fileHelper.CreateFile(formFile);
            carImage.Date = DateTime.Now;
            _carImageRepository.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(int carImageId)
        {

            var carImage = _carImageRepository.Get(c => c.Id == carImageId);

            var result = _fileHelper.DeleteFile(carImage.ImagePath);

            if (result.Success)
            {
                _carImageRepository.Delete(carImage);
            }

            return result;

        }

        public IDataResult<CarImage> Get(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageRepository.Get(c => c.Id == carImageId), "You got this car image");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageRepository.GetAll().ToList(), "Car Image data listed");
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = _fileHelper.UpdateFile(formFile, carImage.ImagePath);

            if (result.Success)
            {
                _carImageRepository.Update(carImage);
            }

            return result;
        }

        public IResult CheckIfThereAreMoreThanFiveImage(int carId)
        {
            var result = _carImageRepository.GetAll(c => c.CarId == carId);

            if (result.Count >= 5)
            {
                return new ErrorResult("There is more than five images.");
            }

            return new SuccessResult("You uploaded image successfully");

        }
    }
}
