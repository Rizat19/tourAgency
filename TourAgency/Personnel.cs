using System;
using System.Collections.Generic;

namespace TourAgency
{
    public class Personnel
    {
        private int personnelID; // Персонал ID-і
        private static int count; // счетчик 
        private string personnelFIO; // Персонал Аты-жөні
        private string personnelPhone; // Персонал телефон номері
        
        //*Rizat
        private string password; // *пароль 
        private string email; // *логин-почта

        // Конструкторлар
        public Personnel()
        {
            Console.WriteLine("ФИО персонала:");
            this.PersonnelFIO = Console.ReadLine();
            this.personnelPhone = checkNumber();
            this.personnelID = ++count;
            //*Rizat
            Console.WriteLine("Введите email:");
            this.email = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            this.password = Console.ReadLine();
            
        }
        
        public Personnel(string personnelFIO, string personnelPhone, string email, string password)
        {
            this.PersonnelFIO = personnelFIO;
            this.personnelPhone = personnelPhone;
            this.email = email;
            this.password = password;
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

        //*Rizat
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
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
        
        //*Rizat
        // регистрация жасау
        public static void Registration(List<Personnel> personnels)
        {
            Console.WriteLine("Введите FIO:");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите телефон номер:");
            string numberPhone = Console.ReadLine();
            Console.WriteLine("Введите email:");
            string email = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Введите пароль");
                string pwd = Console.ReadLine();
                Console.WriteLine("Подтвердите пароль");
                string pwd1 = Console.ReadLine();
                if (pwd != pwd1)
                {

                }else if (pwd == pwd1)
                {
                    Program.Line();
                    personnels.Add(new Personnel(fio, numberPhone, email,pwd1));
                    Personnel.Print(personnels);
                    break;
                }
            }
        }
        
        // Вход- Кіру 
        public static void Login(List<Personnel> personnels)
        {
            Console.WriteLine("Введите email:");
            string email = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            if (IsPersonnel(email, password, personnels))
            {
                while (true)
                {
                    Program.Line();
                    Console.WriteLine("[1]-Продажи\n[2]-Список сотрудников\n[3]-Выход");
                    int choice = int.Parse(Console.ReadLine());
                    Program.Line();
                    if(choice == 1){
                        Program.Line();
                        Order.Prodaji();
                    }else if (choice == 2)
                    {
                        Program.Line();
                        Print(personnels);
                    }else if (choice == 3)
                    {
                        Program.Line();
                        Console.WriteLine("До встречи!!!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("доступ запрещен!!!");
                Program.Line();
            }
        }
        
        // Список элементтерін экранға шығару
        public static void Print(List<Personnel> personnels) 
        {
            Console.WriteLine("------Список сотрудников турфирмы-------");
            for (int i = 0; i < personnels.Count; i++)
            {
                Console.WriteLine($"ID: {personnels[i].personnelID}\nФИО: {personnels[i].personnelFIO}" +
                                  $"\nТелефон: {personnels[i].personnelPhone}\nE-mail: {personnels[i].email}");
                Program.Line();
            }
        }
        // Персоналды растау-списоктан іздеу
        public static bool IsPersonnel(string email,string pwd, List<Personnel> personnels) 
        { 
            bool isPersonnel = false;
            foreach (var personnel in personnels)
            {
                if( email.Equals(personnel.email) && pwd.Equals(personnel.password) )
                {
                    isPersonnel = true;
                    break;
                }
            }
            return isPersonnel;
        }
    }
}