using System;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class EditTime : Form
    {
        private string id = "";
        private string first = "";
        private string last = "";
        private DateTime date = DateTime.Now;
        private DateTime time = DateTime.Now;
        private DateTime stampNewVal = DateTime.Now;
        private string stampToEdit = "";
        public EditTime()
        {
            InitializeComponent();
        }

        public DateTime StampNewVal
        {
            get => stampNewVal;
            set => stampNewVal = value;
        }



        public EditTime(string id, string first, string last, string stampToEd)
        {
            InitializeComponent();
            this.lblID.Text = id.ToUpper();
            this.lblFName.Text = first.ToUpper();
            this.lblLName.Text = last.ToUpper();

            this.id = id.ToUpper();
            this.first = first.ToUpper();
            this.last = last.ToUpper();

            this.stampToEdit = stampToEd;
            this.txtOldTime.Text = stampToEdit;
            this.date = DateTime.ParseExact(stampToEdit.Split(' ')[0], "MM/dd/yyyy", null);
            this.time = DateTime.ParseExact(stampToEdit.Split(' ')[1], "HH:mm:ss", null);
            this.timePicker.Value = time;
            this.datePicker.Value = date;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {

            this.StampNewVal = new DateTime(this.date.Year, this.date.Month, this.date.Day, this.time.Hour, this.time.Minute, this.time.Second);
            this.DialogResult = DialogResult.OK;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
            this.time = timePicker.Value;
            this.date = datePicker.Value;
            this.txtNewTime.Text = new DateTime(this.date.Year, this.date.Month, this.date.Day, this.time.Hour, this.time.Minute, this.time.Second).ToString("MM/dd/yyyy HH:mm:ss");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.time = timePicker.Value;
            this.date = datePicker.Value;
            this.txtNewTime.Text = new DateTime(this.date.Year, this.date.Month, this.date.Day, this.time.Hour, this.time.Minute, this.time.Second).ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}
