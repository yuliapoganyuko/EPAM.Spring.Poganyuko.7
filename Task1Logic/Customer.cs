using System;

namespace Task1Logic
{
    public class Customer
    {
        #region Properties

        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public double Revenue { get; set; }

        #endregion


        #region Constructors

        public Customer(string name, string phone, double revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }

        public Customer() : this("Undefined name", "Undefined phone", 0){}

        #endregion
    }
}
