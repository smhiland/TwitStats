using System;
using System.Configuration;
using System.Timers;
using TwitStats;
using TwitStats.Stats;
using TwitStream.Core;

namespace TwitConsole
{
    class Program
    {
        private static Timer aTimer;
        private static Harvester _harvester;
        static void Main(string[] args)
        {
            string userKey = ConfigurationManager.AppSettings["UserKey"];
            string userSecret = ConfigurationManager.AppSettings["UserSecret"];
            string userBearer = ConfigurationManager.AppSettings["UserBearer"];

            ICredentials creds = new TwitAPICredentials()
            {
                Key = userKey,
                Secret = userSecret,
                BearerToken = userBearer
            }
            ;
           
            _harvester = new(creds);
            _harvester
                .RegisterStat(new TotalStat())
                .RegisterStat(new AverageReceived())
                .RegisterStat(new PercentContainUrl())
                .RegisterStat(new PercentContainPhotoUrl())
                .RegisterStat(new PercentEmojis())
                .RegisterStat(new TopDomains())
                .RegisterStat(new TopHashtags())
                .RegisterStat(new TopEmojis())
                ;

            SetTimer();
            Console.WriteLine("Start listening..");

            _harvester.Start();

            Console.ReadLine();

            aTimer.Stop();
            aTimer.Dispose();
            _harvester.Stop();
            _harvester.Dispose();
            _harvester = null;

            Console.WriteLine("Stop listening. Hit Enter to end.");

            Console.ReadLine();
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string result = _harvester.GetStatsResults();
            Console.WriteLine(result);
        }
    }
}
