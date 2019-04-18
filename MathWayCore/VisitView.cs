using System;
using System.Data;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class VisitView : Form
    {

        private string id = "";
        private string first = "";
        private string last = "";
        private DataTable visits;

      
        public VisitView()
        {
            InitializeComponent();

            Setup();
            FillList();
           
        }


        public VisitView(string id, string first, string last)
        {
            InitializeComponent();
          
            this.lblID.Text = id.ToUpper();
            this.lblFName.Text = first.ToUpper();
            this.lblLName.Text = last.ToUpper();

            this.id = id.ToUpper();
            this.first = first.ToUpper();
            this.last = last.ToUpper();

            Setup();
            FillList();
         

        }

        private void FillList()
        {
            visits = MathLib.DConnect.Connection.GetVisitTable(this.id);
            if(visits.Rows.Count > 0)
            {
                lsBoxVisits.DataSource = visits;
                lsBoxVisits.Columns["StudentID"].Visible = false;
                lsBoxVisits.Columns["Status"].Visible = false;
                lsBoxVisits.Columns["Semester"].Visible = false;
                lsBoxVisits.Columns["ClassType"].Visible = false;
                lsBoxVisits.Columns["ClassNum"].Visible = false;
                lsBoxVisits.Columns["id"].Visible = false;
              
            }
           
          
        }

       private void Setup()
        {
            
           
            lsBoxVisits.AllowUserToAddRows = false;
            lsBoxVisits.AllowUserToDeleteRows = true;
            lsBoxVisits.AllowUserToOrderColumns = false;
            lsBoxVisits.AllowUserToResizeColumns = true;
            lsBoxVisits.EditMode = DataGridViewEditMode.EditProgrammatically;
            lsBoxVisits.MultiSelect = false;
            lsBoxVisits.ScrollBars = ScrollBars.Both;
            lsBoxVisits.ShowCellErrors = true;
            lsBoxVisits.ShowRowErrors = true;
            lsBoxVisits.SelectionMode = DataGridViewSelectionMode.CellSelect;
            
           
        }

        private void UpdateVisits()
        {
            
            MathLib.DConnect.Connection.MergeVisits(visits);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Just close and make no changes!
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // End the current edit, create an update thread and close out
            UpdateVisits();
            MathLib.DConnect.Connection.UpdateDirectly();
            this.DialogResult = DialogResult.OK;
        }

      
        private void lsBoxVisits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e != null && sender != null && lsBoxVisits.Rows.Count > 0)
            {
                lsBoxVisits.CurrentCell = lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex];
                lsBoxVisits.BeginEdit(true);
                if (e.ColumnIndex == lsBoxVisits.Columns["TimeStampIn"].Index)
                {
                    string timeStamp = lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    EditTime form = new EditTime(this.id, this.first, this.last, timeStamp);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (MathLib.DConnect.Connection.GetSetting("ShowFormPopUp"))
                            MessageBox.Show("Update Complete", "Time Stamp Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        if (form.StampNewVal < DateTime.ParseExact((string)lsBoxVisits.Rows[e.RowIndex].Cells[lsBoxVisits.Columns["TimeStampOut"].Index].Value, "MM/dd/yyyy HH:mm:ss", null))
                        {
                            lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.StampNewVal.ToString("MM/dd/yyyy HH:mm:ss");
                            lsBoxVisits.RefreshEdit();
                        }
                        else
                        {
                            if (MathLib.DConnect.Connection.GetSetting("ShowFormPopUp"))
                                MessageBox.Show("Time In Cannot Be Greater Than Time Out", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (e.ColumnIndex == lsBoxVisits.Columns["TimeStampOut"].Index)
                {
                    string timeStamp = lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    EditTime form = new EditTime(this.id, this.first, this.last, timeStamp);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.StampNewVal > DateTime.ParseExact((string)lsBoxVisits.Rows[e.RowIndex].Cells[lsBoxVisits.Columns["TimeStampIn"].Index].Value, "MM/dd/yyyy HH:mm:ss", null))
                        {
                            lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.StampNewVal.ToString("MM/dd/yyyy HH:mm:ss");
                            lsBoxVisits.RefreshEdit();
                        }
                        else
                        {
                            if (MathLib.DConnect.Connection.GetSetting("ShowFormPopUp"))
                                MessageBox.Show("Time Out Cannot Be Greater Than Time In", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   

                }
                else if (e.ColumnIndex == lsBoxVisits.Columns["Tutors"].Index)
                {
                    string visit_id = lsBoxVisits.Rows[e.RowIndex].Cells[0].Value.ToString();
                    TutorData data = new TutorData(this.id, this.first, this.last, visit_id);
                    if (data.ShowDialog() == DialogResult.OK)
                    {
                        if (MathLib.DConnect.Connection.GetSetting("ShowFormPopUp"))
                            MessageBox.Show("Update Complete", "Tutor Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data.Tutors;
                        lsBoxVisits.RefreshEdit();
                    }
                    else
                    {
                        if (MathLib.DConnect.Connection.GetSetting("ShowFormPopUp"))
                            MessageBox.Show("Did Not Update", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Added a comments
                else if (e.ColumnIndex == lsBoxVisits.Columns["Comments"].Index)
                {
                    
                    string visit_id = lsBoxVisits.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string old = MathLib.DConnect.Connection.getCommentByNum(this.id, visit_id);
                    string input = Microsoft.VisualBasic.Interaction.InputBox("What Did The Tutor Do Today?", "Comments" , old, FormMain.SCREEN_WIDTH / 2, FormMain.SCREEN_HEIGHT / 2);

                    lsBoxVisits.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = input;
                    lsBoxVisits.RefreshEdit();
                }
                else
                {
                    if (MathLib.DConnect.Connection.GetSetting("ShowFormPopUp"))
                        MessageBox.Show("Did Not Select A Cell", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lsBoxVisits.EndEdit();
            }    
        } 
    }
}
