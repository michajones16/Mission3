using System;
using System.Collections.Generic;
using System.Text;

namespace Mission3
{
    internal class FoodItem
    {
        private string foodName;
        private string foodCategory;
        private int foodQuantity;
        private DateTime foodExpDate;

        public FoodItem(string name, string category, int quantity, DateTime expDate)
        {
            foodName = name;
            foodCategory = category;
            foodQuantity = quantity;
            foodExpDate = expDate;
        }
    }
}
