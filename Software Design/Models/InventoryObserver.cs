using Software_Design.Interfaces;
using Software_Design.Models.ObservationNotificationProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Design.Models
{
    public class InventoryObserver : IObserver<InventoryItem>
    {

        public string Name { get; set; }

        public IObservationNotificationProvider ObservationNotificationProvider { get; set; }

        public InventoryObserver(string name)
        {
            Name = name;
            ObservationNotificationProvider = new Cli();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(InventoryItem value)
        {
            ObservationNotificationProvider.SendMessage(value, Name);
        }
    }
}
