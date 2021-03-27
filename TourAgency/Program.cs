using System;
using System.Collections.Generic;

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

            // Персоналдар
            //personnels.Add(new Personnel());
            personnels.Add(new Personnel("Spabekov Zhanibek", "+77075257171", "zhanibek25@mail.ru","123"));
            personnels.Add(new Personnel("Turlybekov Daulet", "+77719864521","dauks@mail.ru","111"));
            personnels.Add(new Personnel("Yerkin Meruert", "+77086951452","meru@mail.ru","222"));

            Line();
            
            // Мемлекеттер
            //countries.Add(new Country());
            countries.Add(new Country("Russia", 500, 90));
            countries.Add(new Country("France", 1200, 30));
            countries.Add(new Country("Egypt", 800, 30));
            countries.Add(new Country("Turkey", 900, 90));

            Line();
            
            
            //*Rizat

            while (true)
            {
                Console.WriteLine("Выберите:\n[1]-Клиент" +
                                  "\n[2]-Регистрация* только для сотрудников" +
                                  "\n[3]-Вход * только для сотрудников"+
                                  "\n[4]-Выход");
                Line();
                int vibor = Int32.Parse(Console.ReadLine());
                if (vibor == 1)
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.WriteLine("------Клиент------");
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
                            Console.WriteLine("Kansha adam baradi ?");
                            int countPersonTour = int.Parse(Console.ReadLine());

                            Line();

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
                                orders[orders.Count-1].addList();

                            }
                            else if (tandau == 2)
                            {
                                Console.WriteLine("sau bolynyz!!!");
                            }
                            else
                            {
                                Console.WriteLine("1 nemese 2 ni tandaniz!!!");
                            }

                        } else if(choice == 2)
                        {
                            flag = false;
                        } else
                        {
                            Console.WriteLine("1 nemese 2 tandaniz!!!");
                        }
                    }
                }else if (vibor == 2)
                {
                    Console.WriteLine("-----Регистрация------");
                    Personnel.Registration(personnels);
                }else if (vibor == 3)
                {
                    Console.WriteLine("------Вход-------");
                    Personnel.Login(personnels);
                }else if (vibor == 4)
                {
                    Console.WriteLine("До встречи!!!");
                    break;
                }
                
                
            }

        }

        public static void Line()
        {
            int i = 0;
            while(i != 44)
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
    
}