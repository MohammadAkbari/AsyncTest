using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using WebApplication1.MongoDb;

namespace WebApplication1.Controllers
{
    public class PerformanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EntityFramework()
        {
            var random = new Random();

            var now = DateTime.Now;

            var item = new SqlServer.Item
            {
                Property1 = random.Next(1000),
                Property2 = random.Next(10000, 100000),
                Property3 = random.Next(100000, 10000000),
                Property4 = GenerateCoupon(20),
                Property5 = GenerateCoupon(1000),
                Property6 = GenerateCoupon(10000),
                Property7 = now.AddDays(random.Next(100)),
                Property8 = now.AddDays(random.Next(10, 1000)),
                Property9 = now.AddDays(random.Next(50, 500))
            };

            using (var itemRepository = new SqlServer.ItemRepository())
            {
                itemRepository.Add(item);

            }


            return Ok();
        }

        public IActionResult MongoDb()
        {
            var itemRepository = new ItemRepository();

            var random = new Random();

            var now = DateTime.Now;

            var item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Property1 = random.Next(1000),
                Property2 = random.Next(10000, 100000),
                Property3 = random.Next(100000, 10000000),
                Property4 = GenerateCoupon(20),
                Property5 = GenerateCoupon(1000),
                Property6 = GenerateCoupon(10000),
                Property7 = now.AddDays(random.Next(100)),
                Property8 = now.AddDays(random.Next(10, 1000)),
                Property9 = now.AddDays(random.Next(50, 500))
            };

            itemRepository.Add(item);

            return Ok();
        }

        public IActionResult RabbitMq()
        {
            var random = new Random();

            var now = DateTime.Now;

            var item = new RabbitMq.Item
            {
                Id = random.Next(10000000),
                Property1 = random.Next(1000),
                Property2 = random.Next(10000, 100000),
                Property3 = random.Next(100000, 10000000),
                Property4 = GenerateCoupon(20),
                Property5 = GenerateCoupon(1000),
                Property6 = GenerateCoupon(10000),
                Property7 = now.AddDays(random.Next(100)),
                Property8 = now.AddDays(random.Next(10, 1000)),
                Property9 = now.AddDays(random.Next(50, 500))
            };

            var itemRepository = new RabbitMq.ItemRepository();

            itemRepository.Add(item);

            return Ok();
        }

        public static string GenerateCoupon(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}