using Microsoft.AspNetCore.Mvc;
using ML.Models;
using System.Diagnostics;

namespace ML.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var modelBuilder = new ModelBuilder();
            modelBuilder.LoadModel("trainedModel.zip");
            var modelInput = new ModelInput()
            {
                Age = 24,
                CreditAmount = 9055,
                Duration = 30
            };
            var prediction = modelBuilder?.Predict(modelInput);
            Console.WriteLine($"\nExample input class is {prediction?.Prediction.ToUpper()}!");

            modelInput.Class = prediction?.Prediction.ToString();

            //var modelBuilder = new ModelBuilder();
            //modelBuilder.LoadModel("trainedModel.zip");

            //var modelInput = new ModelInput()
            //{
            //    Age = 300,
            //    CreditAmount = 100000,
            //    Duration = 120
            //};

            //var prediction = modelBuilder?.Predict(modelInput);
            //Console.WriteLine($"\nExample input class is {prediction?.Prediction.ToUpper()}!");

            //string? inputString;
            //float inputValue;

            //Console.WriteLine("\nInput data:");

            //Console.Write("Age in months:\t\t");
            //inputString = Console.ReadLine();
            //while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
            //{
            //    Console.WriteLine("Incorrect input. Try again:");
            //    inputString = Console.ReadLine();
            //}
            //modelInput.Age = inputValue;

            //Console.Write("Credit Amount:\t\t");
            //inputString = Console.ReadLine();
            //while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
            //{
            //    Console.WriteLine("Incorrect input. Try again:");
            //    inputString = Console.ReadLine();
            //}
            //modelInput.CreditAmount = inputValue;

            //Console.Write("Duration in months:\t");
            //inputString = Console.ReadLine();
            //while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
            //{
            //    Console.WriteLine("Incorrect input. Try again:");
            //    inputString = Console.ReadLine();
            //}
            //modelInput.Duration = inputValue;

            //prediction = modelBuilder?.Predict(modelInput);
            //Console.WriteLine($"\nYour credit application class is {prediction?.Prediction.ToUpper()}!");


            return View(modelInput);
        }


        [HttpPost]
        public IActionResult Index(ModelInput mi)
        {
            var modelBuilder = new ModelBuilder();
            modelBuilder.LoadModel("trainedModel.zip");
            var modelInput = new ModelInput()
            {
                Age = mi.Age,
                CreditAmount = mi.CreditAmount,
                Duration = mi.Duration
            };
            var prediction = modelBuilder?.Predict(modelInput);

            mi.Class = prediction?.Prediction.ToString();

            return View("Index",mi);


        }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}