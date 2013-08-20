using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace PlatformAdapter.Tests
{
    [TestClass]
    public class StorageTests
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
        public void FooTest()
        {
        }
    }
}
