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

            //using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            //{
            //    var customerNams = client.Lists["urn:customernames"];
            //    customerNams.Clear();
            //    customerNams.Add("Joe");
            //    customerNams.Add("Mary");
            //    customerNams.Add("Bob");
            //    customerNams.Add("Mili");

            //    customerNams.Push("Pusehd");
            //    customerNams.Append("Appended");
            //}

            //using (IRedisClient client = new RedisClient())
            //{
            //    var customerNames = client.Lists["urn:customernames"];
            //    foreach (var item in customerNames)
            //    {
            //        Console.WriteLine(item);
            //    }

            //}

            //long lastId = 0;

            //using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            //{
            //    var customerClient = client.As<Customer>();
            //    var customer = new Customer
            //    {
            //        Id = customerClient.GetNextSequence(),
            //        Address = "123 Main Street.",
            //        Name = "Bob Green",
            //        Orders = new List<Order> { new Order { OrderNumber = "AB 123" }, new Order { OrderNumber = "AB 456" } }
            //    };

            //    var storedCustomer = customerClient.Store(customer);
            //    lastId = storedCustomer.Id;
            //}

            //using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            //{
            //    var customerClient = client.As<Customer>();
            //    var customer = customerClient.GetById(lastId);

            //    Console.WriteLine($"Customer Name: {customer.Name}, Id: {customer.Id}, Address: {customer.Address}, Orders: ");
            //    foreach (var item in customer.Orders)
            //    {
            //        Console.WriteLine(item.OrderNumber);
            //    }
            //}

            //using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            //{
            //    var transaction = client.CreateTransaction();
            //    transaction.QueueCommand(c => c.Set("abc", 1));
            //    transaction.QueueCommand(c => c.Increment("abc", 1));
            //    transaction.Commit();
            //}

            //using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            //{
            //    int result = client.Get<int>("abc");
            //    Console.WriteLine(result);
            //}

            using (IRedisClient client = new RedisClient(new RedisEndpoint { Host = "117.20.40.28", Port = 6379, Password = "Yellow889" }))
            {
                //IRedisSubscription clientSubscription = client.CreateSubscription();

                //clientSubscription.SubscribeToChannels("debug");

                //clientSubscription.OnMessage = (channel, message) =>
                //{
                //    Console.WriteLine("Received '{0}' from channel '{1}'", message, channel);
                //};

                //Task.Run(() =>
                //{
                //    client.PublishMessage("debug", "Hello C#!!");
                //});

                var sub = client.CreateSubscription();

                sub.OnMessage = (channel, message) =>
                {
                    Console.WriteLine($"I got a message: {message} from {channel} ");
                };

                sub.SubscribeToChannels("news");

                Console.ReadLine();
            }
        }
    }

    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public string OrderNumber { get; set; }
    }
}
