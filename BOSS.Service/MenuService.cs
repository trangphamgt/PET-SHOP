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
    public interface IMenuService
    {
        Menu Add(Menu model);
        Menu Delete(int id);
        Menu Delete(Menu model);
        Menu GetById(int id);
        void Update(Menu model);
        IEnumerable<Menu> GetAll();
        void SaveChanges();


    }
    public class MenuService : IMenuService
    {
        IMenuRepository _menuRepository;
        IUnitOfWork _unitOfWork;
        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }
        public Menu Add(Menu model)
        {
            return _menuRepository.Add(model);
        }

        public Menu Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Menu Delete(Menu model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll()
        {
            throw new NotImplementedException();
        }

        public Menu GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Menu model)
        {
            throw new NotImplementedException();
        }
    }
}
