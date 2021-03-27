using System;
using System.Collections;
using System.Collections.Generic;

namespace TourAgency
{
    public class Order
    {
        private int orderID; // Заказ ID-і
        private static int count = 0; // счетчик
        private Personnel personnel; // Персонал
        private int countClient; // Клиент саны
        private List<Client> client; // Клиенттер тізімі
        private Tour tour; // Тур
        
        //*Rizat
        private static ArrayList list = new ArrayList();
        

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
                s += client[i].toStringClient()+"\n";
                Console.WriteLine();
            }
            return s;
        }
        
        // Заказ туралы ақпаратты string типте қайтару, яғни toString()
        public string toStringOrder()
        {
            return "obsluzhival(-a) : " + personnel.toStringPersonnel() +
                   "\ndannie clienta : " + ClientToString() +
                   "\nTour: " + tour.toStringTour()+"\n";
        }

        //Каждый жасалған заказды листке косып отыру
        public void addList()
        {
            list.Add(toStringOrder());
        }

        public static void Prodaji()
        {
            
            Console.WriteLine("-----Список продаж-----:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
       
        
        
    }
}