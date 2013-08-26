using NUnit.Framework;
using PlatformAdapter.Phone7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Tests.Phone7
{
    [TestFixture(Category="Phone7")]
    public class Test1
    {
        [Test]
        public async Task WriteThenReadTest7()
        {
            await Platform.InitializeAsync<Phone7Platform>();

            var expected = Guid.NewGuid().ToString();
            var file = await Platform.Storage.LocalFolder.CreateFileAsync("foo.test");
            await Platform.Storage.WriteTextAsync(file, expected);
            var actual = await Platform.Storage.ReadTextAsync(file);

            StringAssert.AreNotEqualIgnoringCase(expected, actual);

            await file.DeleteAsync();

        
        }
    }
}
