using Microsoft.Extensions.Configuration;
using Security.BusinessLogic;
using Security.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSecurity.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestAuthentication();
            //TestEncryption();
        }

        public static void TestAuthentication()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("UserSecurityConnection");

            IUserSecurityDAO db = new UserSecurityDAO(connectionString);
            UserManager userMgr = new UserManager(db);
            DataSecurityCLI cli = new DataSecurityCLI(userMgr);
            cli.Run();
        }

        public static void TestEncryption()
        {
            Encryption.GenerateKeys("public.xml", "private.xml");
            var text = Encryption.GetCipherText("Chris can teach!", "public.xml");
            Console.WriteLine($"Encrypted: {text}");
            text = Encryption.DecryptCipherText(text, "private.xml");
            Console.WriteLine($"Decrypted: {text}");
            Console.ReadKey();
        }
    }
}
