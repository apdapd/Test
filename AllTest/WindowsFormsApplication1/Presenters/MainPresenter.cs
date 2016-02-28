using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApplication1.MyForms;
using ClassLibraryBL;
using Domain;

namespace WindowsFormsApplication1.Presenters
{
    public class MainPresenter
    {
        SynchronizationContext _context = SynchronizationContext.Current;

        private IMainForm _mainForm;

        public MainPresenter(IMainForm mainForm)
        {
            _mainForm = mainForm;

            _mainForm.ButtonStartClick += Start_Click;
            _mainForm.ButtonShowClick += Show_Click;
            
        }
        
        public async void  Show_Click(object sender, EventArgs e)
        {
            AllWork allW = new AllWork();
            var lStr = await Task<List<string>>.Factory.StartNew(() => allW.DayShow(_mainForm.NumEnd, _mainForm.NumRep));
            ShowForm showForm = new ShowForm();
            showForm.GetText(lStr);
            showForm.Show();

            
            
        }

        public void Start_Click(object sender, EventArgs e)
        {
            ShowDepart();
            //Task.Factory.StartNew(ShowDepart);
            //List<Task> tasks = new List<Task>();

            //for (int i = 0; i < 1; i++)
            //{
            //    tasks.Add(Task.Factory.StartNew(ShowDepart));
            //}

            //Task.WaitAll(tasks.ToArray());
        }

        public void ShowDepart()
        {
            var departForm = new Depart();
            departForm.SetMdiParent(_mainForm.GetForm());
            DepLogic depLogic = new DepLogic(_context);
            var departPresenter = new DepartPresenter(departForm, depLogic);
//            Task.Factory.StartNew(() => { depLogic.Work(); });

            Thread myThread = new Thread(new ThreadStart(depLogic.Work));
            myThread.Name = "Поток ";
            myThread.IsBackground = true;
            myThread.Start();

            //departForm.MdiParent = this;
            departForm.Show();
        }
    }
}
