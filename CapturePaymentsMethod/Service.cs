using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapturePaymentsMethod
{
    public class Service
    {
        

        public void ExecuteJob()
        {
            using (var context = new YourDbContext())
            {
                var currentDate = DateTime.Now;
                var a = context.Games.ToList();
                var games = context.Games.Where(g => g.FullyPaid == false).ToList();

                foreach (var game in games)
                {
                    Console.WriteLine(game.CourseName);
                    if (game.Date - currentDate <= TimeSpan.FromMinutes(90))
                    {

                        
                        var gameUsers = context.GameUsers.Where(g => g.GameId == game.Id);

                        var payedAmount = gameUsers.Sum(x => x.Price);

                        var toPayAmount = game.Price - payedAmount;

                        StripeConfiguration.ApiKey = "sk_test_51NKyz0A23RRenKg4OVuyrkGw8xoCZ7iPiHfqdJ6k7I5rqELEyhcDPiqspS3ZDaX4uC7iEhgRWuMv86DL4haTl7zL00IFLIp6Nk";

                        var options = new PaymentIntentCaptureOptions
                        {
                            AmountToCapture = (int)(toPayAmount * 100),
                        };

                        var service = new PaymentIntentService();
                        var paymentIntent = service.Capture(game.CreatorUserClientSecret, options);
                    }
                }
            }
        }


    }
}
