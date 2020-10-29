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
    public partial class UpperPanel : UserControl
    {
        public UpperPanel()
        {
            InitializeComponent();
        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            UIController.Navigate(UIController.Controls.Exit);
        }
    }
}
