namespace study_prog2_practis_3
{
    class Time
    {
        private int _seconds = 0;
        private int _minutes = 0;
        private int _hours = 0;
        private int _days = 0;

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > 60)
                {
                    Minutes += value / 60;
                    _seconds = value % 60;
                }
                else
                {
                    _seconds = value;
                }
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > 60)
                {
                    Hours += value / 60;
                    _minutes = value % 60;
                }
                else
                {
                    _minutes = value;
                }
            }
        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > 24)
                {
                    Days += value / 24;
                    _hours = value % 24;
                }
                else
                {
                    _hours = value;
                }
            }
        }

        public int Days
        {
            get { return _days; }
            set
            {
                if (value < 0)
                    _days = 0;
                else
                    _days = value;
            }
        }

        public Time(int seconds = 0, int minutes = 0, int hours = 0, int days = 0)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string ToString()
        {
            return $"Zeit: {_days} Tage, {_hours} Stunden, {_minutes} Minuten und {_seconds} Sekunden!";
        }

        public static Time operator -(Time t1, Time t2)
        {
            return new Time(t1.Seconds - t2.Seconds, t1.Minutes - t2.Minutes, t1.Hours - t2.Hours, t1.Days - t2.Days);
        }

        public static Time operator +(Time t1, Time t2)
        {
            return new Time(t1.Seconds + t2.Seconds, t1.Minutes + t2.Minutes, t1.Hours + t2.Hours, t1.Days + t2.Days);
        }

        public static Time operator ++(Time t)
        {
            return new Time(++t.Seconds, t.Minutes, t.Hours, t.Days);
        }

        public static Time operator --(Time t)
        {
            return new Time(--t.Seconds, t.Minutes, t.Hours, t.Days);
        }
    }
}