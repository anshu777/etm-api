using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.Repository.Dto;
using ETM.Repository.Models;

namespace ETM.Service.Services
{
    public class MRFService : IMRFService
    {
        public async Task<MRFDto> AddMRFRaise(MRFDto mrfdto)
        {
            using (var _context = new DatabaseContext())
            {
                try
                {
                    var mrf = mapdtotoentity(mrfdto);
                    _context.MRF.Add(mrf);
                    int x = _context.SaveChanges();

                    MRFSkills mrfskill = new MRFSkills();
                    mrfskill.MRFid = mrf.id;
                    foreach (int skillid in mrfdto.skillsId)
                    {
                        mrfskill.skillid = skillid;
                        _context.MRFSkills.Add(mrfskill);
                        x = _context.SaveChanges();
                    }
                    

                    return mrfdto;
                }
                catch
                {
                    throw;
                }
            }
        }

        private MRF mapdtotoentity(MRFDto mrfdto)
        {
            MRF mrf = new MRF();
            mrf.Project = mrfdto.Project;
            mrf.ProjectMgr = mrfdto.ProjectMgr;
            mrf.DesignationId = mrfdto.DesignationId;
            mrf.OfferedSalary = mrfdto.OfferedSalary;
            mrf.PRB = mrfdto.PRB;
            mrf.Remarks = mrfdto.Remarks;
            mrf.IsApproved = mrfdto.IsApproved;
            mrf.Date = mrfdto.Date;
            mrf.NoOfEmployess = mrfdto.NoOfEmployess;
            mrf.NewRequest = mrfdto.NewRequest;
            mrf.YearsOfExp = mrfdto.YearsOfExp;
            mrf.Location = mrfdto.Location;
            return mrf;
        }
    }
}
