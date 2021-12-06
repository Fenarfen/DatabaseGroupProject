using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BaggingAreaScale
    {
        // Attributes
        private int weight;
        private int expectedWeight;
        private int allowedDifference;

        // Operations
        public int GetCurrentWeight()
        {
            return weight;
        }

        public bool IsWeightOk()
        {
            allowedDifference = expectedWeight / 10;

            if (weight > (weight - allowedDifference) && weight < (weight + allowedDifference))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetExpectedWeight()
        {
            return expectedWeight;
        }

        public void SetExpectedWeight(int expected)
        {
            expectedWeight = expected;
        }

        public void OverrideWeight()
        {
            weight = expectedWeight;
        }

        public void Reset()
        {
            weight = 0;
            expectedWeight = 0;
            allowedDifference = 0;
        }

        public void LinkToSelfCheckout(SelfCheckout sc)
        {
            // TO DO
        }

        // NOTE: in reality the difference wouldn't be passed in here
        // the scale would detect the change and notify the self checkout
        public void WeightChangeDetected(int difference)
        {
            //TO DO
        }
    }
}