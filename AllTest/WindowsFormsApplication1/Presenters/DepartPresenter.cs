using System;
using WindowsFormsApplication1.MyForms;
using ClassLibraryBL;

namespace WindowsFormsApplication1.Presenters
{
    public class DepartPresenter
    {
        private readonly IDepart _depart;
        private readonly IDepLogic _depLogic;



        public DepartPresenter(IDepart depart, IDepLogic depLogic)
        {
            _depart = depart;
            _depLogic = depLogic;

            _depart.ButtonStartClick += _depart_ButtonStartClick;
            _depart.ButtonStopClick += _depart_ButtonStopClick;
            _depart.ButtonContinueClick += _depart_ButtonContinueClick;
            _depart.ButtonAbortClick += _depart_ButtonAbortClick;
            _depLogic.DepChanged += _depart.DepartProcessChanged;
            _depLogic.WorkCompleted += _depart.DepartWorkCompleted;
        }

        private void _depart_ButtonAbortClick(object sender, EventArgs e)
        {
            _depLogic.Abort(_depart.Volume);
        }

        private void _depart_ButtonContinueClick(object sender, EventArgs e)
        {
            _depLogic.Continue(_depart.Volume);
        }

        void _depart_ButtonStartClick(object sender, EventArgs e)
        {
            _depLogic.Begin(_depart.Volume);
        }

        void _depart_ButtonStopClick(object sender, EventArgs e)
        {
            _depLogic.Cancell();
        }

    }
}
