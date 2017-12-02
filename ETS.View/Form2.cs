using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using ETS.Domain; //to enable access to Employee class
using ETS.Logic;   //for accessing methods in Logic 

namespace ETS.View
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Create instance of EmployeeService class
             EmployeeService service = new EmployeeService();

            //call Find method from EmployeeService class
            List<Employee> list = service.FindEmployee();

            //display the result on dgvCategories
            dgvEmployees.DataSource = list;
        }

        
        //click event to add hours
        private void btnAddHours_Click(object sender, EventArgs e)
        {
            EmpHrs empHrs = new EmpHrs();
            try
            {
                empHrs.EmpID = int.Parse(txtEmpID.Text);
                empHrs.WorkDate = txtDate.Text;
                empHrs.Hours = int.Parse(txtHours.Text);
                MessageBox.Show("Employee Hours added successfully!");
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter valid inputs");
            }
            

            //create EmpHoursService object
            EmpHrsService service = new EmpHrsService();
            service.AddEmpHours(empHrs);
        }
        //click event to show total hours of employee
        private void btnShowHrs_Click(object sender, EventArgs e)
        {
            int id;
            int totalHours = 0;
            try
            {
                id = int.Parse(txtEmpID.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a valid ID");
                return;
            }
            
            //    //create EmpHoursService object
                EmpHrsService service = new EmpHrsService();

                //call method
                Result<List<EmpHrs>> res = new Result<List<EmpHrs>>();
                res = service.EmpHoursbyID(id);
               if (res.Status == ResultEnum.Success && res.Data.Count() != 0)
                {

                    foreach (EmpHrs ehrs in res.Data)
                    {
                        totalHours += ehrs.Hours;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Error!");
                }
                             
                dgvEmployees.DataSource = res.Data;
                lblEmpTotalHrs.Text = "Total Hours worked by Employee ID " + id + " : " + totalHours.ToString();
            
        }            
            
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //click event to update details
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime d;
            if (new EmailAddressAttribute().IsValid(txtEmailAdd.Text) == false)
            {
                MessageBox.Show("Please enter a valid email");
                return;
            }

            if (!DateTime.TryParse(txtDateofBirth.Text, out d))
            {
                MessageBox.Show("Please enter a valid date");
                return;
            }

            if (new PhoneAttribute().IsValid(txtPhoneNo.Text) == false)
            {
                MessageBox.Show("Please enter a valid phone number");
                return;
            }

            Employee emp = new Employee();
            emp.EmpID = int.Parse(txtEmpID.Text);
            emp.FName = txtFirstName.Text;
            emp.LName = txtLastName.Text;
            emp.Email = txtEmailAdd.Text;
            emp.DOB = txtDateofBirth.Text;
            emp.Phone = txtPhoneNo.Text;

            EmployeeService service = new EmployeeService();
            ResultEnum result = new ResultEnum();
            result = service.UpdateEmployee(emp);
            //check if Employee updated or not
            if (result == ResultEnum.Success)
            {
                MessageBox.Show("Employee Details Updated!");

            }
            else
            {
                MessageBox.Show("Sorry, couldn't Update Details");
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            try
            {
                DataGridViewRow selectedRow = dgvEmployees.Rows[index];
                txtEmpID.Text = selectedRow.Cells[0].Value.ToString();
                txtFirstName.Text = selectedRow.Cells[1].Value.ToString();
                txtLastName.Text = selectedRow.Cells[2].Value.ToString();
                txtEmailAdd.Text = selectedRow.Cells[3].Value.ToString();
                txtDateofBirth.Text = Convert.ToDateTime(selectedRow.Cells[4].Value).ToShortDateString();
                txtPhoneNo.Text = selectedRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Error");
                
            }
        }

        private void btnFindByEmail_Click(object sender, EventArgs e)
        {
            if (new EmailAddressAttribute().IsValid(txtEmailAdd.Text) == false)
            {
                MessageBox.Show("Please enter a valid email");
                return;
            }
            else
            {
                string email;
                int totalHours = 0;
                email = txtEmailAdd.Text;
                
                //create EmpHoursService object
                EmpHrsService service = new EmpHrsService();

                //call method
                Result<List<EmpHrs>> res = new Result<List<EmpHrs>>();
                res = service.FindEmpbyEmail(email);
                if (res.Status == ResultEnum.Success && res.Data.Count() != 0)
                {

                    foreach (EmpHrs ehrs in res.Data)
                    {
                        totalHours += ehrs.Hours;

                    }
                }
                else
                {
                    MessageBox.Show("Oops! Error");
                }
                
                dgvEmployees.DataSource = res.Data;
                lblEmpTotalHrs.Text = "Total Hours worked by this Employee: " + totalHours.ToString() + " hours.";

            }

        }
    }
}
