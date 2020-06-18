using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Reflection;
using System.Net.Http.Headers;
using Xunit;
using Internship_Task1;

namespace UnitTestProject1
{
    public class Test1
    {
        [Fact]
        public void test()
        {
            // create an object to test it 
            var configuration = new Configuration(2, "www.training.com", new[] { "192.168.1.8", "192.168.1.2" });
            // Actual result
           var actualResult = Internship_Task1.Configuration.JsonStringFormat(configuration);
           var expectedResult= "\"{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\",\"192.168.1.2\"]}\"";
            Assert.Equals(expectedResult, actualResult);

        }

      
    
    }

}
