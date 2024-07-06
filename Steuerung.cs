using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GFS
{
    public class Steuerung
    {
        
        private bool registered;
        private int id;
        public List<OrderGen> Order  = new List<OrderGen>();

        // Setzt die ID
        public void setId(int Id)
        {
            try
            {
                id = Id;
            }
            catch (Exception)
            {
                id = 0;
            }
        }

        // Gibt die ID zurück
        public int getId() { return id; }


        // Überprüft, ob der Benutzer registriert ist
        public void checkRegistered()
        {
            if (Data.RegisteredCustomerIds.Any(user => user.Id == id))
            {
                registered = true;
            }
            else
            {
                registered = false;
            }
        }

        // Gibt zurück, ob der Benutzer registriert ist
        public bool getRegistered()
        {
            return registered;
        }


        // Gibt das Guthaben des Benutzers zurück
        public static decimal GetBalanceById(int userId)
        {
            var user = Data.RegisteredCustomerIds.Find(u => u.Id == userId);
            return user?.balance ?? 0.00m;
        }

        // Aktualisiert das Guthaben des Benutzers
        public void UpdateBalance(int userId, decimal newBalance)
        {
            var user = Data.RegisteredCustomerIds.Find(u => u.Id == userId);
            if (user != null)
            {
                user.balance = newBalance;
            }
        }

        // Speichert die Bestellung
        public void safeOrder(string btn)
        {
            if (Order.Any(order => order.Id == btn))
            {
                Order.Find(order => order.Id == btn).count++;
            }
            else { Order.Add(new OrderGen { Id = btn, count = 1 }); }
        }

        // Löscht die Bestellung
        public void deleteOrder()
        {
            Order.Clear();
        }

        

        






    }
}
