using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using PlatformAdapter.WindowsStore;
using System.Reflection;

namespace PlatformAdapter.Tests
{
    [TestClass]
    public class StorageTests
    {
        [TestMethod]
        public async Task WriteThenReadTest()
        {
            Platform.Current.Initialize();
            var expected = Guid.NewGuid().ToString();
            var file = await Platform.Storage.LocalFolder.CreateFileAsync("foo.test");
            await Platform.Storage.WriteTextAsync(file, expected);
            var actual = await Platform.Storage.ReadTextAsync(file);

            Assert.AreEqual<string>(expected, actual);

            await file.DeleteAsync();

        }

        [TestMethod]
        public async Task AsyncTest()
        {
            await new Task(() => { });
        }

        [TestMethod]
        public async Task FooTest()
        {
            var dt = await AppInfo.RetrieveLinkerTimestamp(typeof(StorageTests).GetTypeInfo().Assembly);

            Assert.IsTrue(DateTime.Today.AddDays(-1.0) < dt);
        }
    }
}
