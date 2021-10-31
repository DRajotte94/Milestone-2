using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // create several objects for testing purposes
            Bike bike1 = new Bike("Diamondback", "small", "full", "red", 2);
            Bike bike2 = new Bike("E-Caliber", "medium", "rear", "black", 1);
            Bike bike3 = new Bike("Eclipse", "small", "rear", "white", 1);
            Bike bike4 = new Bike("Diamondback", "medium", "full", "black", 2);

            // inventory list of bikes (several bikes pre loaded into list for testing)
            List<Bike> inventory = new List<Bike>();
            inventory.Add(bike1);
            inventory.Add(bike2);
            inventory.Add(bike3);
            inventory.Add(bike4);

            Boolean loop = true;
            while (loop == true)
            {
                int input;
                Console.WriteLine("\n-------------------------------------------\n");
                Console.WriteLine("Enter one of the following options: ");
                Console.WriteLine("1: View Inventory");
                Console.WriteLine("2: Add Item");
                Console.WriteLine("3: Remove Item");
                Console.WriteLine("4: Adjust Item Quantity");
                Console.WriteLine("5: Search Inventory");
                Console.WriteLine("0: Exit");
                Console.Write("Enter: ");

                if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 5) // returns error if input is not a valid int
                {
                    // provide controls based on input
                    if (input == 1) // view inventory
                    {
                        if (inventory.Count <= 0)
                        {
                            Console.WriteLine("\nInventory is empty");
                        }
                        else
                        {
                            int count = 1;
                            foreach (Bike i in inventory)
                            {
                                Console.Write($"\n{count}: {i.ToString()}");
                                count++;
                            }
                        }
                    }
                    else if (input == 2) // add item
                    {
                        // get variables to build object
                        Console.Write("\nEnter item name: ");
                        String name = Console.ReadLine();
                        Console.Write("Enter item size: ");
                        String size = Console.ReadLine();
                        Console.Write("Enter item suspension: ");
                        String suspension = Console.ReadLine();
                        Console.Write("Enter item color: ");
                        String color = Console.ReadLine();
                        Console.Write("Enter item quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        // build object
                        Bike bike = new Bike(name, size, suspension, color, quantity);

                        // add to inventory list
                        InventoryManager.addItem(inventory, bike);
                    }
                    else if (input == 3) // remove item
                    {
                        Console.Write("\nEnter the inventory # of the item you want to remove: ");
                        int item;
                        if (int.TryParse(Console.ReadLine(), out item) && item > 0 && item <= inventory.Count) 
                        {
                            // remove item from list
                            InventoryManager.removeItem(inventory, item);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                        
                    }
                    else if (input == 4) // adjust quantity
                    {
                        Console.Write("\nEnter the inventory # of the item: ");
                        int item;
                        if (int.TryParse(Console.ReadLine(), out item) && item > 0 && item <= inventory.Count)
                        {
                            // edit the quantity of the item
                            InventoryManager.editQuantity(inventory, item);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                    else if (input == 5) // search inventory
                    {
                        Console.WriteLine("\nSelect search criteria: ");
                        Console.WriteLine("1: Name");
                        Console.WriteLine("2: Size");
                        Console.WriteLine("3: Suspension");
                        Console.WriteLine("4: Color");
                        Console.Write("Enter: ");

                        int entry = 0;
                        if (int.TryParse(Console.ReadLine(), out entry) && entry > 0 && entry <= 5)
                        {
                            if (entry == 1) // name
                            {
                                // get name being searched
                                Console.Write("\nEnter name: ");
                                String name = Console.ReadLine();

                                // call name search method
                                InventoryManager.searchName(inventory, name);
                            }
                            if (entry == 2) // size
                            {
                                // get size being searched
                                Console.Write("\nEnter size (small, medium, large): ");
                                String size = Console.ReadLine();

                                // call name search method
                                InventoryManager.searchSize(inventory, size);
                            }
                            if (entry == 3) // suspension
                            {
                                // get size being searched
                                Console.Write("\nEnter suspension (rear, full): ");
                                String suspension = Console.ReadLine();

                                // call name search method
                                InventoryManager.searchSuspension(inventory, suspension);
                            }
                            if (entry == 4) // color
                            {
                                // get size being searched
                                Console.Write("\nEnter color: ");
                                String color = Console.ReadLine();

                                // call name search method
                                InventoryManager.searchColor(inventory, color);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input"); // invalid input error handling
                        }
                    }
                    else if (input == 0) // end loop
                    {
                        loop = false;
                    }
                }
                else // invalid input error handling
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }

    class InventoryManager
    {
        // method for adding item to list
        public static void addItem(List<Bike> list, Bike bike)
        {
            // if item is not present on list, add
            if (!list.Contains(bike))
            {
                list.Add(bike);
            }
        }

        // method for removing item from list
        public static void removeItem(List<Bike> list, int item)
        {
            Bike bike = list[item - 1];
            list.Remove(bike);
        }

        // method for restocking items
        public static void editQuantity(List<Bike> list, int item)
        {
            Bike bike = list[item];
            Console.Write("\nEnter the new quantity: ");

            int quantity;
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
            {
                bike.setQuantity(quantity);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        // method for searching by name
        public static void searchName(List<Bike> list, String name)
        {
            int i = 0;
            foreach (Bike bike in list)
            {
                // compare list items name to the searched name
                if (string.Equals(list[i].getName(), name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i + 1}: {bike.ToString()}");
                }

                i++;
            }
        }

        // method for searching by size
        public static void searchSize(List<Bike> list, String size)
        {
            int i = 0;
            foreach (Bike bike in list)
            {
                if (string.Equals(list[i].getSize(), size, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i + 1}: {bike.ToString()}");
                }

                i++;
            }
        }

        // method for searching by suspension
        public static void searchSuspension(List<Bike> list, String suspension)
        {
            int i = 0;
            foreach (Bike bike in list)
            {
                if (string.Equals(list[i].getSuspension(), suspension, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i + 1}: {bike.ToString()}");
                }

                i++;
            }
        }

        // method for searching by color
        public static void searchColor(List<Bike> list, String color)
        {
            int i = 0;
            foreach (Bike bike in list)
            {
                if (string.Equals(list[i].getColor(), color, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i + 1}: {bike.ToString()}");
                }

                i++;
            }
        }
    }

    class Bike // class for creating and managing the bike object
    {
        // variables representing the bike
        private String name, size, suspension, color;
        private int quantity;

        // constructor
        public Bike(String name, String size, String suspension, String color, int quantity)
        {
            this.name = name;
            this.size = size;
            this.suspension = suspension;
            this.color = color;
            this.quantity = quantity;
        }

        // get and set name
        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        // get and set size
        public String getSize()
        {
            return size;
        }

        public void setSize(String size)
        {
            this.size = size;
        }

        // get and set suspension
        public String getSuspension()
        {
            return suspension;
        }

        public void setSuspension(String suspension)
        {
            this.suspension = suspension;
        }

        // get and set color
        public String getColor()
        {
            return color;
        }

        public void setColor(String color)
        {
            this.color = color;
        }

        // get and set quantity
        public int getQuantity()
        {
            return quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        // string value of object
        public override string ToString()
        {
            return this.getName() + ", " + this.getSize() + ", " + this.getSuspension() + ", " + this.getColor() + ", QTY: " + this.getQuantity();
        }
    }
}
