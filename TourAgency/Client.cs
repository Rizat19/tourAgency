using System;

namespace TourAgency
{
    public class Client
    {
        private string name; // клиент аты
        private string lastName; // клиент фамилиясы
        private string phone; // клиент телефон номері
        private string passport; //клиент жеке куәлік номері
        private int clientID; // клиент ID-і 
        private static int counter = 0; // счетчик
        private ZagranPassport zp; // загранпаспортты беру үшін загранпаспорт класын объект құрып шақыру


        // Бос конструктор
        public Client()
        {

            Console.WriteLine("Enter client name: ");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter lastName: ");
            this.LastName = Console.ReadLine();;
            this.Phone = checkNumber();
            this.Passport = checkPassportNmb();
            zp = new ZagranPassport(this.passport);
            this.clientID = ++counter;
        }

        //Параметрлі конструктор
        public Client(string name, string lastName, string phone, string passport)
        {
            this.Name = name;
            this.LastName = lastName;
            this.phone = phone;
            this.passport = passport;
            this.clientID = ++counter;
        }
        

        // Қасиеттері (get, set аксессорлары)
        public string Name
        {
            set
            {
                name = value.ToUpper(); //АТЫ
            }
            get
            { return name; }
        }

        public string LastName
        {
            set
            {
                lastName = value.ToUpper(); //ФАМИЛИЯ
            }
            get
            { return lastName; }
        }

        public int ClientId
        {
            get { return clientID; }
        }

        public string Phone
        {
            set
            {
                phone = value;
            }
            get
            { return phone; }
        }

        public string Passport
        {
            set
            {
                passport = value;   
            }
            get
            { return passport; }
        }

        //Клиент телефон номерін тексеретін әдіс
        public string checkNumber()
        {
            string phone = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter client phone: ");
                phone = Console.ReadLine();
                if (phone.Length == 12)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Client phone nomerin duris engiziniz +77778889966 formatta bolu kerek!");
                }
            }
            return phone;
        }

        // Клиент Паспортының номерін тексеретін әдіс 
        public string checkPassportNmb()
        {
            string passportNmb = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter passport number: ");
                passportNmb = Console.ReadLine();
                if (passportNmb.Length == 9)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Passport nomeri 9 simbol bolu kerek!");
                }
            }
            return passportNmb;
        }
        
        // toString()
        public string toStringClient()
        {
            return "Surname: " + this.lastName + "; Name: " + this.name +
                   "\nPhone number: " + this.phone + "\nDannie passporta :" +
                   zp.toStringPassport();
        }
    }
}