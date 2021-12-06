using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class ScannedProducts
    {
        // Attributes
        private List<Product> products = new List<Product>();


        // Operations
        public List<Product> GetProducts()
        {
            return products;
        }

        public int CalculateWeight()
        {
            // TO DO
            return 0;
        }

        public int CalculatePrice()
        {
            // TO DO
            return 0;
        }

        public void Reset()
        {
            // TO DO
        }

        public void Add(Product p)
        {
            // TO DO
        }

        public bool HasItems()
        {
            // TO DO
            return false;
        }
    }
}
