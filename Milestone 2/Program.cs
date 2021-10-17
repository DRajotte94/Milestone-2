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
            // create two objects for testing purposes
            Bike bike1 = new Bike("Diamondback", "small", "full", "red", 2);
            Bike bike2 = new Bike("E-Caliber", "medium", "rear", "black", 1);

            // Print bike 1 to console, edit it, then print again
            Console.WriteLine("Bike 1: " + bike1.ToString());
            bike1.setName("Diamonback Bolt");
            bike1.setColor("blue/white");
            bike1.setQuantity(1);
            Console.WriteLine("Bike 1: " + bike1.ToString());

            Console.WriteLine(" "); // blank line to seperate objects

            // Print bike 1 to console, edit it, then print again
            Console.WriteLine("Bike 2: " + bike2.ToString());
            bike2.setSize("small");
            bike2.setSuspension("full");
            Console.WriteLine("Bike 2: " + bike2.ToString());

            // prevents console from closing until enter key is pressed
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
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
