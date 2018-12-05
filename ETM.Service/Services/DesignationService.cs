using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
    public class DesignationService: IDesignationService
    {
        public DesignationService() { }
        public async Task<List<Designation>> GetAllDesignation()
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    return await _context.Designation.ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
