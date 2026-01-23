using System;
using System.Collections.Generic;
using System.Text;

namespace Mission3
{
    internal class FoodItem
    {
        public string Name { get; }
        public string Category { get; }
        public int Quantity { get; }
        public DateTime ExpDate { get; }

        public FoodItem(string name, string category, int quantity, DateTime expDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpDate = expDate;
        }
    }

}
