using System;
using System.Collections.Generic;
using System.Text;

namespace Mission3
{
    internal class FoodItem
    {
        // Class attributes (get means main class can view attribute)
        public string Name { get; }
        public string Category { get; }
        public int Quantity { get; }
        public DateTime ExpDate { get; }

        // FoodItem constructor
        public FoodItem(string name, string category, int quantity, DateTime expDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpDate = expDate;
        }
    }

}
