﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem.Interface
{
    public partial class DeptUC : UserControl
    {
        private bool isLoaded = false;  
        public DeptUC()
        {
        
        }
        public void InitObject()
        {
            if (!isLoaded)
            {
                InitializeComponent();
                isLoaded = true;
            }
        }

    }
}