using Bellefu.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Repository
{
    public interface IMenuRepository
    {
        bool DeleteMenu(int Id);

        IEnumerable<MenuObj> GetAllMenu();

        MenuObj GetMenuById(int Id);

        bool UpdateMenu(MenuObj entity);

    }
}
