using Software_Design.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Design.Models.ObservationNotificationProviders
{
    public class Cli : IObservationNotificationProvider
    {
        public void SendMessage(InventoryItem inventoryItem, string observerName)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello " + observerName + ", The item \"" + inventoryItem.Title + "\" has changed.");
            Console.ForegroundColor = oldColor;
        }
    }
}
