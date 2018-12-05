using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryService() { }
        public async Task<List<Category>> GetAllCategory()
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    return await _context.Category.ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
