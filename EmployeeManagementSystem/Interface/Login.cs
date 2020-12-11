using System;
using System.Windows.Forms;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Interface
{
    public partial class Login : UserControl
    {
        private bool isloaded = false;
        public Login()
        {


        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (User.Auth(txtUsername.Text, txtPassword.Text))
            {
                Notification.Alert($"Hello! {User.Employee.FullName}! You're logged in!", PopUp.AlertType.Info);
                UIController.Navigate(UIController.Controls.Dashboard); 
            }
            else
            {
                Notification.Alert("We couldn't recognise you, mind to reintroduce?", PopUp.AlertType.Warning);
            }
        }

        public void InitializeObject()
        {
            if (!isloaded)
            {
                InitializeComponent();
                isloaded = true;
            }
        }

    }
}
