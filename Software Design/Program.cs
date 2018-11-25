using Software_Design.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Design
{
    class Program
    {
        static ObservableInventory observableInventory;

        static void Main(string[] args)
        {
            observableInventory = new ObservableInventory();

            AddDefaultItems();
            ShowAddInventoryObserver();
            ShowHomescreen();
        }

        static void ShowAddInventoryObserver()
        {
            Console.WriteLine("Hello, what is your name?");

            string name;
            bool valid;
            do
            {
                Console.Write("Name:\t");
                name = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(name);
                if (!valid)
                {
                    Console.WriteLine("Your name cannot by empty");
                }

            } while (!valid);

            InventoryObserver inventoryObserver = new InventoryObserver(name);

            observableInventory.Subscribe(inventoryObserver);
        }

        static void ShowInventoryItems()
        {
            Console.WriteLine("====Items====");
            Console.WriteLine("#\tPrice\tItem");

            int i = 1;
            foreach (InventoryItem inventoryItem in observableInventory.InventoryItems)
            {
                Console.WriteLine(i++ + ":\t" + inventoryItem.Price + "\t" + inventoryItem.Title);
            }
        }

        static void AddDefaultItems()
        {
            observableInventory.AddInventoryItem(new InventoryItem { Title = "Football", Price = 10.50m });
            observableInventory.AddInventoryItem(new InventoryItem { Title = "Basketball", Price = 6m });
        }

        static void ShowAddItemForm()
        {
            Console.WriteLine("Please enter the info of the item you are about to add");

            bool validTitle;
            string titleInput;
            do
            {
                Console.Write("Title:\t");

                titleInput = Console.ReadLine();

                validTitle = !string.IsNullOrWhiteSpace(titleInput);
                if (!validTitle)
                {
                    Console.WriteLine("Title cannot be empty");
                }
            } while (!validTitle);

            string priceInput;
            decimal price;
            bool validPrice;
            do
            {
                Console.Write("Price:\t");
                priceInput = Console.ReadLine();

                validPrice = decimal.TryParse(priceInput, out price);

                if (!validPrice)
                {
                    Console.WriteLine("Sorry, that doesn't seem to be  a number");
                }
            } while (!validPrice);

            Console.WriteLine(titleInput + " Added!");
            observableInventory.AddInventoryItem(new InventoryItem { Title = titleInput, Price = price });
            return;
        }

        static void ShowDeleteItemForm()
        {

            if (!observableInventory.InventoryItems.Any())
            {
                Console.WriteLine("Silly you, you can't delete an item if you have no items");
                return;
            }

            ShowInventoryItems();
            Console.WriteLine("To delete an item enter the number of that item");

            int id;

            do
            {
                Console.Write("#:\t");
                string input = Console.ReadLine();
                if (!Int32.TryParse(input, out id))
                {
                    Console.WriteLine("Please input a number");
                }
            } while (id == 0);

            // human readable numbers so subtract 1 for the actual index
            id--;

            if (id <= observableInventory.InventoryItems.Count() && id >= 0)
            {
                InventoryItem deletedItem = observableInventory.InventoryItems.ElementAt(id);
                Console.WriteLine("Deleted: " + deletedItem.Title);
                observableInventory.RemoveInventoryItem(deletedItem);
            }
            else
            {
                Console.WriteLine("That is not a valid item number");
                ShowDeleteItemForm();
            }

        }

        static void ShowHomescreen()
        {
            ConsoleKeyInfo pressedKey;
            do
            {
                ShowInventoryItems();

                Console.WriteLine();

                Console.WriteLine("Press 1 to add an item");
                Console.WriteLine("Press 2 to delete an item");
                Console.Write("Press 0 to exit \t");



                pressedKey = Console.ReadKey();
                Console.WriteLine("\n");

                if (pressedKey.Key == ConsoleKey.D1)
                {
                    ShowAddItemForm();
                    Console.WriteLine("\n");
                }
                else if (pressedKey.Key == ConsoleKey.D2)
                {
                    ShowDeleteItemForm();
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("That was not a valid Key!\n");
                }
            } while (pressedKey.Key != ConsoleKey.D0);
        }
    }
}
