using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class BrandManager : IBrandService
    {

        IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public IResult Add(Brand brand)
        {
            _brandRepository.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandRepository.Delete(brand);

            return new SuccessResult(Messages.BrandDeleted);
        }

        [CacheAspect]
        public IDataResult<Brand> Get(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandRepository.Get(b => b.Id == brandId));
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandRepository.GetAll().ToList());
        }

        public IResult Update(Brand brand)
        {
            _brandRepository.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
