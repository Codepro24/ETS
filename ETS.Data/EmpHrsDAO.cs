using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //see Lesson 6 for comments
using ETS.Domain;

namespace ETS.Data
{
    public class EmpHrsDAO
    {
        //method to add employee hours to database
        public void AddEmpHrs(EmpHrs empDailyHrs)
        {
            //create connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";
            conn.Open();


            //create command object
            SqlCommand cmd = new SqlCommand("sp_EmpHours_Insert", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@empID", empDailyHrs.EmpID));
            cmd.Parameters.Add(new SqlParameter("@workDate", empDailyHrs.WorkDate));
            cmd.Parameters.Add(new SqlParameter("@hrs", empDailyHrs.Hours));

            //execute command
            cmd.ExecuteNonQuery(); 

            //handle result
            conn.Close();
        }

        //method to get an employee's days worked and hours
        public List<EmpHrs> EmpTotalHrs(int empID)
        {
            List<EmpHrs> listHrs = new List<EmpHrs>(); 
            //create connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";
            conn.Open();


            //create command object
            SqlCommand cmd = new SqlCommand("sp_EmpHours_WorkDateHrs", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@empID", empID));


            //4.Execute the command - select
            SqlDataReader reader = cmd.ExecuteReader();

            //5.Handle the results
            while (reader.Read())
            {
                EmpHrs eh = new EmpHrs();
                eh.EmpID = empID;
                eh.Hours = Convert.ToInt32(reader["Hours"]);
                eh.WorkDate = Convert.ToString(reader["WorkDate"]);
                eh.FName = Convert.ToString(reader["FirstName"]);
                eh.LName = Convert.ToString(reader["LastName"]);
                listHrs.Add(eh);
             }

            //handle result
            conn.Close();

            return listHrs;
        }
        //Find an employee hours by email
        public List<EmpHrs> EmpHoursByEmail(string emailID)
        {
            List<EmpHrs> listHrs = new List<EmpHrs>();
            //create connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";
            conn.Open();


            //create command object
            SqlCommand cmd = new SqlCommand("sp_Employees_SelectByEmail", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Email", emailID));


            //4.Execute the command - select
            SqlDataReader reader = cmd.ExecuteReader();

            //5.Handle the results
            while (reader.Read())
            {
                EmpHrs eh = new EmpHrs();
                eh.EmpID = Convert.ToInt32(reader["EmpID"]);
                eh.Hours = Convert.ToInt32(reader["Hours"]);
                eh.WorkDate = Convert.ToString(reader["WorkDate"]);
                eh.FName = Convert.ToString(reader["FirstName"]);
                eh.LName = Convert.ToString(reader["LastName"]);
                listHrs.Add(eh);
            }

            //handle result
            conn.Close();
            return listHrs;

        }



    }
}
