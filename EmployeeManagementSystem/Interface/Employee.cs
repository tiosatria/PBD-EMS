using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeManagementSystem.Controller;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.FileDialogs;

namespace EmployeeManagementSystem.Interface
{
    public partial class Employee : UserControl
    {
        private bool isLoad = false, isSaved = false;
        public Employee()
        {

        }
        public void InitializeObject()
        {
            if(isLoad)
            {

            }
            else
            {
                InitializeComponent();
                Data.GetEmployees();
                InitGrid();
            }
            isLoad = true;
        }

        private void InitGrid()
        {
            Data.employeesList.Sort((x, y) => x.FullName.CompareTo(y.FullName));
            dgEmployee.DataSource = Data.employeesList;
            dgEmployee.Columns[0].Visible = true;
            dgEmployee.Columns[0].HeaderText= "Employee ID";
            dgEmployee.Columns[1].Visible = false;
            dgEmployee.Columns[2].Visible = false;
            dgEmployee.Columns[3].Visible = true;
            dgEmployee.Columns[3].HeaderText = "Full Name";
            dgEmployee.Columns[4].Visible = false;
            dgEmployee.Columns[5].Visible = false;
            dgEmployee.Columns[6].Visible = false;
            dgEmployee.Columns[7].Visible = false;
            dgEmployee.Columns[8].Visible = false;
            dgEmployee.Columns[9].Visible = false;
            dgEmployee.Columns[10].Visible = false;
            dgEmployee.Columns[11].HeaderText = "Job Title";
            dgEmployee.Columns[11].Visible = true;
            dgEmployee.Columns[12].Visible = false;
            dgEmployee.Columns[13].Visible = false;
        }

        private void CtrlEmployee_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UIController.Navigate(UIController.Controls.DeleteEmp);
        }

        private void dgEmployee_SelectionChanged(object sender, EventArgs e)
        {
            int i;
                i = Convert.ToInt32(dgEmployee.CurrentRow.Cells[0].Value);
                DisplaySelectedEmployee(i);
        }
        private void DisplaySelectedEmployee(int i)
        {
            int index = Data.employeesList.FindIndex(id => id.idEmployee.ToString().Contains(i.ToString()));
            Data.employee = Data.employeesList[index];
            txtFullname.Text = Data.employee.FullName;
            txtAddress.Text = Data.employee.ResAddress;
            txtContact.Text = Data.employee.Mobile;
            txtDept.Text = Data.employee.Department;
            txtJobTitle.Text = Data.employee.JobTitle;
            try
            {
                picEmp.Image = Image.FromFile(Data.employee.picLocation);

            }
            catch (Exception)
            {
                picEmp.Image = Resources.icons8_male_user_52px;
            }
        }

        public enum state { View, Create, Update}
        public enum stateCreate { personal, document }
        private stateCreate _stateCreate;
        private state _state;

        private void FocusingButton(Guna2Button button)
        {
            btnPersonal.FillColor = Color.White;
            btnPersonal.ForeColor = Color.Black;
            btnDocuments.FillColor = Color.White;
            btnDocuments.ForeColor = Color.Black;
            button.FillColor = Color.Black;
            button.ForeColor = Color.White;
        }

        private void NavigateCreate(stateCreate state)
        {
            _stateCreate = state;
            switch (state)
            {
                case stateCreate.personal:
                    CtrPersonal.BringToFront();
                    FocusingButton(btnPersonal);
                    break;
                case stateCreate.document:
                    CtrlDocuments.BringToFront();
                    FocusingButton(btnDocuments);
                    break;
                default:
                    break;
            }
        }



        private void InitData()
        {

        }

        private void Navigate(state state)
        {
            _state = state;
            switch (state)
            {
                case state.View:
                    CtrlEmployeeView.BringToFront();
                    btnNewRecord.FillColor = Color.White;
                    break;
                case state.Create:
                    UIController.ResetControl(CtrPersonal);
                    UIController.ResetControl(CtrlDocuments);
                    CtrCreateUpdate.BringToFront();
                    NavigateCreate(stateCreate.personal);
                    break;
                case state.Update:
                    InitData();
                    CtrCreateUpdate.BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Navigate(state.Create);
        }

        private void dgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
                i = Convert.ToInt32(dgEmployee.CurrentRow.Cells[0].Value);
                DisplaySelectedEmployee(i);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Navigate(state.Update);
        }

        private void UpdateData()
        { 
        
        }

        private void InsertData()
        {
            
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            NavigateCreate(stateCreate.personal);
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            NavigateCreate(stateCreate.document);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigate(state.View);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isLoad)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
        }
    }
}
