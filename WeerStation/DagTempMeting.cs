using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WeerStation
{
    class DagTempMeting
    {
        private DateTime _date;
        private float temp;

        public DateTime _Date { get { return _date; } set { _date = value; } }
        public float Temp { get { return temp; } set { temp = value; } }

        public int WeekNr { get { return WeekOfYear(_date); } }

        public DayOfWeek Dag { get { return _date.DayOfWeek;  } }

        //default constructor
        public DagTempMeting()
        { }
        
        public DagTempMeting(DateTime date_)
        {
            this._date = date_;
        }
        public DagTempMeting(DateTime date_, float _temp)
        {
            this._date = date_;
            this.temp = _temp;
        }

        private int WeekOfYear(DateTime _dateOfYear)
        {
            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("nl-NL");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            //return the week number
            return myCal.GetWeekOfYear(_dateOfYear, myCWR, myFirstDOW);
        }


    }
}
