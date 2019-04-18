using System;
using System.Windows.Forms;
using System.IO;
using MathLib;

namespace MathLogCenter
{
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
            chkPopUp.Checked = DConnect.Connection.GetSetting("ShowFormPopUp");
        }

        #region Button
        private void btnReport_Click(object sender, EventArgs e)
        {
            string p = "BugReport_" + new Random(DateTime.Now.Second).Next() + ".data";

            File.WriteAllText(p, this.txtBugBox.Text);
            this.txtBugBox.Text = string.Empty;

        }

        private void chkPopUp_CheckedChanged(object sender, EventArgs e)
        {
            DConnect.Connection.SetSetting("ShowFormPopUp", chkPopUp.Checked);
        }
        #endregion

        #region Helper Methods


        #endregion


    }
}
