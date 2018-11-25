using Software_Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Design.Interfaces
{
    public interface IObservationNotificationProvider
    {
        void SendMessage(InventoryItem inventoryItem, string observerName);
    }
}
