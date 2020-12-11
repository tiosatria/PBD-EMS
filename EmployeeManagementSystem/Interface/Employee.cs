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
                InitDropBox();
            }
            isLoad = true;
        }

        private void InitDropBox()
        {

            
            
        }

        public enum state { View, Create, Update}
        public enum stateCreate { personal, document }
        private stateCreate _stateCreate;
        private state _state;

        private void NavigateCreate(stateCreate state)
        {
            //_stateCreate = state;
            //switch (state)
            //{
            //    case stateCreate.personal:
            //        CtrPersonal.BringToFront();
            //        FocusingButton(btnPersonal);
            //        break;
            //    case stateCreate.document:
            //        CtrlDocuments.BringToFront();
            //        FocusingButton(btnDocuments);
            //        break;
            //    default:
            //        break;
            //}
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Navigate(state.Update);
        }

        private void UpdateData()
        {
            string[] str = new string[10];
        }

        //private void ParseData()
        //{
        //    Data.employee.FirstName = eTxtFname.Text;
        //    Data.employee.LastName = eTxtLname.Text;
        //    Data.employee.ResAddress = eAddress.Text;
        //    Data.employee.ResPostCode = ePost.Text;
        //    Data.employee.Mobile = eMobile.Text;
        //    Data.employee.HomePhone = eHomePhone.Text;
        //    Data.employee.Nik = eNik.Text;
        //    Data.employee.DepartmentId = Data.department.DeptID;
        //    Data.employee.Desc = eDesc.Text;
        //    Data.employee.JobTitle = eJobTitle.Text;
        //    Data.employee.picLocation = Data.GetImagePath();
        //}

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
    }
}
