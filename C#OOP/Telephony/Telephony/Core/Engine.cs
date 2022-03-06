using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Engine
    {
        private Smartphone smartphone;
        private IList<string> phoneNumbers;
        private IList<string> url;
        public Engine()
        {
            this.smartphone = new Smartphone();
            this.phoneNumbers = new List<string>();
            this.url = new List<string>();
        }
        public void Run()
        {
            this.phoneNumbers = Console.ReadLine().Split().ToList();
            this.url = Console.ReadLine().Split().ToList();
            callPhoneNUmber();
            browseWeb();
        }

        private void callPhoneNUmber()
        {
            foreach (string phoneNumber in this.phoneNumbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(phoneNumber));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void browseWeb()
        {
            foreach (var item in url)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(item));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);                
                }
            }
        }
    }
}
