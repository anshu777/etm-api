using ETM.Repository.Dto;
using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
    public class StatusService : IStatusService
    {
        public async Task<List<StatusDto>> GetAll()
        {
            List<StatusDto> status = null;
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var svs = await _context.Status.Include(x => x.StatusType).ToListAsync<Status>();
                    status = (from s in svs
                              select new StatusDto()
                              {
                                  id = s.Id,
                                  name = s.Name,
                                  description = s.Description,
                                  statusId = s.StatusTypeId,
                                  status = s.StatusType.Type
                              }).ToList();
                }
                return status;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<List<StatusType>> GetAllTypes()
        {
            List<StatusType> Types = null;
            try
            {
                using(var _contaxt = new DatabaseContext())
                {
                    var stypes = await _contaxt.StatusType.ToListAsync<StatusType>();
                    Types = (from s in stypes
                             select new StatusType()
                             {
                                 Id = s.Id,
                                 Type = s.Type
                             }).ToList();
                }
                return Types;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<List<StatusDto>> GetByStatusId(int id)
        {
            List<StatusDto> status = null;
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var statusValue = await _context.Status.Where(x => x.StatusTypeId == id).Include(x => x.StatusTypeId).ToListAsync<Status>();
                    status = (from s in statusValue
                              select new StatusDto()
                              {
                                  id = s.Id,
                                  name = s.Name,
                                  description = s.Description,
                                  statusId = s.StatusTypeId
                              }).ToList();
                }



                return status;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Status> AddStatus(Status status)
        {
            try
            {
                
                int sid;
                using (var _context = new DatabaseContext())
                {
                    

                    _context.Status.Add(status);
                    await _context.SaveChangesAsync();
                }

               

                return status;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
