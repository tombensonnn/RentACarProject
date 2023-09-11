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
    public class ColorManager : IColorService
    {

        IColorRepository _colorRepository;

        public ColorManager(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public IResult Add(Color color)
        {
            _colorRepository.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorRepository.Delete(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colorRepository.Get(c => c.Id == id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorRepository.GetAll().ToList());
        }

        public IResult Update(Color color)
        {
            _colorRepository.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
