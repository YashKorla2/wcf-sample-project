using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreWCF;


namespace WcfServiceLibrary.SampleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding wSHttpBinding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress(@"http://localhost:8743/testservice/WcfServiceLibrary");
            ChannelFactory<IService1> channelFactory = new ChannelFactory<IService1>(wSHttpBinding, endpointAddress);
            IService1 proxyObject = channelFactory.CreateChannel();

            string returnValue = proxyObject.GetData(50);
            string returnValue3 = proxyObject.GetData(555);

            Console.WriteLine();
        }
    }
}
