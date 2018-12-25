﻿using CommonCommunicationHelper.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = TwitterClone_DAL;


namespace TwitterClone_BAL
{
  public class TwitterService
  {
    Entity.TwitterDataAccessManager _twitterDataAccess = new Entity.TwitterDataAccessManager();
    public ValidationResult AddUser(Entity.Person model, out string _ValidationMessage)
    {
      _twitterDataAccess.AddUser(model, out _ValidationMessage);
      return ValidationResult.Sucess;
    }

    public ValidationResult ValidateUser(string uname, string pwd, out string _ValidationMessage, out Entity.Person model)
    {
      _twitterDataAccess.ValidateUser(uname, pwd, out _ValidationMessage, out model);
      return ValidationResult.Sucess;
    }

    public ValidationResult SaveTweet(Entity.Tweet _tweet, int user_id, out string _ValidationMessage)
    {
      _twitterDataAccess.SaveTweet(_tweet, user_id, out _ValidationMessage );
      return ValidationResult.Sucess;
    }

    public ValidationResult GetTweets(int userId, out List<Entity.Tweet> _tweets)
    {
      _tweets = _twitterDataAccess.GetTweets(userId).ToList();
      return ValidationResult.Sucess;
    }

    public List<Entity.Following> GetFollowings(int userId) {
      List<Entity.Following> following = new List<Entity.Following>();
      following = _twitterDataAccess.GetFollowings(userId);
      return following;
    }

    public List<Entity.Follower> GetFollowers(int userId)
    {
      List<Entity.Follower> follower = new List<Entity.Follower>();
      follower = _twitterDataAccess.GetFollowers(userId);
      return follower;
    }
  }
}
