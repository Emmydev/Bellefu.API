using Bellefu.API.Data;
using Bellefu.API.DbObjects;
using Bellefu.API.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Bellefu.API.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DataContext _context;

        public MenuRepository(DataContext context)
        {
            _context = context;
        }
        public bool DeleteMenu(int Id)
        {
            try 
            {
                var menu = _context.Menu.Find(Id);

                if(menu != null)
                {
                    menu.Deleted = true;
                }
                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MenuObj> GetAllMenu()
        {
            try
            {
                var customerList = (from a in _context.Menu
                                    where a.Deleted == false
                                    select new MenuObj
                                    {
                                        MenuId = a.MenuId,
                                        Name = a.Name,
                                        Decription = a.Decription,
                                        Cost = a.Cost

                                    }).ToList();
                return customerList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public MenuObj GetMenuById(int Id)
        {
            try
            {
                var menu = (from a in _context.Menu
                            where a.Deleted == false && a.MenuId == Id
                            select new MenuObj
                            {
                                MenuId = a.MenuId,
                                Name = a.Name,
                                Decription = a.Decription,
                                Cost = a.Cost

                            }).FirstOrDefault();
                return menu;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMenu(MenuObj entity)
        {
            try
            {
                if (entity == null) return false;

                if(entity.MenuId > 0)
                {
                    var itemExist = _context.Menu.FirstOrDefault(x => x.MenuId == entity.MenuId);
                    if(itemExist != null)
                    {
                        itemExist.Name = entity.Name;
                        itemExist.Decription = entity.Decription;
                        itemExist.Cost = entity.Cost;
                        itemExist.Active = true;
                        itemExist.Deleted = false;
                        itemExist.UpdatedBy = entity.CreatedBy;
                        itemExist.UpdatedOn = DateTime.Now;
                        
                    }
                }
                else
                {
                    var item = new Menu
                    {
                        Name = entity.Name,
                        Decription = entity.Decription,
                        Cost = entity.Cost,
                        Active = true,
                        Deleted = false,
                        CreatedBy = entity.CreatedBy,
                        CreatedOn = DateTime.Now
                    };
                    _context.Menu.Add(item);
                }

                var response = _context.SaveChanges() > 0;
                return response;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
