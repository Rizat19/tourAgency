using System;

namespace TourAgency
{
    class ZagranPassport
    {
        private int passportID; // ЗагранПасспорт ID-і
        private static int counter = 0; // счетчик
        private string passportNumber; //ЗагранПасспорт номері
        private string dateStartPassport; //ЗагранПасспорт басталу уақыты
        private string dateFinishPassport; // ЗагранПасспорт аяқталу уақыты

        // Конструкторлар
        public ZagranPassport(string passportNmb)
        {
            this.passportID = ++counter;
            this.PassportNumber = passportNmb;
            Console.WriteLine("Passport berilgen uaqiti");
            this.DateStartPassport = checkDate();
            Console.WriteLine("Passport srogi :");
            this.DateFinishPassport = checkDate();
        }

        public ZagranPassport(string passportNumber, string dateStartPassport, string dateFinishPassport)
        {
            this.passportID = ++counter;
            this.passportNumber = passportNumber;
            this.dateStartPassport = dateStartPassport;
            this.dateFinishPassport = dateFinishPassport;
        }

        public string PassportNumber
        {
            set
            {
                passportNumber = value;
            }
            get
            { return passportNumber; }
        }

        public string DateStartPassport
        {
            set
            {
                dateStartPassport = value;
            }
            get
            { return dateStartPassport; }
        }
        public string DateFinishPassport
        {
            set
            {
                dateFinishPassport = value; 
            }
            get
            {
                return dateFinishPassport;
            }
        }
        
        // Датаны тексеру әдісі
        public string checkDate()
        {
            string date = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Passport Enter date: ");
                date = Console.ReadLine();
                if (date.Length > 6 && date.Length <= 10)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Date dd.mm.yyyy formatta bolady!");
                }
            }
            return date;
        }
        
        // toString()
        public string toStringPassport()
        {
            return "Passport number: " + this.passportNumber +
                   "\nPassport Date start: " + this.dateStartPassport +
                   "\nPassport Date finish: " + this.dateFinishPassport;
        }
    }
}