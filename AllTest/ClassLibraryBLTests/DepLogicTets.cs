using System.Threading;
using ClassLibraryBL;
using NUnit.Framework;

namespace ClassLibraryBLTests
{
    [TestFixture]
    public class DepLogicTets
    {
        [Test]
        public void Work()
        {
            var context = SynchronizationContext.Current;
            var depLogic = new DepLogic(context);
        }
    }
}
