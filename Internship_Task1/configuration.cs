using System;
using System.Reflection;

namespace Internship_Task1
{
    public class Configuration
    {
        public int Version { get; }
        public string DomainName { get; }
        public string[] IpAddresses { get; }

        public Configuration(int version, string domainName, string[] ipAddresses)
        {
            Version = version;
            DomainName = domainName;
            IpAddresses = ipAddresses;
        }
        static void Main(string[] args)
        {
            var configuration = new Configuration(2, "www.training.com", new[] { "192.168.1.8", "192.168.1.2" });
           var result= JsonStringFormat(configuration);

        }


        public static String JsonStringFormat(Configuration configuration)

        {
            // to check if the object is null or not 
            if (configuration is null)
                return null;

            Type type = configuration.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();

            // local variables to use it inside the methods
            string domainName = "";
            string[] ipAddress;
            string ipAddresses = "";
            int version = 0;
          
       
            foreach (var d in propertyInfo)
                if (d.GetIndexParameters().Length == 0)
                {
                    // To check if the version is an integer 
                    if (d.PropertyType.Name.Equals("int") && d.Name.Equals("Version"))
                    {
                        version = (int)d.GetValue(configuration);
                    }

                    // to check if the domain name is String 
                    else if (d.PropertyType.Name.Equals("String") && d.Name.Equals("DomainName"))

                    {

                        domainName = (string)d.GetValue(configuration);
                    }

                    // to check if the IpAddresses is array
                    else if (d.PropertyType.IsArray && d.Name.Equals("IpAddresses"))
                    {
                        ipAddress = (string[])d.GetValue(configuration);
                        ipAddresses = ipAddresses + "[";
                        for (int i = 0; i < ipAddress.Length; i++)
                        {
                            object object1 = ipAddress.GetValue(i);
                            if (i == ipAddress.Length - 1)
                            {
                                ipAddresses = ipAddresses + "\"" + object1 + "\"";

                            }
                            else
                            {
                                ipAddresses = ipAddresses + "\"" + object1 + "\",";
    
                            }

                        }

                        ipAddresses = ipAddresses + "]";

                        string jsonResult = "\"{\"Version\":" + version + ",\"DomainName\":\"" + domainName + "\",\"IpAddresses\":" + ipAddresses + "}\"";
                        return jsonResult;
                    }
                   
                }
                else
                    return "There is no result";
            return " There is no result";
        }




    }
}




