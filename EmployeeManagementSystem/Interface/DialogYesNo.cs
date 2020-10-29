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
    public partial class DialogYesNo : UserControl
    {
        private string _title;
            
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _subtitle;

        public string Subtitle
        {
            get { return _subtitle; }
            set { _subtitle = value; }
        }

        private Image _imagedialog;

        public Image ImageDialog
        {
            get { return _imagedialog; }
            set { _imagedialog = value; }
        }


        public DialogYesNo()
        {

        }

        public void InitializeObject()
        {
            InitializeComponent();

            lblTitle.Text = Confirmation.Title;
            lblSubtitle.Text = Confirmation.Subtitle;
            picDialog.Image = Confirmation.img;
            btnYes.Text = Confirmation.yesDisplay;
            btnNo.Text = Confirmation.noDisplay;

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Confirmation.Yes(Confirmation.Type.Exit);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }


    }
}
