using System;

namespace TourAgency
{
    public class Tour
    {
        private int tourID; //Тур ID-і
        private static int counter = 0; // счетчик 
        private string dateStart; //Турдың басталу уақыты
        private string dateFinish; //Турдың аяқталу уақыты
        private double tourPrice; //Тур бағасы
        private int countPerson; //Турға баратын адам саны
        public Country country;  

        // Конструкторлар
        
        public Tour()
        {
            country = new Country();
            this.dateStart = "defaultDataStart";
            this.dateFinish = "defaultDataFinish";
            this.countPerson = 0;
            this.tourPrice = 0;
            this.tourID = ++counter;
        }

        public Tour(Country c, string dateStart, string dateFinish, int countPerson)
        {
            this.country = c;
            this.dateStart = dateStart;
            this.dateFinish = dateFinish;
            this.countPerson = countPerson;
            this.tourPrice = tourPricePerson();
            this.tourID = ++counter;
        }

        // Адам санына байланысты тур бағасын есептеу әдісі
        public double tourPricePerson()
        {
            // тур бағасын Country класы ішінен аламыз
            if (countPerson <= 5)
            {
               // скидка жасау формуласы
                tourPrice = countPerson * country.Price * (1.05 - (5.0 * countPerson) / 100.0);
            }
            else
            {
                this.tourPrice = 0.8 * countPerson * this.country.Price;
            }

            return this.tourPrice;
        }

        // Қасиеттері (get, set аксессорлары)
        public int TourId
        {
            get { return tourID; }
        }

        public int CountPerson
        {
            get { return countPerson; }
            set
            {
                countPerson = value;
            }
        }

        public double TourPrice
        {
            get { return tourPrice; }
            set
            {
                tourPrice = value;
            }
        }

        public string DateStart
        {
            set
            {
                dateStart = value;
            }
            get { return dateStart; }
        }

        public string DateFinish
        {
            set
            {
                dateStart = value;
                
            }
            get { return dateFinish; }
        }
        
        public string toStringTour()
        {

            return "Country :" + this.country.CountryName + " ;tour price :" + this.tourPrice;
        }
    }
}