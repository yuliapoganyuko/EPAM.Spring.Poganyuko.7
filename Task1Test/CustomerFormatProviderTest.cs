using System;
using System.Collections.Generic;
using NUnit.Core;
using Task1Logic;
using NUnit.Framework;

namespace Task1Test
{
    public class CustomerFormatProviderTest
    {
        public IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("NPR").Returns($"Customer record: John Smit, +1 (425) 555-0100, {10000000:N}");
                yield return new TestCaseData("").Returns($"Customer record: John Smit, +1 (425) 555-0100, {10000000:N}");
                yield return new TestCaseData(null).Returns($"Customer record: John Smit, +1 (425) 555-0100, {10000000:N}");
                yield return new TestCaseData("NRP").Returns($"Customer record: John Smit, {10000000:N}, +1 (425) 555-0100");
                yield return new TestCaseData("N").Returns("Customer record: John Smit");
                yield return new TestCaseData("Nup").Returns("Customer record: JOHN SMIT");
                yield return new TestCaseData("Nlow").Returns("Customer record: john smit");
                yield return new TestCaseData("P").Returns("Customer record: +1 (425) 555-0100");
                yield return new TestCaseData("R").Returns($"Customer record: {10000000:N}");
                yield return new TestCaseData("NR").Returns($"Customer record: John Smit, {10000000:N}");
                yield return new TestCaseData("NP").Returns("Customer record: John Smit, +1 (425) 555-0100");
                yield return new TestCaseData("smth wrong").Throws(typeof(FormatException));
            }
        }

        [Test, TestCaseSource("TestData")]
        public static string Format_Formats_Test(string format)
        {
            format = "{0:" + format + "}";
            return string.Format(new CustomerFormatProvider(), format, new Customer("John Smit", "+1 (425) 555-0100", 10000000));
        }

        [TestCase(null, ExpectedException = typeof(FormatException))]
        public static string Format_Data_Test(object arg)
        {
            return string.Format(new CustomerFormatProvider(), "{0:N}", arg);
        }

        [TestCase(null, Result = null)]
        public static object GetFormat_Test(Type type)
        {
            CustomerFormatProvider formatter = new CustomerFormatProvider();
            return formatter.GetFormat(type);
        }
    }
}
