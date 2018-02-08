using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio258
{
    class Program
    {
        static void Main(string[] args)
        {
            // Maak nieuw object aan voor een meting
            Measurement m = new Measurement();

            // Get name of weatherstation
            Console.Write("Geef de datum van de eerste dag van de week (maandag) als jjjj-mm-dd: ") ;
            string maandag = Console.ReadLine();
            m.FirstDateOfWeek = DateTime.Parse(maandag);

            // Get name of weatherstation
            Console.Write("Wat is de naam van het weerstation? ");
            m.WeatherStation = Console.ReadLine();

            // Get name of person who has done the observation
            Console.Write("Wat is de naam van de weermens? ");
            m.WeatherStation = Console.ReadLine();

            Console.WriteLine("Geef de temperaturen van de week als 00.00");
            Console.Write("Maandag: ");
            m.AddTemperature(DayOfWeek.Monday , double.Parse(Console.ReadLine()));
            Console.Write("Dinsdag: ");
            m.AddTemperature(DayOfWeek.Tuesday, double.Parse(Console.ReadLine()));
            Console.Write("Woensdag: ");
            m.AddTemperature(DayOfWeek.Wednesday, double.Parse(Console.ReadLine()));
            Console.Write("Donderdag: ");
            m.AddTemperature(DayOfWeek.Thursday, double.Parse(Console.ReadLine()));
            Console.Write("Vrijdag: ");
            m.AddTemperature(DayOfWeek.Friday, double.Parse(Console.ReadLine()));
            Console.Write("Zaterdag: ");
            m.AddTemperature(DayOfWeek.Saturday, double.Parse(Console.ReadLine()));
            Console.Write("Zondag: ");
            m.AddTemperature(DayOfWeek.Sunday, double.Parse(Console.ReadLine()));

            Console.Clear();
            Console.WriteLine("Weeroverzicht voor de week van {0:D} tot {1:D}",
                m.FirstDateOfWeek, m.FirstDateOfWeek.AddDays(6));
            Console.WriteLine("-".PadRight(100));
            Console.WriteLine("Weerstation: {0}", m.WeatherStation);
            Console.WriteLine("Weermens: {0}", m.WeatherPerson);
            Console.WriteLine();
            Console.WriteLine("Metingen:");
            Console.WriteLine("Maandag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek, m.Temperatures[0]);
            Console.WriteLine("Dinsdag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek.AddDays(1), m.Temperatures[1]);
            Console.WriteLine("Woensdag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek.AddDays(2), m.Temperatures[2]);
            Console.WriteLine("Donderdag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek.AddDays(3), m.Temperatures[3]);
            Console.WriteLine("Vrijdag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek.AddDays(4), m.Temperatures[4]);
            Console.WriteLine("Zaterdag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek.AddDays(5), m.Temperatures[5]);
            Console.WriteLine("Zondag {0:d-M-yyyy}: {1:0.00}", m.FirstDateOfWeek.AddDays(6), m.Temperatures[6]);

            Console.WriteLine("Statistieken voor week " + GetIso8601WeekOfYear(DateTime.Today) + ": ");
            Console.WriteLine("De hoogste temperatuur van de week, {0:0.0} graden, werd gemeten op {1:D}",
                m.Max, m.HottestDate);
            Console.WriteLine("De laagste temperatuur van de week, {0:0.0} graden, werd gemeten op {1:D}",
                m.Min, m.ColdestDate);
            Console.WriteLine("De gemiddelde temperatuur van de week was {0:0.00} graden.",
                m.AverageTemperature);
            Console.WriteLine("De standaarddeviatie is {0:0.00} graden.",
                m.StandardDeviationOfTemperatures);
            Console.ReadKey();
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
