using BOSS.Data.Infrastructure;
using BOSS.Data.Repositories;
using BOSS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void SaveChanges();
    }
    public class ErrorService: IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitofWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitofWork unitofWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitofWork;
        }

        public Error Create(Error error)
        {
           return  _errorRepository.Add(error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
