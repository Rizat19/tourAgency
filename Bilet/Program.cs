using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Bilet
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<Client>();
            var tours = new List<Tour>();
            var personnels = new List<Personnel>();
            var passports = new List<ZagranPassport>();
            List<Country> countries = new List<Country>();
            var orders = new List<Order>();

            // Персоналдар
            personnels.Add(new Personnel("Spabekov Zhanibek", "+77075257171"));
            personnels.Add(new Personnel("Turlybekov Daulet", "+77719864521"));
            personnels.Add(new Personnel("Yerkin Meruert", "+77086951452"));

            Line();

            // Мемлекеттер
            countries.Add(new Country("Russia", 500, 90));
            countries.Add(new Country("France", 1200, 30));
            countries.Add(new Country("Egypt", 800, 30));
            countries.Add(new Country("Turkey", 900, 90));

            Line();

            bool flag = true;
            while (flag)
            {

                Console.WriteLine("\n1. Tour tandau \n2. Exit :");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    // Персоналдар тізімін көру
                    foreach (var s in personnels)
                    {
                        Console.WriteLine(s.toStringPersonnel());
                    }

                    Line();

                    // Тізімнен персоналды айдиі бойынша таңдау
                    Console.WriteLine("Personnel tanda, id:");
                    int personnelID = int.Parse(Console.ReadLine());

                    Line();

                    // Мемлекеттер тізімін көру
                    foreach (var s in countries)
                    {
                        Console.WriteLine(s.toString());
                    }

                    Line();

                    // Тізімнен мемлекетті айдиі бойынша таңдау
                    Console.WriteLine("Memleket tanda, id:");
                    int idCountry = Convert.ToInt16(Console.ReadLine());

                    Line();

                    // Турдың басталу және аяқталу датасын, адам санын енгізу
                    Console.WriteLine("Tour Date start:");
                    string dateStartTour = checkDate();
                    Console.WriteLine("Tour Date finish:");
                    string dateFinishTour = checkDate();

                    // new functional
                    while (true)
                    {
                        Console.WriteLine("Kansha adam baradi ?");
                        int countPersonTour = int.Parse(Console.ReadLine());
                        Line();
                        if (Tour.Bilet((countPersonTour)))
                        {
                            // Тур тізіміне алған деректерді беру
                            tours.Add(new Tour(countries[idCountry - 1], dateStartTour, dateFinishTour, countPersonTour));
                            // Тур туралы ақпарат алу
                            Console.WriteLine(tours[tours.Count - 1].toStringTour());

                            Line();

                            // Жалғастыру, яғни точно тур сатып алу процесі басталады

                            Console.WriteLine("Zhalgastyrgyniz kele me?\n 1. Yes \n 2. No");
                            int tandau = int.Parse(Console.ReadLine());

                            Line();

                            if (tandau == 1)
                            {
                                // клиенттерді тізімге қосу
                                int countClient = clients.Count;
                                for (int i = 0; i < countPersonTour; i++)
                                {
                                    clients.Add(new Client());
                                    Line();
                                }

                                // сәтті жасалған заказды да тізімге қосу
                                orders.Add(new Order(clients, personnels[personnelID - 1], tours[tours.Count - 1], countClient));
                                // сәтті жасалған заказ туралы ақпарат алу
                                Console.WriteLine(orders[orders.Count - 1].toStringOrder());
                                Line();
                                Console.WriteLine("Good bye!!");
                                break;

                            }
                            if (tandau == 2)
                            {
                                Console.WriteLine("sau bolynyz!!!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("1 nemese 2 ni tandaniz!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{Tour.bilet_sany} -bilet ala beresiz ba? 1-Yes, " +
                                              $"2-No, kerek emes, programmadan shygu:");
                            int tandauu = Int32.Parse(Console.ReadLine());
                            if (tandauu == 1)
                            {
                                Console.WriteLine($"Ok, onda adam sanyna  {Tour.bilet_sany}-biletten aspaytyn colichestvo zhazynyz!!!");
                            }

                            if (tandauu == 2)
                            {
                                Console.WriteLine("Sau bolynyz");
                                System.Environment.Exit(0); // programmadan shygy
                            }
                        }
                    }
                }
                else if (choice == 2)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("1 nemese 2 tandaniz!!!");
                }

            }
            Console.ReadKey();
        }
        
        public static void Line()
        {
            int i = 0;
            while (i != 44)
            {
                Console.Write("=");
                i++;
            }
            Console.WriteLine();
        }

        // Main-да Енгізілген датаны(күн.ай.жыл) тексеру әдісі
        public static string checkDate()
        {
            string date = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter date");
                date = Console.ReadLine();
                if (date.Length > 6 && date.Length <= 10)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Date dd.mm.yyyy");
                }
            }
            return date;
        }
    }
    
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

            Console.WriteLine("Enter name: ");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter lastName: ");
            this.LastName = Console.ReadLine(); ;
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
    
    
    public class Personnel
    {
        private int personnelID; // Персонал ID-і
        private static int count; // счетчик 
        private string personnelFIO; // Персонал Аты-жөні
        private string personnelPhone; // Персонал телефон номері

        // Конструкторлар
        public Personnel()
        {
            Console.WriteLine("Personnel FiO :");
            this.PersonnelFIO = Console.ReadLine();
            this.personnelPhone = checkNumber();
            this.personnelID = ++count;
        }

        public Personnel(string personnelFIO, string personnelPhone)
        {
            this.PersonnelFIO = personnelFIO;
            this.personnelPhone = personnelPhone;
            this.personnelID = ++count;
        }

        // аксессорлар get, set
        public string PersonnelFIO
        {
            set
            {
                personnelFIO = value.ToUpper(); //АТЫ-ЖӨНІ
            }
            get
            { return personnelFIO; }
        }

        public string PersonnelPhone
        {
            set
            {
                personnelPhone = value;
            }
            get
            { return personnelPhone; }
        }

        public int PersonnelId
        {
            get { return personnelID; }
        }

        // Персоналдың телефон номерин тексеретін әдіс
        public string checkNumber()
        {
            string phone = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter personnel phone: ");
                phone = Console.ReadLine();
                if (phone.Length == 12)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Personal phone nomerin duris engiziniz +77778889966 formatta bolu kerek!");
                }
            }
            return phone;
        }

        // toString()
        public string toStringPersonnel()
        {
            return "Personal ID: " + this.personnelID + " " + this.personnelFIO + "; phone number :" + this.personnelPhone;
        }
    }
    
    
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
    
    public class Tour
    {
        private int tourID; //Тур ID-і
        private static int counter = 0; // счетчик 
        private string dateStart; //Турдың басталу уақыты
        private string dateFinish; //Турдың аяқталу уақыты
        private double tourPrice; //Тур бағасы
        private int countPerson; //Турға баратын адам саны
        public Country country;
        
        public static int bilet_sany = 3;  // bilet sany shekteu

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
        
        //bilet
        public static bool Bilet(int countPerson)
        {
            bool availableTickets = false;
            if (bilet_sany > countPerson || bilet_sany == countPerson)
            {
                Console.WriteLine($"Ok, siz {countPerson} bilet aldynyz");
                bilet_sany -= countPerson;
                availableTickets = true;
            }
            else
            {
                Console.WriteLine($"Keshiriniz bizde tek {bilet_sany}-bilet kaldy!!!");
            }

            return availableTickets;
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
    
    
    public class Order
    {
        private int orderID; // Заказ ID-і
        private static int count = 0; // счетчик
        private Personnel personnel; // Персонал
        private int countClient; // Клиент саны
        private List<Client> client; // Клиенттер тізімі
        private Tour tour; // Тур

        // Конструкторлар

        public Order()
        {
            this.client = new List<Client>();
            this.personnel = new Personnel();
            this.tour = new Tour();
            this.countClient = 0;
            orderID = ++count;
        }

        public Order(List<Client> client, Personnel personnel, Tour tour, int countClient)
        {
            this.client = client;
            this.personnel = personnel;
            this.tour = tour;
            this.countClient = countClient;
            orderID = ++count;
        }

        public int CountClient
        {
            get { return countClient; }
            set
            {
                countClient = value;
            }
        }

        // Клиенттер туралы ақпаратты бір string-ге жинау
        public string ClientToString()
        {
            string s = "";
            for (int i = countClient; i < this.client.Count; i++)
            {
                s += client[i].toStringClient() + "\n";
                Console.WriteLine("\n");
            }
            return s;
        }

        // Заказ туралы ақпаратты string типте қайтару, яғни toString()
        public string toStringOrder()
        {
            return "Vas obsluzhival(-a) : " + personnel.toStringPersonnel() +
                   "\nVashi dannie  : " + ClientToString() +
                   "Vash Tour: " + tour.toStringTour();
        }
    }
}