using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio258
{
    
    /// <summary>
    /// Metingen van een weerstation per week
    /// </summary>
    public class Measurement
    {
        #region MyRegion
        private DateTime firstDateOfWeek;
        private string weatherStation;
        private string weatherPerson;
        private double[] temperatures = new double[7];
        #endregion

        #region Properties
        public DateTime FirstDateOfWeek { get => firstDateOfWeek;  set => firstDateOfWeek = value; }
        public string WeatherStation { get => weatherStation; set => weatherStation = value; }
        public string WeatherPerson { get => weatherPerson; set => weatherPerson = value; }
        public double[] Temperatures { get => temperatures; }

        /// <summary>
        /// Gets the hottest date.
        /// </summary>
        /// <value>
        /// The hottest date.
        /// </value>
        public DateTime HottestDate
        {
            get
            {
                double max = Max;
                DateTime hottestDate = FirstDateOfWeek;
                for(int i = 0; i < temperatures.Length; i++)
                {
                    if (temperatures[i] == max) return FirstDateOfWeek.AddDays(i);
                }
                return hottestDate;
            }
        }

        /// <summary>
        /// Gets the hottest date.
        /// </summary>
        /// <value>
        /// The hottest date.
        /// </value>
        public DateTime ColdestDate
        {
            get
            {
                double min = Min;
                DateTime coldestDate = FirstDateOfWeek;
                for (int i = 0; i < temperatures.Length; i++)
                {
                    if (temperatures[i] == min) return FirstDateOfWeek.AddDays(i);
                }
                return coldestDate;
            }
        }
        /// <summary>
        /// Gets the maximum temperature.
        /// </summary>
        /// <value>
        /// The maximum temperature.
        /// </value>
        public double Max
        {
            get
            {
                double max = Temperatures[0];
                for (int i = 1; i < Temperatures.Length; i++)
                {
                    if (Temperatures[i] > max)
                    {
                        // Vervang de waarde in max door de waarde in de array op positie i
                        max = Temperatures[i];
                    }
                }
                return max;
            }

        }

        /// <summary>
        /// Gets the minimum temperature.
        /// </summary>
        /// <value>
        /// The minimum temperature.
        /// </value>
        public double Min
        {
            get
            {
                double min = Temperatures[0];
                for (int i = 1; i < Temperatures.Length; i++)
                {
                    if (Temperatures[i] < min)
                    {
                        // Vervang de waarde in min door de waarde in de array op positie i
                        min = Temperatures[i];
                        // Sla de datum van de koudste dag op in veld kpudsteDag
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Gets the average temperature.
        /// </summary>
        /// <value>
        /// The average temperature.
        /// </value>
        public double AverageTemperature
        {
            get { return temperatures.Average(); }
        }

        /// <summary>
        /// Calculates the standard deviation.
        /// </summary>
        /// <value>
        /// The standard deviation.
        /// </value>
        public double StandardDeviationOfTemperatures
        {
            get
            {
                double avg = AverageTemperature;
                double dev = 0;
                foreach(double t in temperatures)
                {
                    var diff = t - avg;
                    dev += (diff * diff);
                }
                return Math.Sqrt(dev / temperatures.Length); 
            }
        }

        #endregion

        #region Constructors

        #endregion
        #region Methods

        /// <summary>
        /// Adds the temperature.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <param name="temperature">The temporature.</param>
        public void AddTemperature(DayOfWeek day , double temperature)
        {
            switch(day)
            {
                case DayOfWeek.Monday:
                    Temperatures[0] = temperature;
                    break;
                case DayOfWeek.Tuesday:
                    Temperatures[1] = temperature;
                    break;
                case DayOfWeek.Wednesday:
                    Temperatures[2] = temperature;
                    break;
                case DayOfWeek.Thursday:
                    Temperatures[3] = temperature;
                    break;
                case DayOfWeek.Friday:
                    Temperatures[4] = temperature;
                    break;
                case DayOfWeek.Saturday:
                    Temperatures[5] = temperature;
                    break;
                case DayOfWeek.Sunday:
                    Temperatures[6] = temperature;
                    break;
            }
            
        } 
        #endregion
    }
}
