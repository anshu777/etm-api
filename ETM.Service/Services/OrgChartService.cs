using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.Repository.Models;
using ETM.Repository.Dto;
using System.Data.Entity;

namespace ETM.Service.Services
{
    public class OrgChartService : IOrgChartService
    {
        public async Task<OrgChartDto> getOrgChart(int projectid)
        {
            OrgChartDto orgChartdto = new OrgChartDto();
            Employee emp = new Employee();
            List<Employee> empList;
            List<TempDto> teamList;
            List<int> ts;
            //.Include(x =>x.Project)
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var teams = _context.Team.Where(x => x.ProjectId == projectid).ToList<Team>();
                    teamList = (from t in teams
                                select new TempDto()
                                {
                                    id = t.Id,
                                }).ToList();

                    foreach (TempDto t in teamList)
                    {
                    var emps = await _context.Employee.Where(x => x.TeamId == t.id).Include(x => x.Designation).ToListAsync<Employee>();
                    t.emplist = (from e in emps
                               select new Employee()
                               {
                                   Id = e.Id,
                                   Name = e.Name,
                                   DesignationId = e.DesignationId,
                                   TeamId = e.TeamId,
                                   Designation = e.Designation
                               }).ToList();
                       
                }//foreach
                    List<OrgChartDto> TLLevel = new List<OrgChartDto>();
                    int i = 0;
                    foreach (TempDto t in teamList)
                    { if (i > 0) continue;
                        List<OrgChartDto> EmpLevel = new List<OrgChartDto>();
                        OrgChartDto temp1 = new OrgChartDto();
                        OrgChartDto temp = new OrgChartDto();
                        temp = temp1;
                        if (t.emplist != null)
                        {
                            foreach (Employee e in t.emplist)
                            {
                                if (e != null)
                                {
                                    temp.name = e.Name;
                                    temp.designation = e.Designation.Name;
                                    temp.subordinates = new List<OrgChartDto>();


                                    //List<OrgChartDto> tempList = new List<OrgChartDto>();

                                    if (e.DesignationId == 11)
                                    {
                                        orgChartdto = temp;
                                    }

                                    else if (e.DesignationId == 4)
                                    {
                                        TLLevel.Add(temp);
                                    }
                                    else
                                    {
                                        EmpLevel.Add(temp);
                                        //temp.subordinates.Add(temp);
                                        //temp = temp.subordinates[0];
                                    }
                                }
                            }
                            //EmpLevel.Add(temp1);
                            if(TLLevel[i]!=null)
                            TLLevel[i++].subordinates = (EmpLevel);
                        }
                    }
                    orgChartdto.subordinates = TLLevel;
                }
                return orgChartdto;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
