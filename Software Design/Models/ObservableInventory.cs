using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Design.Models
{
    public class ObservableInventory : IObservable<InventoryItem>
    {
        public List<InventoryItem> InventoryItems { get; set; }

        public List<IObserver<InventoryItem>> Observers { get; set; }

        public ObservableInventory()
        {
            InventoryItems = new List<InventoryItem>();
            Observers = new List<IObserver<InventoryItem>>();
        }

        public IDisposable Subscribe(IObserver<InventoryItem> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }

            return new Unsubscriber();
        }

        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            foreach (var observer in Observers)
            {
                observer.OnNext(inventoryItem);
            }

            InventoryItems.Add(inventoryItem);
        }

        public void RemoveInventoryItem(InventoryItem inventoryItem)
        {
            foreach (var observer in Observers)
            {
                observer.OnNext(inventoryItem);
            }
            InventoryItems.Remove(inventoryItem);
        }
    }

    class Unsubscriber : IDisposable
    {
        public Unsubscriber()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
