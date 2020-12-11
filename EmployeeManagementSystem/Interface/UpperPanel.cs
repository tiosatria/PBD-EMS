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
        private bool isloaded = false;
        public UpperPanel()
        {

        }
        public void InitObject()
        {
            if (!isloaded)
            {
                InitializeComponent();
                isloaded = true;
            }
        }
        private void PicExit_Click(object sender, EventArgs e)
        {
            UIController.AnimateHideControl(PicExit, Guna.UI2.AnimatorNS.AnimationType.Transparent);
        }

        private void PicExit_MouseEnter(object sender, EventArgs e)
        {
            UIController.EnlargeImage(PicExit, 3);
        }

        private void PicExit_MouseLeave(object sender, EventArgs e)
        {
            UIController.ReduceImageSize(PicExit, 3);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            UIController.EnlargeImage(picMoreMenu, 3);

        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            UIController.ReduceImageSize(picMoreMenu, 3);

        }
        private void picMoreMenu_MouseEnter(object sender, EventArgs e)
        {
            UIController.EnlargeImage(picMoreMenu, 3);
        }
        private void picMoreMenu_MouseLeave(object sender, EventArgs e)
        {
            UIController.ReduceImageSize(picMoreMenu, 3);
        }
    }
}
