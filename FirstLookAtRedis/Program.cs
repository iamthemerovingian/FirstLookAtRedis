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
            using (IRedisNativeClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            {
                client.Set("urn:messages:1", Encoding.UTF8.GetBytes("Hello C# World"));
            }

            using (IRedisNativeClient client = new RedisClient())
            {
                string result = Encoding.UTF8.GetString(client.Get("urn:messages:1"));

                Console.WriteLine($"Mesage: {result}");
                Console.ReadLine();
            }
        }
    }
}
