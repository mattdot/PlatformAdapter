using NUnit.Framework;
using PlatformAdapter.Phone8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PlatformAdapter.Tests.Phone8
{
    [TestFixture]
    public class AppInfoTest
    {
        [Test]
        public async Task TestLinkerStamp()
        {
            var dt = await AppInfo.RetrieveLinkerTimestamp(typeof(AppInfoTest).GetTypeInfo().Assembly);

            Assert.IsNotNull(dt);
        }
    }
}
