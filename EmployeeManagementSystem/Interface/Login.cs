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

namespace EmployeeManagementSystem.Interface
{
    public partial class Login : UserControl
    {
        public Login()
        {
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Query.Auth(txtUsername.Text, txtPassword.Text);
        }

        public void InitializeObject()
        {
            InitializeComponent();
        }

    }
}
