using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    abstract class ClubCard
    {
        // Attributes
        protected int QRcode;
        protected string Firstname;
        protected string Secondname;
        protected int TotalPoints;

        // Operations
        public string FirstName()
        {
            return Firstname;

            public string SecondName()
            {
                return Secondname;
            }

            public int QRcode()
            {
                return QRcode;
            }

            public int TotalPoints()
            {
                return TotalPoints;
            };

            public void SetPoints(int NewPoints)
            {
                TotalPoints = NewPoints;
            }


        }
    }
}