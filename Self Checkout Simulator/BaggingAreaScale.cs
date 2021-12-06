using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BaggingAreaScale
    {
        // Attributes
       

        // Operations
        public int GetCurrentWeight()
        {
            // TO DO
            return 0;
        }

        public bool IsWeightOk()
        {
            // TO DO
            return false;
        }

        public int GetExpectedWeight()
        {
            // TO DO
            return 0;
        }

        public void SetExpectedWeight(int expected)
        {
            // TO DO
        }

        public void OverrideWeight()
        {
            // TO DO
        }

        public void Reset()
        {
            // TO DO
        }

        public void LinkToSelfCheckout(SelfCheckout sc)
        {
            // TO DO
        }

        // NOTE: in reality the difference wouldn't be passed in here
        // the scale would detect the change and notify the self checkout
        public void WeightChangeDetected(int difference)
        {
            // TO DO
        }
    }
}