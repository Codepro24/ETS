using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETS.Data;
using ETS.Domain;

namespace ETS.Logic
{
    public class EmpHrsService
    {
        //method to add Employee Hours
        public void AddEmpHours(EmpHrs empDailyHrs)
        {
            //create EmpHrs object
            try
            {
                EmpHrsDAO dao = new EmpHrsDAO();
                dao.AddEmpHrs(empDailyHrs);
                
            }
            catch
            {   
                // Ask Shanty
            }
        }

        
        //method to get hours by EmpID
        public Result<List<EmpHrs>> EmpHoursbyID(int empID)
        {
            Result<List<EmpHrs>> resHrs = new Result<List<EmpHrs>>();
            try
            {
                EmpHrsDAO dao = new EmpHrsDAO();
                resHrs.Data = dao.EmpTotalHrs(empID);
                resHrs.Status = ResultEnum.Success;
            }
            catch 
            {

                resHrs.Status = ResultEnum.Fail;
            }

            return resHrs;

        }
        //method to find employee by email
        public Result<List<EmpHrs>> FindEmpbyEmail(string emailID)
        {
            Result<List<EmpHrs>> resHrs = new Result<List<EmpHrs>>();
            try
            {
                EmpHrsDAO dao = new EmpHrsDAO();
                resHrs.Data = dao.EmpHoursByEmail(emailID);
                resHrs.Status = ResultEnum.Success;
            }
            catch
            {

                resHrs.Status = ResultEnum.Fail;
            }
            return resHrs;

        }

    }
}
