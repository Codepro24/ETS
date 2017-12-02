using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETS.Domain;
using System.Data.SqlClient;

namespace ETS.Data
{
    public class EmployeeDAO
    {
        public void InsertEmployee(Employee emp)
        {
            //2. Create a connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";
            conn.Open();

            //3.Create a command object
            SqlCommand cmd = new SqlCommand("sp_Employees_Insert", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FName", emp.FName));
            cmd.Parameters.Add(new SqlParameter("@LName", emp.LName));
            cmd.Parameters.Add(new SqlParameter("@Email", emp.Email));
            cmd.Parameters.Add(new SqlParameter("@dob", emp.DOB));
            cmd.Parameters.Add(new SqlParameter("@phone", emp.Phone));

            //4.Execute the command
            cmd.ExecuteNonQuery();

            //5.Handle the results

            conn.Close();
        }
        //method to update employee details
        public void UpdateEmployee(Employee emp)
        {
            //2. Create a connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";
            conn.Open();

            //3.Create a command object
            SqlCommand cmd = new SqlCommand("sp_Employees_Update", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@empID", emp.EmpID));
            cmd.Parameters.Add(new SqlParameter("@FName", emp.FName));
            cmd.Parameters.Add(new SqlParameter("@LName", emp.LName));
            cmd.Parameters.Add(new SqlParameter("@Email", emp.Email));
            cmd.Parameters.Add(new SqlParameter("@dob", emp.DOB));
            cmd.Parameters.Add(new SqlParameter("@phone", emp.Phone));

            //4.Execute the command
            cmd.ExecuteNonQuery();

            //5.Handle the results

            conn.Close();
        }
        //Method to display all employees
        public List<Employee> FindEmployee()
        {
            List<Employee> listEmp = new List<Employee>();

            //2. Create a connection object
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";
            conn.Open();

            //3.Create a command object
            SqlCommand cmd = new SqlCommand("sp_Employees_SelectAll", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            

            //4.Execute the command
            SqlDataReader reader= cmd.ExecuteReader();

            //5.Handle the results
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmpID = Convert.ToInt32(reader["EmpID"]);
                emp.FName = Convert.ToString(reader["FirstName"]);
                emp.LName = Convert.ToString(reader["LastName"]);
                emp.Email = Convert.ToString(reader["Email"]);
                emp.DOB = Convert.ToString(reader["DOB"]);
                emp.Phone = Convert.ToString(reader["Phone"]);

                listEmp.Add(emp);
            }

                conn.Close();
            return listEmp;
        }
    }
}
