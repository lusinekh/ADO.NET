using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Util-1 More namespaces.  
using System.Configuration;

namespace WindowsFormsApplication2
{
    internal class Utility
    {

        //Get the connection string from App config file.  
        internal static string GetConnectionString()
        {
            //Util-2 Assume failure.  
            string returnValue = null;

            //Util-3 Look for the name in the connectionStrings section.  
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["SimpleDataApp.Properties.Settings.connString"];

            //If found, return the connection string.  
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }



}


