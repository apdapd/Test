using System;
using System.Threading;

namespace ClassLibraryBL
{
    public enum DepState
    {
        DepWait,
        DepStart,
        DepWork,
        DepPause,
        DepAbort
    }

    public interface IDepLogic
    {
        event Action<int> DepChanged;
        event Action<bool> WorkCompleted;
        void Work();
        void Cancell();
        void Begin(int vol);
        void Abort(int vol);
        void Continue(int vol);
    }

    
    public class DepLogic :  IDepLogic
    {
        private readonly object _lockobject = new object();
        private readonly SynchronizationContext _context;
        private int _currVol;
        private readonly bool _bContinue;
        private bool _cancelled;

        public event Action<int> DepChanged;
        public event Action<bool> WorkCompleted;

        private int _currentVol;
        private int _depNumber;

        private int _volume;
        private DepState _state;

        private DepLogic(int currentVol, int volume, int depNumber)
        {
            _currentVol = currentVol;
            _volume = volume;
            _depNumber = depNumber;
        }

        public DepLogic(SynchronizationContext context) : this(0, 0, 0)
        {
            _state = DepState.DepWait;
            _context = context;
            _bContinue = true;
        }

        public void Begin(int vol)
        {
            lock (_lockobject)
            {
                _volume = vol;
                _currVol = 0;
                _state = DepState.DepStart;
            }
        }

        public void Cancell()
        {
            lock (_lockobject)
            {
                _cancelled = true;
                _state = DepState.DepPause;
            }
        }
        public void Abort(int currV)
        {
            DoEnd(_currVol);
            _state = DepState.DepWait;

        }
        public void Continue(int currV)
        {
            _state = DepState.DepWork;
        }

        public void Work()
        {
            while (_bContinue)
            {
                switch (_state)
                {
                    case DepState.DepStart:
                        if(CanStart())
                          _state = DepState.DepWork;
                        break;
                    case DepState.DepAbort:
                        _state = DepState.DepWait;
                        break;
                    
                    case DepState.DepWork:
                        GetCurrVol();
                        _context.Send(OnDepChanged, _currVol);
                        if (_currVol >= _volume)
                        {
                            DoEnd(_currVol);
                            _state = DepState.DepWait;
                        }
                        //_context.Send(OnWorkCompleted, _cancelled);
                        break;
                    
                    case DepState.DepPause:
            //            _context.Send(OnWorkCompleted, _cancelled);
                        break;
                }
            }
        }

        private void DoEnd(int currV)
        {
            _cancelled = (currV < _volume);
            _context.Send(OnWorkCompleted, _cancelled);
        }

        private bool CanStart()
        {
            return true;
        }

        private void GetCurrVol()
        {
            _currVol += 10;
            Thread.Sleep(5);
        }

        private void OnDepChanged(object i)
        {
            if (DepChanged != null)
                DepChanged((int) i);
        }

        private void OnWorkCompleted(object c)
        {
            if (WorkCompleted != null)
                WorkCompleted((bool) c);
        }
    }
}
