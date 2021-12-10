using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    abstract class Product
    {
        // Attributes
        protected int barcode;
        protected string name;
        protected int weightInGrams;

        // Operations
        public string GetName()
        {
            return name;
        }

        public int GetBarcode()
        {
            return barcode;
        }

        public int GetWeight()
        {
            return weightInGrams;
        }

        public void SetWeight(int newWeight)
        {
            weightInGrams = newWeight;
        }

        public abstract int CalculatePrice();
    }

    class PackagedProduct : Product
    {
        // Attributes
        private int priceInPence;

        // Constructor
        public PackagedProduct(int newBarcode, string newName, int newPriceInPence, int newWeightInGrams)
        {
            barcode = newBarcode;
            name = newName;
            priceInPence = newPriceInPence;
            weightInGrams = newWeightInGrams;
        }

        //Operations
        public override int CalculatePrice()
        {
           return priceInPence;
        }
    }
}