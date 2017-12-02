using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETS.Data;
using ETS.Domain;

namespace ETS.Logic
{
    public class EmployeeService
    {   
        //Adds Employee into Database
        public ResultEnum InsertEmployee(Employee emp)
        {
            ResultEnum result = ResultEnum.Success;
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                dao.InsertEmployee(emp); 
            }
            catch
            {
                result = ResultEnum.Fail;
            }
            return result;
            
        }
        //Updates an employee details
        public ResultEnum UpdateEmployee(Employee emp)
        {
            ResultEnum result = ResultEnum.Success;
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                dao.UpdateEmployee(emp);
            }
            catch
            {
                result = ResultEnum.Fail;
            }
            return result;
        }
        //Find/Shows all Employees
        public List<Employee> FindEmployee()
        {
            List<Employee> emp = new List<Employee>();
            //ResultEnum result = ResultEnum.Success;
            try
            {
                EmployeeDAO dao = new EmployeeDAO();
                emp =  dao.FindEmployee();
            }
            catch
            {
                //    result = ResultEnum.Fail;
            }
            return emp;

        }
    }
}
