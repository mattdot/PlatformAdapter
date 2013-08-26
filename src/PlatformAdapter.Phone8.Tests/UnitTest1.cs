using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;

namespace PlatformAdapter.Phone8.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task WriteThenReadTest()
        {
            Platform.Current.Initialize();
            var expected = "hello world";
            var file = await Platform.Storage.LocalFolder.CreateFileAsync("foo.test");
            await Platform.Storage.WriteTextAsync(file, expected);
            var actual = await Platform.Storage.ReadTextAsync(file);

            Assert.AreEqual<string>(expected, actual);

            await file.DeleteAsync();

        }

        [TestMethod]
        public async Task TestTimestamp()
        {
            var ts = await AppInfo.RetrieveLinkerTimestamp(typeof(UnitTest1).GetTypeInfo().Assembly);

            Assert.IsNotNull(ts);
        }
    }
}
