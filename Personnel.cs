using System;

namespace TourAgency
{
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
}