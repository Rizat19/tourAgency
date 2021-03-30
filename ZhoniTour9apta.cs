using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency;

namespace TourAgency
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

            //personnels.Add(new Personnel());
            personnels.Add(new Personnel("Orazalina Rizat", "+77071225589"));
            personnels.Add(new Personnel("Spabekov Zhanibek", "+77075257171"));
            personnels.Add(new Personnel("Turlybekov Daulet", "+77719864521"));
            personnels.Add(new Personnel("Yerkin Meruert", "+77086951452"));

            Line();


            //countries.Add(new Country());
            countries.Add(new Country("Thailand", 1500, 60));
            countries.Add(new Country("Russia", 500, 90));
            countries.Add(new Country("France", 1200, 30));
            countries.Add(new Country("Egypt", 800, 30));
            countries.Add(new Country("Turkey", 900, 90));

            Line();

            bool flag = true;
            while (flag)
            {

                Console.WriteLine("Welcome \n1. Tour tandau \n2. Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {

                    foreach (var s in personnels)
                    {
                        Console.WriteLine(s.toStringPersonnel());
                    }

                    Line();

                    Console.WriteLine("Personnel Name, id :");
                    int personnelID = int.Parse(Console.ReadLine());

                    Line();

                    foreach (var s in countries)
                    {
                        Console.WriteLine(s.toString());
                    }

                    Line();

                    Console.WriteLine("Memleket tanda, id:");
                    int idCountry = Convert.ToInt16(Console.ReadLine());

                    Line();

                    Console.WriteLine("Date start");
                    string dateStartTour = checkDate();
                    Console.WriteLine("Neshe kunge barginiz keledi ? " + countries[idCountry - 1].days + " kunnen artiq bolmau kerek");
                    int day = int.Parse(Console.ReadLine());
                    string dateFinishTour = dateFinTour(dateStartTour, day);
                    Console.WriteLine("Kansha adam baradi ?");
                    int countPersonTour = int.Parse(Console.ReadLine());

                    Line();

                    tours.Add(new Tour(countries[idCountry - 1], dateStartTour, dateFinishTour, countPersonTour));

                    Console.WriteLine(tours[tours.Count - 1].toStringTour());

                    Line();

                    Console.WriteLine("Zhalgastyrgyniz kele me?\n 1. Yes \n 2. No");
                    int tandau = int.Parse(Console.ReadLine());

                    Line();

                    if (tandau == 1)
                    {
                        int countClient = clients.Count;
                        for (int i = 0; i < countPersonTour; i++)
                        {
                            clients.Add(new Client());
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        }

                        orders.Add(new Order(clients, personnels[personnelID - 1], tours[tours.Count - 1], countClient));
                        Line();
                        Console.WriteLine(orders[orders.Count - 1].toStringOrder());

                        Line();

                        Console.WriteLine("Siz bergen aqparat duris pa ?\n1.Yes \n2.No, update");
                        int tandauUpdate = int.Parse(Console.ReadLine());
                        if(tandauUpdate == 1)
                        {
                            Console.WriteLine("Demalisiniz zhaksy otsin !");
                        } else if (tandauUpdate == 2)
                        {
                            bool flag2 = true;
                            while (flag2)
                            {
                                Console.WriteLine("Qai aqparatti zhanartasiz ?" +
                                    "\n1. Name \n2. LastName \n3. Date start tour \n4. Demalys kuni \n5. Exit");
                                Line();
                                int tandauUpdate2 = int.Parse(Console.ReadLine());
                                switch (tandauUpdate2)
                                {
                                    case 1:
                                        Console.WriteLine("Enter update name :");
                                        string name = Console.ReadLine();
                                        clients[clients.Count - 1].Name = name;
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter update LastName :");
                                        string lastName = Console.ReadLine();
                                        clients[clients.Count - 1].LastName = lastName;
                                        break;
                                    case 3:
                                        string dateStartUpdate = checkDate();
                                        tours[tours.Count - 1].DateStart = dateStartUpdate;
                                        break;
                                    case 4:
                                        Console.WriteLine("Neshe kunge barginiz keledi ? " + countries[idCountry - 1].days + " kunnen artiq bolmau kerek");
                                        int day2 = int.Parse(Console.ReadLine());
                                        string dateFinishTourUpdate = dateFinTour(dateStartTour, day2);
                                        tours[tours.Count - 1].DateFinish = dateFinishTourUpdate;
                                        break;
                                    case 5:
                                        flag2 = false;
                                        break;
                                    default:
                                        Console.WriteLine("1 men 5 arasinda tandanyz");
                                        break;
                                }
                            }
                            Console.WriteLine(orders[orders.Count - 1].toStringOrder());
                        }
                        else
                        {
                            Console.WriteLine("1 nemese 2 ni tandaniz!!");
                        }

                    }
                    else if (tandau == 2)
                    {
                        Console.WriteLine("sau bol");
                    }
                    else
                    {
                        Console.WriteLine("1 nemese 2 ni tandaniz!!");
                    }

                } else if (choice == 2)
                {
                    flag = false;
                } else
                {
                    Console.WriteLine("1 nemese 2 tandaniz!!");
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

        public static string checkDate()
        {
            string date = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter date");
                date = Console.ReadLine();

                if (date.Length > 6 && date.Length <= 10 && dateCheck(date))
                {
                    //dateCheck(date);
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Date dd.mm.yyyy");
                }

            }
            return date;
        }

        public static bool dateCheck(string d)
        {
            // d = 1.1.20    //35.14.21
            string[] date = d.Split('.');
            bool flag = true;
            int[] date2 = new int[date.Length];
            for (int i = 0; i < date2.Length; i++)
            {
                date2[i] = Convert.ToInt32(date[i]);
            }

            if (date2[0] < 0 || date2[0] > 32)
            {
                Console.WriteLine("Kun 1 men 31 araligynda bolu kerek");
                flag = false;
            }

            if (date2[1] <= 0 || date2[1] > 12)
            {
                Console.WriteLine("Ai 1 men 12 araligynda bolu kerek");
                flag = false;
            }

            if (date2[2] <= 2020 || date2[2] > 2023)
            {
                Console.WriteLine("Zhyl 2021 men 2022 araligynda bolu kerek");
                flag = false;
            }
            return flag;
        }

        public static string dateFinTour(string d, int n)
        {
            string dateFinish = "";
            string[] date = d.Split('.');
            int[] date2 = new int[date.Length];
            for (int i = 0; i < date2.Length; i++)
            {
                date2[i] = Convert.ToInt32(date[i]);
            }
            int weekend = date2[0] + n;
            if (weekend > 30)
            {
                date2[0] = weekend % 30;
                date2[1] += weekend / 30;
            }
            if(date2[1] > 12)
            {
                date2[1] %= 12;
                date2[2] += 1;
            }
            if (date2[0] < 10)
            {
                dateFinish += 0;
            }
            dateFinish += date2[0] + ".";
            if (date2[1] < 10)
            {
                dateFinish += 0;
            }
            dateFinish += date2[1] + "." + (date2[2]);

            return dateFinish;

        }

    }

    public class Country
    {
        public int id;
        public string countryName;
        public int price;
        public int days;
        private static int count = 0;


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

        public string toString()
        {
            return "ID " + id + " country: " + this.countryName +
                 "; price :" + this.price + "; day: " + this.days;
        }

    }

    public class Client
    {
        private string name; // клиент аты
        private string lastName; //клиент фамилиясы
        private string phone; //клиент телефон номері
        private string passport; //клиент жеке куәлік номері
        private int clientID; //клиент ID-і 
        private static int counter = 0;
        private ZagranPassport zp;


        // Бос конструктор
        public Client()
        {

            Console.WriteLine("Enter name ");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter lastName ");
            this.LastName = Console.ReadLine();;
            this.Phone = checkNumber();
            this.Passport = checkPassportNmb();
            zp = new ZagranPassport(this.passport);
            clientID = ++counter;
        }

        //Параметрлі конструктор
        public Client(string name, string lastName, string phone, string passport)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Phone = phone;
            this.Passport = passport;
            clientID = ++counter;
        }

        public string toStringClient()
        {
            return "\nSurname: " + this.lastName + "; Name: " + this.name +
                "\n Phone number: " + this.phone + "\nDannie passporta :" +
                zp.toStringPassport();
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

        public string checkNumber()
        {
            string phone = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter client phone");
                phone = Console.ReadLine();
                if (phone.Length == 12)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Nomerdi duris engiziniz +7 777 888 99 66");
                }
            }
            return phone;
        }

        public string checkPassportNmb()
        {
            string passportNmb = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter passport number");
                passportNmb = Console.ReadLine();
                if (passportNmb.Length == 9)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Passport nomeri 9 simvol");
                }
            }
            return passportNmb;
        }
    }
}



public class Tour
{
    private int tourID; //Тур ID-і
    private static int counter = 0;
    private string dateStart; //Турдың басталу уақыты
    private string dateFinish; //Турдың аяқталу уақыты
    private double tourPrice; //Тур бағасы
    private int countPerson; //Турға баратын адам саны
    public Country country;
    

    public Tour()
    {
        
        Country c = null;
        this.DateStart = "defaultDataStart";
        this.DateFinish = "defaultDataFinish";
        this.countPerson = 0;
        this.tourPrice = 0;
        tourID = ++counter;
    }

    public Tour(Country c, string dateStart, string dateFinish, int countPerson)
    {
        

        this.country = c;
        this.DateStart = dateStart;
        this.DateFinish = dateFinish;
        this.countPerson = countPerson;
        this.tourPrice = tourPricePerson();
        tourID = ++counter;
    }
    

    // Адам санына байланысты тур бағасын есептеу әдісі
    public double tourPricePerson()
    {
        if (countPerson <= 5)
        {
            tourPrice = countPerson * country.price * (1.05 - (5.0 * countPerson) / 100.0);
        }
        else
        {
            this.tourPrice = 0.8 * countPerson * this.country.price;
        }

        return this.tourPrice;
    }

    public string toStringTour()
    {

        return "Country :" + this.country.countryName + " ;tour price :" + this.tourPrice +
            "; nachalo tour :" + this.DateStart + "; konec tour :" + this.DateFinish;
    }

    public int CountPerson
    {
        get;set;
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
                dateFinish = value;
           
        }
        get { return dateFinish; }
    }
    
}

class ZagranPassport
{
    private int passportID; // ЗагранПасспорт ID-і
    private static int counter = 0;
    private string passportNumber; //ЗагранПасспорт номері
    private string dateStartPassport; //ЗагранПасспорт басталу уақыты
    private string dateFinishPassport; // ЗагранПасспорт аяқталу уақыты

    public ZagranPassport(string passportNmb)
    {
        this.passportID = ++counter;
        this.PassportNumber = passportNmb;
        Console.WriteLine("Passport berilgen uaqiti");
        this.DateStartPassport = checkDate();
        Console.WriteLine("Passport srogi :");
        this.DateFinishPassport = dateSrogZp(this.DateStartPassport);
    }

    public ZagranPassport(string passportNumber, string dateStartPassport, string dateFinishPassport)
    {
        this.passportID = ++counter;
        this.PassportNumber = passportNumber;
        this.DateStartPassport = dateStartPassport;
        this.DateFinishPassport = dateFinishPassport;
    }

    public string toStringPassport()
    {
        return "Passport number: " + this.passportNumber +
            "\nDate start: " + this.dateStartPassport +
            "\nDate finish: " + this.dateFinishPassport;
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
            if (value.Length <= 10)  //01.07.2020
            { dateStartPassport = value; }
            else
            { Console.WriteLine("Datany durys engiziniz"); }
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

    

    public string checkDate()
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

    public string dateSrogZp(string d)
    {
        string dateFinish = "";
        string[] date = d.Split('.');
        int[] date2 = new int[date.Length];
        for (int i = 0; i < date2.Length; i++)
        {
            date2[i] = Convert.ToInt32(date[i]);
        }
        if(date2[0] < 10)
        {
            dateFinish += 0;
        }
        dateFinish += date2[0] + ".";
        if (date2[1] < 10)
        {
            dateFinish += 0;
        }
        dateFinish += date2[1] + "." + (date2[2] + 10);

        return dateFinish;

    }
}


    public class Personnel
    {
        private int personnelID;
        private static int count;
        private string personnelFIO;
        private string personnelPhone;

        public Personnel()
        {
            Console.WriteLine("Personnel FiO :");
            this.PersonnelFIO = Console.ReadLine();
            //Console.WriteLine("Personnel phone number ");
            this.PersonnelPhone = checkNumber();
            this.personnelID = ++count;
        }

        public string toStringPersonnel()
        {
            return "ID " + this.personnelID + " " + this.PersonnelFIO + "; phone number :" + this.personnelPhone;
        }

        public Personnel(string personnelFIO, string personnelPhone)
        {
            this.PersonnelFIO = personnelFIO;
            this.PersonnelPhone = personnelPhone;
            this.personnelID = ++count;
        }

        public string PersonnelFIO
        {
            set
            {
                personnelFIO = value.ToUpper(); //АТЫ
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

        public string checkNumber()
        {
            string phone = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter personnel phone :");
                phone = Console.ReadLine();
                if (phone.Length == 12)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Nomerdi duris engiziniz");
                }
            }
            return phone;
        }
    }


    public class Order
    {
        private int orderID;
        private static int count = 0;
        private Personnel personnel;
        private int countClient;
        private List<Client> client;
        private Tour tour;

        public Order(List<Client> client, Personnel personnel, Tour tour, int countClient)
        {
            this.client = client;
            this.personnel = personnel;
            this.tour = tour;
            this.countClient = countClient;
            orderID = ++count;
        }

        public string toStringOrder()
        {
            return "Vas obsluzhival : " + personnel.toStringPersonnel() +
                "\n Vashi dannie  : \n" + ClientToString() +
                "\nVash Tour: " + tour.toStringTour();
        }

        public string ClientToString()
        {
            string s = "";
            for (int i = countClient; i < this.client.Count; i++)
            {
                s += client[i].toStringClient();
                Console.WriteLine();
            }
            return s;
        }
    }