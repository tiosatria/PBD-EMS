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
using Telerik.WinControls;

namespace EmployeeManagementSystem.Interface
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            ThisSettings.SetTheme(ThisSettings.Theme.Dark, this);
            
        }

        public void InitializeObject()
        {
            InitializeComponent();
        }

    }
}
