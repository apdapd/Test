using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;

namespace WindowsFormsApplication1
{

    public interface IMainForm
    {
        Form GetForm();
        int NumEnd { get; set; }
        int NumRep { get; set; }
        event EventHandler ButtonStartClick;
        event EventHandler ButtonShowClick;
    }
    public partial class MainForm : Form, IMainForm
    {
        private List<Panel> Panels { get; set; }


        public Form GetForm()
        {
            return this;
        }

        public event EventHandler ButtonStartClick;
        public event EventHandler ButtonShowClick;

        public MainForm()
        {
            InitializeComponent();
            MainDefs.ReadConfig();

            //var departForm = new Depart();
            //var depLogic = new DepLogic();
            //var departPresenter = new DepartPresenter(departForm, depLogic);
            ////departForm.MdiParent = this;
            //departForm.Show();

        }
        public int NumEnd
        {
            get { return (int)(numericUpDownNum.Value); }
            set { numericUpDownNum.Value = value; }
        }
        public int NumRep
        {
            get { return (int)(numericUpDownRep.Value); }
            set { numericUpDownRep.Value = value; }
        }
        
                
        private void button1_Click(object sender, EventArgs e)
        {
            if (ButtonStartClick != null)
                ButtonStartClick(this, EventArgs.Empty);           
        }

        private void InitializePanel()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ButtonShowClick != null)
                ButtonShowClick(this, EventArgs.Empty);
        }

    }
}
