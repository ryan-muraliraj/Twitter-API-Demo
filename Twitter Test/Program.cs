using System;
using Tweetinvi;
using Tweetinvi.Parameters;

namespace Twitter_Test
{
    class Program
    {
        private static string keyword;
        static void Main(string[] args)
        {
            Console.WriteLine(System.DateTime.Now.ToLocalTime() + " - Connecting to Twitter");
            Auth.SetUserCredentials(keys.consumer_api_key, keys.consumer_api_secret, keys.access_token, keys.access_token_secret);
            Console.WriteLine(System.DateTime.Now.ToLocalTime() + " - Connected to Twitter");
            Console.WriteLine(System.DateTime.Now.ToLocalTime() + " - Verifying with Twitter");
            var user = User.GetAuthenticatedUser();
            Console.WriteLine(System.DateTime.Now.ToLocalTime() + " - Ready to accept keyword");
            Console.Write("Keyword: ");
            keyword = Console.ReadLine();
            

            //var tweet = Tweet.PublishTweet("Test from Twitter API");
            //Console.ReadLine();
            

            
            /*
            var userTimelineParameters = new UserTimelineParameters();
            var timelineTweets = Timeline.GetUserTimeline(user, userTimelineParameters);

            foreach (var tweet in timelineTweets)
            {
                Console.WriteLine(tweet.Entities.Medias[0].MediaURL.ToString());
            }
            */

            //Console.WriteLine(timelineTweets);
            //Console.ReadLine();
            
            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(keyword);
            stream.AddTweetLanguageFilter(Tweetinvi.Models.LanguageFilter.English);

            stream.MatchingTweetReceived += (sender, argument) =>
            {
                Console.WriteLine(argument.Tweet.CreatedBy + ": " + argument.Tweet.Text + Environment.NewLine);

            };

            stream.StartStreamMatchingAllConditions();
            
            Console.ReadLine();
            

        }
    }
}
