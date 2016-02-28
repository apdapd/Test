using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.MyForms
{
    public interface IDepart
    {

        void SetMdiParent(Form form);
        int Volume { get; set; }

        event EventHandler ButtonStartClick;
        event EventHandler ButtonStopClick;
        event EventHandler ButtonContinueClick;
        event EventHandler ButtonAbortClick;
        event EventHandler VolChange;
        void DepartProcessChanged(int progress);

        void SetLblNumber(int number);

        void DepartWorkCompleted(bool obj);
    }
    public partial class Depart : Form, IDepart
    {
        public Depart()
        {
            InitializeComponent();

            buttonStart.Click += ButtonStartOnClick;
            buttonStop.Click += ButtonStopOnClick;
            buttonContinue.Click += ButtonContinueOnClick;
            buttonAbort.Click += ButtonAbortOnClick;

        }

        #region IDepart

        public void SetMdiParent(Form form)
        {
            MdiParent = form;
        }

        public int Volume
        {
            get { return (int)Math.Round(numVol.Value * 1000); }
            set { numVol.Value = value; }
        }

        public event EventHandler ButtonStartClick;
        public event EventHandler ButtonStopClick;
        public event EventHandler ButtonContinueClick;
        public event EventHandler ButtonAbortClick;
        
        public event EventHandler VolChange;

        public void DepartWorkCompleted(bool obj)
        {

            labelTime.Text = obj ? "Останов" : "Окончание";
            buttonStart.Visible = true;
            buttonStop.Visible = false;
            buttonContinue.Visible = false;
            buttonAbort.Visible = false;
        }

        void IDepart.DepartProcessChanged(int progress)
        {
            DepartProcessChanged(progress);
            labelVol.Text = progress.ToString();
        }

        public void SetLblNumber(int number)
        {
            labelVol.Text = number.ToString();
        }

        #endregion

        private void ButtonStartOnClick(object sender, EventArgs eventArgs)
        {
            if (ButtonStartClick != null)
                ButtonStartClick(this, EventArgs.Empty);
        }
        private void ButtonStopOnClick(object sender, EventArgs eventArgs)
        {
            if (ButtonStopClick != null)
                ButtonStopClick(this, EventArgs.Empty);
        }

        private void ButtonContinueOnClick(object sender, EventArgs eventArgs)
        {
            if (ButtonContinueClick != null)
                ButtonContinueClick(this, EventArgs.Empty);
        }
        private void ButtonAbortOnClick(object sender, EventArgs eventArgs)
        {
            if (ButtonAbortClick != null)
                ButtonAbortClick(this, EventArgs.Empty);
        }

        private void DepartProcessChanged(int progress)
        {
            progressBarVol.Value = progress;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            progressBarVol.Value = 0;
            progressBarVol.Minimum = 0;
            progressBarVol.Maximum = Volume;
            buttonStart.Visible = false;
            buttonStop.Visible = true;
            buttonContinue.Visible = false;
            buttonAbort.Visible = false;

            //Volume = (int)Math.Round(numVol.Value * 1000);
        }

        private void Depart_Load(object sender, EventArgs e)
        {
            buttonStart.Visible = true;
            buttonStop.Visible = false;
            buttonContinue.Visible = false;
            buttonAbort.Visible = false;
            //ShowTime(true);
        }

        private void ShowTime(bool b)
        {
            //Action action = () =>
            //{
            //    while (true)
            //    {
            //        Invoke((Action)(() => labelTime.Text = DateTime.Now.ToLongTimeString()));
            //    }
            //};
            //Task task = new Task(action);
            //task.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            buttonStop.Visible = false;
            buttonContinue.Visible = true;
            buttonAbort.Visible = true;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            buttonStop.Visible = true;
            buttonContinue.Visible = false;
            buttonAbort.Visible = false;
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = true;
            buttonStop.Visible = false;
            buttonContinue.Visible = false;
            buttonAbort.Visible = false;
        }
    }
}
