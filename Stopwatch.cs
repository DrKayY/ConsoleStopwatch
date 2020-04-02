using System;

namespace exercise_stopwatch
{
    public class Stopwatch
    {
        private DateTime _start, _stop, _pause, _resume;
        private TimeSpan _timeOff, _timeOn;
       
        private TimeSpan Duration
        {
            get {
                var duration = ((_stop - _start) - _timeOff);

                return duration;
            }
        }

        public void Start(char s)
        {
            if (s == 'C')
                throw new InvalidOperationException("You can't stop the watch before even starting it");
            if (s != 'S')
                throw new InvalidOperationException("Invalid input");
            
            _start = DateTime.Now;
        }

        public TimeSpan StopOrPause(char c)
        {
            if (c == 'S')
                throw new InvalidOperationException("Watch already running");
            if (c != 'C' && c != 'P')
                throw new InvalidOperationException("Invalid input");
            if (c == 'P')
            {
                this.DurationOnPause();
                _pause = DateTime.Now;

                return _timeOn;
            }
            if (c == 'C')
                _stop = DateTime.Now;

            return this.Duration;
        }

        private void DurationOnPause()
        { 
            if (_timeOn == new TimeSpan())
                _timeOn = DateTime.Now - _start;
            else
            _timeOn += (DateTime.Now - _resume);
        }
        
        public void Resume(char p)
        {
            // if (p != 'P')
            //     throw new InvalidOperationException("Invalid input, press p to resume watch");
            
            _resume = DateTime.Now;
            this.TimeOff(_pause, _resume);
        }

        private void TimeOff(DateTime start, DateTime stop)
        { 
            _timeOff += (stop - start);
        }

        public TimeSpan CancelOnPause()
        {
            return _timeOn;
        }
    }
}
