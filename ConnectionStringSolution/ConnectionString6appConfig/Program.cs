using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConnectionString6appConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new ConnectionStringSettings();
            settings.Name = "NameOfMyConnectionStringSettings";
            settings.ConnectionString = "MyConnectionString";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(settings);
            config.Save();

            var section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            if(section.SectionInformation.IsProtected) section.SectionInformation.UnprotectSection(); //cipher section
            else section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider"); //uncipher section

            config.Save();

            Console.WriteLine($"Protected?: {section.SectionInformation.IsProtected}");
            Console.WriteLine(ConfigurationManager.ConnectionStrings["NameOfMyConnectionStringSettings"].ConnectionString);

            Console.WriteLine(ConfigurationManager.ConnectionStrings["NameOfMyConnectionStringSettings"].ConnectionString);

            Console.ReadKey();
        }
    }
}
