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

        private SelfCheckout selfCheckout;

        // Operations
        public int GetCurrentWeight()
        {
            return weight;
        }

        public bool IsWeightOk()
        {
            //set allowed difference to 10% of the current items weight
            if(selfCheckout.GetCurrentProduct() != null)
            {
                allowedDifference = selfCheckout.GetCurrentProduct().GetWeight() / 10;
            }

            //check if weight is too low
            if (weight < (expectedWeight - allowedDifference))
            {
                return false;
            }
            //check if scales too high
            else if (weight > (expectedWeight + allowedDifference))
            {
                return false;
            }

            return true;
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
            expectedWeight = weight;
            selfCheckout.BaggingAreaWeightChanged();
        }

        public void Reset()
        {
            weight = 0;
            expectedWeight = 0;
            allowedDifference = 0;
        }

        public void LinkToSelfCheckout(SelfCheckout sc)
        {
            selfCheckout = sc;
        }

        // NOTE: in reality the difference wouldn't be passed in here
        // the scale would detect the change and notify the self checkout
        public void WeightChangeDetected(int difference)
        {
            weight += difference;
            selfCheckout.BaggingAreaWeightChanged();
        }
    }
}