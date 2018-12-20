using System;
using System.Collections.Generic;
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
            _ValidationMessage = "This User " + model.username + " Already Exists!.";
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

  }
}
