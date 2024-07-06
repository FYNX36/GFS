using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFS
{
    public static class Data
    {

        // Liste der Menüpunkte
        public static List<MenuItem> MenuItems { get; } = new List<MenuItem>
         {
           new MenuItem {Nummer = "1", Name = "Bürger", Price = 8.99m},
           new MenuItem {Nummer = "2", Name = "Nudeln", Price = 5.60m},
           new MenuItem {Nummer = "3", Name = "Salat", Price = 4.20m},
           new MenuItem {Nummer = "4", Name = "Pizza", Price = 9.99m},
           new MenuItem {Nummer = "5", Name = "Veg. Menü", Price = 10.50m},
           new MenuItem {Nummer = "6", Name = "Menü", Price = 11.50m},
           new MenuItem {Nummer = "7", Name = "Getränk gr", Price = 1.20m},
           new MenuItem {Nummer = "8", Name = "Getränk kl", Price = 0.80m},
           new MenuItem {Nummer = "9", Name = "Kaffe", Price = 1.10m},
         };
        

        // Liste der registrierten Benutzer
        public static List<UserGen> RegisteredCustomerIds { get; } = new List<UserGen>
        {
            new UserGen {Id = 110, balance = GetRandomBalance()},
            new UserGen {Id = 112, balance = GetRandomBalance()},
            new UserGen {Id = 233, balance = GetRandomBalance()},
            new UserGen {Id = 964, balance = GetRandomBalance()},
            new UserGen {Id = 565, balance = GetRandomBalance()},
            new UserGen {Id = 631, balance = GetRandomBalance()},
            new UserGen {Id = 745, balance = GetRandomBalance()},
            new UserGen {Id = 808, balance = GetRandomBalance()},
            new UserGen {Id = 913, balance = GetRandomBalance()},
            new UserGen {Id = 710, balance = GetRandomBalance()},
        };


        // Gibt eine zufällige Guthaben zurück
        private static decimal GetRandomBalance()
        {

            Random rnd = new Random();
            return rnd.Next(15, 50);
        }
    }
}
