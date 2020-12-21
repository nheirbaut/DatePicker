using System.Collections;
using System.Collections.Generic;

namespace DatePicker.Domain.UnitTests.Helpers
{
    public class InvalidNamesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { " " };
            yield return new object[] { "\t" };
            yield return new object[] { "\r" };
            yield return new object[] { "\n" };
            yield return new object[] { " \t" };
            yield return new object[] { " \r" };
            yield return new object[] { " \n" };
            yield return new object[] { "\t " };
            yield return new object[] { "\r " };
            yield return new object[] { "\n " };
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}