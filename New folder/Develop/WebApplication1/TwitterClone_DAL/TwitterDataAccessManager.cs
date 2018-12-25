using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using DTO = CommonCommunicationHelper.DTO;

namespace TwitterClone_DAL
{
  public class TwitterDataAccessManager
  {
    DOTNETEntities _TwitterEntity;
    //DbSet<DOTNETEntities> _TwitterEntity;
    public TwitterDataAccessManager()
    {
      _TwitterEntity = new DOTNETEntities();
      //string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    }

    public void getAllFollowingsByUserId(int userid)
    {

      var res = (from d in _TwitterEntity.Followings
                 join b in _TwitterEntity.People on d.user_id equals b.user_id
                 where userid == d.user_id
                 select d).ToList();

    }

    public void getAllTweetsByUserID(int userid)
    {

      List<Tweet> _Tweets = (from p in _TwitterEntity.Tweets
                             join s in _TwitterEntity.People on p.user_id equals s.user_id
                             where p.user_id == userid
                             select p
                            ).ToList();
    }


    public void AddUser(Person model, out string _ValidationMessage)
    {
      _ValidationMessage = string.Empty;
      try
      {

        using (DOTNETEntities _TwitterEntity = new DOTNETEntities())
        {
          Person isExist = (from p in _TwitterEntity.People
                            where p.username == model.username
                            select p).FirstOrDefault();
          if (isExist == null)
          {
            _TwitterEntity.People.Add(model);
            _TwitterEntity.SaveChanges();
            _ValidationMessage = "User " + model.username + " Successfully Created!.";
          }
          else
            _ValidationMessage = "This user " + model.username + " Already Exists!.";
        }

      }
      catch (Exception ex)
      {
        string error = ex.Message;
        throw;
      }


    }


    public void ValidateUser(string uname, string pwd, out string _ValidationMessage, out Person model)
    {
      model = null;
      _ValidationMessage = string.Empty;
      try
      {

        using (DOTNETEntities _TwitterEntity = new DOTNETEntities())
        {
          model = (from p in _TwitterEntity.People
                   where p.username == uname && p.password == pwd && p.active == true
                   select p).FirstOrDefault();
          if (model == null)
          {
            _ValidationMessage = " Invalid UserID/Password !.";
          }
          else
          {
            _ValidationMessage = string.Empty;
          }
        }

      }
      catch (Exception ex)
      {
        string error = ex.Message;
        throw;
      }


    }

    public void SaveTweet(Tweet _tweet, int user_id, out string _ValidationMessage )
    {
      _ValidationMessage = string.Empty;
      

      using (DOTNETEntities _TwitterEntity = new DOTNETEntities())
      {

        _TwitterEntity.Tweets.Add(_tweet);
        _TwitterEntity.SaveChanges();
        _ValidationMessage = "Tweet Successfully Posted!.";
       
      }

    }

    public Collection<Tweet> GetTweets(int userId)
    {
      Collection<Tweet> tweets = new Collection<Tweet>();
      using (var db = new DOTNETEntities())
      {
        db.Tweets.Where(x => x.user_id == userId).ToList()
            .ForEach(y =>
            tweets.Add(new Tweet()
            {
              tweet_id = y.tweet_id,
              user_id = y.user_id,
              message = y.message,
              created = y.created,
              Person = y.Person

            }));
      }

      return tweets;
    }

    public List<Follower> GetFollowers(int userId)
    {
      Collection<Follower> followers = new Collection<Follower>();
      using (var db = new DOTNETEntities())
      {
        db.Followings.Where(x => x.following_Id == userId)
            .ToList()
            .ForEach(y =>
            followers.Add(new Follower()
            {
              user_id = y.user_id,
              follower_Id = y.following_Id
            }));
      }

      return followers.ToList();
    }

    public List<Following> GetFollowings(int userId)
    {
      Collection<Following> follwings = new Collection<Following>();
      using (var db = new DOTNETEntities())
      {
        db.Followings.Where(x => x.user_id == userId)
            .ToList()
            .ForEach(y =>
            follwings.Add(new Following()
            {
              user_id = y.user_id,
              following_Id = y.following_Id
            }));
      }

      return follwings.ToList();
    }
  }
}
