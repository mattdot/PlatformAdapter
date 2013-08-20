using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter
{
    public interface ICryptographyAdapter : IPlatformAdapter
    {
        string Encrypt(string secretKey, string message);
        string Decrypt(string secretKey, string message);
    }
}
