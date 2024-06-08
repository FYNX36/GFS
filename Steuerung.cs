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
        public int getId() { return id; }


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

        public bool getRegistered()
        {
            return registered;
        }

        public static decimal GetBalanceById(int userId)
        {
            var user = Data.RegisteredCustomerIds.Find(u => u.Id == userId);
            return user?.balance ?? 0.00m;
        }
        public void UpdateBalance(int userId, decimal newBalance)
        {
            var user = Data.RegisteredCustomerIds.Find(u => u.Id == userId);
            if (user != null)
            {
                user.balance = newBalance;
            }
        }
        
        public void safeOrder(string btn)
        {
            if (Order.Any(order => order.Id == btn))
            {
                Order.Find(order => order.Id == btn).count++;
            }
            else { Order.Add(new OrderGen { Id = btn, count = 1 }); }
        }
        public void deleteOrder()
        {
            Order.Clear();
        }

        

        






    }
}
