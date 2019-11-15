using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeerStation
{
    class WeekMetingOverzicht
    {
        private List<DagTempMeting> metingen = new List<DagTempMeting>();
        private int weeknr;
        private int jaar;

        public float Avgtemp
        {
            get
            {
                float _avgtemp = 0;
                foreach (DagTempMeting meting in metingen)
                {
                    _avgtemp += meting.Temp;
                }
                return _avgtemp / metingen.Count();
            }
        }
        public float MaxTemp
        {
            get
            {
                List<float> _temp = new List<float>();
                foreach (DagTempMeting meting in metingen)
                {
                    _temp.Add(meting.Temp);
                }
                _temp.Sort();
                return _temp[_temp.Count - 1];
            }
        }

        public float MinTemp
        {
            get
            {
                List<float> _temp = new List<float>();
                foreach (DagTempMeting meting in metingen)
                {
                    _temp.Add(meting.Temp);
                }
                _temp.Sort();
                return _temp[0];
            }
        }

        public List<DagTempMeting> Metingen { get { return metingen; } }

        public int WeekNr { get { return weeknr; } }

        public int Jaar { get { return jaar; } }

        public WeekMetingOverzicht()
        {

        }

        public WeekMetingOverzicht( int _weeknr)
        {
            this.weeknr = _weeknr;
        }

        public void Add(DagTempMeting _meting)
        {
           this.weeknr = _meting.WeekNr;
            this.jaar = _meting._Date.Year;
           this.metingen.Add(_meting);
        }

    }
}
