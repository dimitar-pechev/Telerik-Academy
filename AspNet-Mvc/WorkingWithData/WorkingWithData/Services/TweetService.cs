using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WorkingWithData.Data.Contracts;
using WorkingWithData.Models;
using WorkingWithData.Services.Contracts;

namespace WorkingWithData.Services
{
    public class TweetService : ITweetService
    {
        private IApplicationDbContext context;

        public TweetService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(string userId, Tweet tweet)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException();
            }

            var user = this.context.Users.Find(userId);

            if (user == null)
            {
                throw new InvalidOperationException();
            }

            tweet.Id = Guid.NewGuid();
            tweet.UserId = userId;
            tweet.User = user;

            this.context.Tweets.Add(tweet);
            this.context.SaveChanges();
        }

        public Tweet Delete(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var tweet = this.context.Tweets.Find(id);

            if (tweet == null)
            {
                return null;
            }

            this.context.Tweets.Remove(tweet);
            this.context.SaveChanges();

            return tweet;
        }

        public void Edit(Tweet tweet)
        {
            this.context.Entry(tweet).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public ICollection<Tweet> GetAllTweets()
        {
            var tweets = this.context.Tweets
                .OrderByDescending(x => x.CreatedOn)
                .Include(x => x.User)
                .ToList();

            return tweets;
        }

        public Tweet GetById(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var tweet = this.context.Tweets.Find(id);

            return tweet;
        }

        public ICollection<Tweet> GetTweetsByQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return this.context.Tweets.OrderByDescending(x => x.CreatedOn).ToList();
            }

            var tweets = this.context.Tweets
                .Where(x => x.Content.ToLower().Contains(query.ToLower()))
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return tweets;
        }

        public ICollection<Tweet> GetTweetsByUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidOperationException();
            }
            
            var tweets = this.context.Tweets
                .Where(x => x.User.UserName == username)
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return tweets;
        }
    }
}