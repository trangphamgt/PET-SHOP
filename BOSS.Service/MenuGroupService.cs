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
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup model);
        MenuGroup Delete(int id);
        MenuGroup Delete(MenuGroup model);
        MenuGroup GetById(int id);
        void Update(MenuGroup model);
        IEnumerable<MenuGroup> GetAll();
        IEnumerable<MenuGroup> GetAllPaging(int pageIndex, int page, out int totalRow);
        IEnumerable<MenuGroup> GetAllByTagPaging(int tag, int pageIndex, int page, int totalRow);
        void SaveChanges();
    }
    public class MenuGroupService : IMenuGroupService
    {
        IMenuGroupRepository _menuGroupRepository;
        IUnitOfWork _unitofWork;
        
        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork unitofWork)
        {
            this._menuGroupRepository = menuGroupRepository;
            this._unitofWork = unitofWork;
        }
        public MenuGroup Add(MenuGroup model)
        {
            return _menuGroupRepository.Add(model);
        }

        public MenuGroup Delete(int id)
        {
            return _menuGroupRepository.Delete(id);
        }

        public MenuGroup Delete(MenuGroup model)
        {
            return _menuGroupRepository.Delete(model);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }


        public IEnumerable<MenuGroup> GetAllByTagPaging(int tag, int pageIndex, int page, int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuGroup> GetAllPaging(int pageIndex, int page, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public MenuGroup GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitofWork.Commit();
        }

        public void Update(MenuGroup model)
        {
            throw new NotImplementedException();
        }
    }
}
