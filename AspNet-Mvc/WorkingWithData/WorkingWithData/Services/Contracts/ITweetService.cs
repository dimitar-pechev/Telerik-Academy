using System;
using System.Collections.Generic;
using WorkingWithData.Models;

namespace WorkingWithData.Services.Contracts
{
    public interface ITweetService
    {
        ICollection<Tweet> GetAllTweets();

        ICollection<Tweet> GetTweetsByUser(string username);

        ICollection<Tweet> GetTweetsByQuery(string query);

        Tweet GetById(Guid? id);

        Tweet Delete(Guid? id);

        void Edit(Tweet id);

        void Create(string userId, Tweet tweet);
    }
}
