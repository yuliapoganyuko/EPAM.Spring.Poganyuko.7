using System;

namespace Task1Logic
{
    /// <summary>
    /// Provides formatting of a Customer instance.
    /// </summary>
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        #region Public methods

        /// <summary> Converts a Customer instance into equal string using formatting.</summary>
        /// <param name="format"> Format string</param>
        /// <param name="arg"> Object to format</param>
        /// <param name="formatProvider"> Object of format provider</param>
        /// <returns> String format of Customer instance</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!formatProvider.Equals(this))
                throw new ArgumentException();

            if (string.IsNullOrEmpty(format))
                format = "NPR";

            Customer customer = arg as Customer;
            if (ReferenceEquals(customer, null))
                throw new FormatException();

            switch (format)
            {
                case "NPR":
                    return $"Customer record: {customer.Name}, {customer.ContactPhone}, {customer.Revenue:N}";
                case "NRP":
                    return $"Customer record: {customer.Name}, {customer.Revenue:N}, {customer.ContactPhone}";
                case "N":
                    return $"Customer record: {customer.Name}";
                case "Nup":
                    return $"Customer record: {customer.Name.ToUpperInvariant()}";
                case "Nlow":
                    return $"Customer record: {customer.Name.ToLowerInvariant()}";
                case "P":
                    return $"Customer record: {customer.ContactPhone}";
                case "R":
                    return $"Customer record: {customer.Revenue:N}";
                case "NP":
                    return $"Customer record: {customer.Name}, {customer.ContactPhone}";
                case "NR":
                    return $"Customer record: {customer.Name}, {customer.Revenue:N}";
                default:
                    throw new FormatException();
            }
        }

        /// <summary>
        /// Gets object for type object formatting.
        /// </summary>
        /// <param name="formatType"> Type</param>
        /// <returns> Object instanse of <paramref name="formatType" /> or null</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        #endregion
    }
}
