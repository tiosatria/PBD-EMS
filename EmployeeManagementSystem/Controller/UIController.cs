using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using EmployeeManagementSystem.Interface;
using System.Diagnostics.Eventing.Reader;
using Telerik.WinControls.VirtualKeyboard;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using Telerik.WinControls.UI;
using EmployeeManagementSystem.Properties;

namespace EmployeeManagementSystem.Controller
{
    public class UIController
    {
        #region Properties
        #region InterfaceComponent
        private static Login login = new Login();
        private static UpperPanel upperDefault = new UpperPanel();
        private static LeftPanel leftPanel = new LeftPanel();
        private static Dashboard dashboard = new Dashboard();
        private static DialogYesNo dialog = new DialogYesNo();
        #endregion

        public enum Controls { LeftPanel, LeftPanelExpand, Login, UpperPanel, Dashboard, Exit }
        private static Controls _controls;
        public enum DockType { top, fill, left }
        private static DockType _dock;
        public enum UpperPanelEnum { def }
        private static UpperPanelEnum _up;
        static Form mainform = Application.OpenForms[0];
        private static UserControl ctrl;
        #endregion

        public UIController()
        {

        }
        #region Function
        //navigate
        public static void Navigate(Controls ctr)
        {
            UserControl control = null;
            _controls = ctr;
            switch (ctr)
            {
                case Controls.LeftPanel:
                    control = AddControl(leftPanel);
                    mainform.Controls.Add(control);
                    SetControl(control, DockType.left);
                    leftPanel.InitializeObject();
                    break;
                case Controls.LeftPanelExpand:

                    break;
                case Controls.Login:
                    control = AddControl(login);
                    mainform.Controls.Add(control);
                    SetControl(control, DockType.fill);
                    login.InitializeObject();
                    break;
                case Controls.UpperPanel:
                    control = AddControl(upperDefault);
                    mainform.Controls.Add(control);
                    SetControl(control, DockType.top);
                    break;
                case Controls.Dashboard:
                    control = AddControl(dashboard);
                    mainform.Controls.Add(control);
                    SetControl(control, DockType.fill);
                    dashboard.InitializeObject();
                    break;
                case Controls.Exit:
                    control = AddControl(dialog);
                    mainform.Controls.Add(control);
                    SetControl(control, DockType.fill);
                    Confirmation.Title = "Exit Application";
                    Confirmation.Subtitle = "Are you sure you want to quit application?\nAny unsaved data will be lost!";
                    Confirmation.yesDisplay = "Yes, let me go";
                    Confirmation.noDisplay = "No, let me stay";
                    Confirmation.img = Resources.icons8_question_mark_480px;
                    dialog.InitializeObject();
                    dialog.BringToFront();
                    break;
            }
        }

        #endregion


        private static void SetControl(UserControl ctrl, DockType type)
        {
            _dock = type;
            switch (type)
            {
                case DockType.top:
                    if (ctrl == null)
                    {
                        mainform.Controls.Remove(ctrl);
                        MessageBox.Show("lah");
                    }
                    else
                    {
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].Dock = DockStyle.Top;
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].BringToFront();
                    }
                    break;
                case DockType.fill:
                    if (ctrl == null)
                    {
                        mainform.Controls.Remove(ctrl);
                    }
                    else
                    {
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].Dock = DockStyle.Fill;
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].BringToFront();
                    }
                    break;
                default:
                    if (ctrl == null)
                    {
                        mainform.Controls.Remove(ctrl);
                    }
                    else
                    {
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].Dock = DockStyle.Fill;
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].BringToFront();
                    }
                    break;
                case DockType.left:
                    if (ctrl == null)
                    {
                        mainform.Controls.Remove(ctrl);
                    }
                    else
                    {
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].Dock = DockStyle.Left;
                        mainform.Controls[mainform.Controls.IndexOf(ctrl)].BringToFront();
                    }
                    break;
            }

        }

        private static UserControl AddControl(UserControl control)
        {
            if (mainform.Controls.Contains(control))
            {
                return null;
            }
            else
            {
                switch (_controls)
                {
                    case Controls.LeftPanel:
                        control = leftPanel;
                        return control;
                        break;
                    case Controls.LeftPanelExpand:
                        control = new LeftPanelExpand();
                        return control;
                        break;
                    case Controls.Login:
                        control =  login;
                        return control;
                        break;
                    case Controls.UpperPanel:
                        control = upperDefault;
                        return control;
                        break;
                    case Controls.Dashboard:
                        control = dashboard;
                        return control;
                        break;
                    case Controls.Exit:
                        control = dialog;
                        return control;
                        break;
                    default:
                        control = null;
                        return control;
                        break;
                }
            }
        }




    }
}
