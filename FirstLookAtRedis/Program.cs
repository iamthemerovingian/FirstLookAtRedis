using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLookAtRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (IRedisNativeClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            //{
            //    client.Set("urn:messages:1", Encoding.UTF8.GetBytes("Hello C# World"));
            //}

            //using (IRedisNativeClient client = new RedisClient())
            //{
            //    string result = Encoding.UTF8.GetString(client.Get("urn:messages:1"));

            //    Console.WriteLine($"Mesage: {result}");
            //    Console.ReadLine();
            //}

            using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            {
                var customerNams = client.Lists["urn:customernames"];
                customerNams.Clear();
                customerNams.Add("Joe");
                customerNams.Add("Mary");
                customerNams.Add("Bob");
                customerNams.Add("Mili");

                customerNams.Push("Pusehd");
                customerNams.Append("Appended");
            }

            using (IRedisClient client = new RedisClient())
            {
                var customerNames = client.Lists["urn:customernames"];
                foreach (var item in customerNames)
                {
                    Console.WriteLine(item);
                }

            }
            Console.ReadLine();
        }
    }
}
