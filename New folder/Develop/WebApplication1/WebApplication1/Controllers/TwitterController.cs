using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone_MVC_WebAPI.Models;
using WebApplication1.Repository;

namespace TwitterClone_MVC_WebAPI.Controllers
{
  public class TwitterController : Controller
  {
    TwitterRepository _Repository = new TwitterRepository();

    [HttpGet]
    public ActionResult Home()
    {
      TwitterModal _twitterModal = new TwitterModal();
      Person userModel;
      if (Session["UserInfo"] != null)
      {
        userModel = (Person)Session["UserInfo"];
        _twitterModal._person.fullname = userModel.fullname;
        _twitterModal._person.email = userModel.email;
        _twitterModal._person.user_id = userModel.user_id;
        _twitterModal._following = _Repository.getFollowings(userModel.user_id);
        _twitterModal._follower = _Repository.getFollowers(userModel.user_id);
      }
      return View(_twitterModal);
    }

    [ChildActionOnly]
    public PartialViewResult GetTweetMessages(int userId)
    {

      List<Tweet> _Tweets = new List<Tweet>();
      try
      {
        _Tweets = _Repository.getAllTweets(userId);
      }
      catch (Exception)
      {
        AddErrors("Problem with server. Please try again later..");
      }
      return PartialView("Tweets", _Tweets);
    }

    public ActionResult SearchUsersByName(string name)
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult AddTweet(TwitterModal _twitterModal)
    {
      string _ValidationMessage = string.Empty;
      try
      {
        if (Session["UserInfo"] != null)
        {
          Person userModel = (Person)Session["UserInfo"];
          Tweet tweet = new Tweet
          {
            user_id = userModel.user_id,
            fullname = userModel.fullname,
            message = _twitterModal._myTweet.message,
            created = DateTime.Now,

          };

          _Repository.SaveTweet(tweet, userModel.user_id, out _ValidationMessage);

        }
        else
        {
          return RedirectToAction("Login", "User");
        }

      }
      catch (Exception)
      {
        AddErrors("Problem with server. Please try again later..");
      }
      return RedirectToAction("Home", "Twitter");
    }

    private void AddErrors(string error)
    {
      ModelState.AddModelError("", error);
    }

  }
}