using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalRepository _rentalRepository;

        public RentalManager(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public IResult Add(Rental rental)
        {

            var rentedCar = _rentalRepository.GetAll(r => r.CarId == rental.CarId && r.ReturnDate != null);

            if (rentedCar.Any())
            {
                return new ErrorResult(Messages.CarNotAvailable);

            }
            else
            {

                _rentalRepository.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

        }

        public IResult Delete(Rental rental)
        {
            _rentalRepository.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalRepository.Get(r => r.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalRepository.GetAll().ToList());
        }

        public IResult Update(Rental rental)
        {
            _rentalRepository.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
