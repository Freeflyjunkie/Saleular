using System.Collections;

namespace Saleular.NUnit.Tests.TestCaseSources
{
    public class GadgetTestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new string[] { "iPhone", "6", "Factory", "64 GB", "Good" };
            yield return new string[] { "iPhone", "6", "Factory", "64 GB", "Good" };
            yield return new string[] { "iPhone", "6", "Factory", "64 GB", "Good" };
        }
    }
}
