using System;

namespace TourAgency
{
    public class Country
    {
        private int id; // Мемлекет ID-i
        private string countryName; // Мемлекет аты
        private int price; // Осы мемлекетке бару құны
        private int days; // күні
        private static int count = 0; // счетчик ID-ді есептеу үшін қажет
        
        // Конструкторлар
        public Country()
        {
            Console.WriteLine("Name country :");
            this.countryName = Console.ReadLine();
            Console.WriteLine("Price money");
            this.price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Days ");
            this.days = Convert.ToInt32(Console.ReadLine());
            this.id = ++count;
        }
        public Country(string name, int price, int days)
        {
            this.countryName = name;
            this.price = price;
            this.days = days;
            this.id = ++count;
        }

        // Қасиеттері (get, set аксессорлары)
        public string CountryName
        {
            get { return countryName; }
            set
            {
                countryName = value;
            }
        }

        public int Days
        {
            get { return days; }
            set
            {
                days = value;
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
            }
        }

        public int Id
        {
            get { return id; }
        }

        // Country туралы ақпаратты string типте қайтару әдісі
        public string toString()
        {
            return "Country ID " + id + " country: " + this.countryName +
                   "; price :" + this.price + "; day: " + this.days;
        }

    }
}