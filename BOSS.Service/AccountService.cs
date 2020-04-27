using BOSS.Data.Infrastructure;
using BOSS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS.Service
{
    public interface IAccountService
    {
        string GetUserNameByEmail(string email);
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
        public string GetUserNameByEmail(string email)
        {
            return _accountRepository.GetUserNameByEmail(email);
        }
    }
}
