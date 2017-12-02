using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using ETS.Domain;
using ETS.Logic;



namespace ETS.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            DateTime d;
            if (new EmailAddressAttribute().IsValid(txtEmail.Text) == false)
            {
                MessageBox.Show("Please enter a valid email");
                return;
            }
            
            if(!DateTime.TryParse(txtDOB.Text,out d))
            {
                MessageBox.Show("Please enter a valid date");
                return;
            }
           
            if (new PhoneAttribute().IsValid(txtPhone.Text) == false) 
            {
                MessageBox.Show("Please enter a valid phone number");
                return;
            }

            Employee emp = new Employee();
            emp.FName = txtFName.Text;
            emp.LName = txtLName.Text;
            emp.Email = txtEmail.Text;
            emp.DOB = txtDOB.Text;
            emp.Phone = txtPhone.Text;

            EmployeeService service = new EmployeeService();
            ResultEnum result = new ResultEnum();
            result = service.InsertEmployee(emp);
            //check if Employee added or not
            if (result == ResultEnum.Success)
            {
                MessageBox.Show("Employee Added to Database!");

            }
            else
            {
                MessageBox.Show("Sorry, couldn't add Employee");
            }
        }

       
        private void btnFindAll_Click(object sender, EventArgs e)
        {
            Form2 displayForm = new Form2();
            displayForm.ShowDialog();
        }

        private void btnHours_Click(object sender, EventArgs e)
        {
            Form2 displayForm = new Form2();
            displayForm.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Employee emp = new Employee();
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtDOB.Text = "";
            txtPhone.Text = "";
        }

        private void btnAddEmployeeHrs_Click(object sender, EventArgs e)
        {
            Form2 displayForm = new Form2();
            displayForm.ShowDialog();

        }

    }
}
