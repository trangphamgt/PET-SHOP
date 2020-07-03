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
    public interface IAccountService
    {
        string GetUserByEmail(string email);
    }
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;
        IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }
        public string GetUserByEmail(string email)
        {
            return _accountRepository.GetUserNameByEmail(email);
        }
       
    }
}
