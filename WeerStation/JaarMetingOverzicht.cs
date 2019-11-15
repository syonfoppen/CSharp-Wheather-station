using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerStation
{
    class JaarMetingOverzicht
    {
        private List<WeekMetingOverzicht> metingen = new List<WeekMetingOverzicht>();
        private int jaar;

        public float Avgtemp
        {
            get
            {
                float _avgtemp = 0;
                foreach (WeekMetingOverzicht meting in metingen)
                {
                    if (meting.WeekNr != 0)
                    {
                        _avgtemp += meting.Avgtemp;
                    }
                    
                }
                return _avgtemp / metingen.Count();
            }
        }
        public float MaxTemp
        {
            get
            {
                List<float> _temp = new List<float>();
                foreach (WeekMetingOverzicht meting in metingen)
                {
                    if (meting.WeekNr != 0)
                    {
                        _temp.Add(meting.MaxTemp);
                    }
                    
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
                foreach (WeekMetingOverzicht meting in metingen)
                {
                    if (meting.WeekNr != 0)
                    {
                        _temp.Add(meting.MinTemp);
                    }
                }
                _temp.Sort();
                return _temp[0];
            }
        }

        public int Jaar { get { return jaar; } }

        public List<WeekMetingOverzicht> Metingen { get { return metingen; } }

        public JaarMetingOverzicht()
        {

        }

        public JaarMetingOverzicht(int _jaar)
        {
            this.jaar = _jaar;
        }

        public void Add(WeekMetingOverzicht _meting)
        {
            this.jaar = _meting.Jaar;
            this.metingen.Add(_meting);
        }

    }
}
