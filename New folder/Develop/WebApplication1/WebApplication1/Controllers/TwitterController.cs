using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone_MVC_WebAPI.Models;


namespace TwitterClone_MVC_WebAPI.Controllers
{
  public class TwitterController : Controller
  {
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
      }
      return View(_twitterModal);
    }

    [ChildActionOnly]
    public PartialViewResult GetTweetMessages(int userId)
    {


      IEnumerable<Tweet> Items = new List<Tweet> {
    new Tweet (){ tweet_id = 1,message = "had tea",
            created=DateTime.Now, user_id= 2, fullname="test" },
     new Tweet (){ tweet_id = 2,message = "coffee with friends",
            created=DateTime.Now, user_id= 2 , fullname="test1"},
     new Tweet (){ tweet_id = 3,message = "fun with movie",
            created=DateTime.Now, user_id= 2 , fullname="test2"},
     new Tweet (){ tweet_id = 5,message = "Tea",
            created=DateTime.Now, user_id= 2, fullname="test3" },
      new Tweet (){ tweet_id = 6,message = "Tea",
            created=DateTime.Now, user_id= 2 , fullname="test4"},
};
      return PartialView("Tweets", Items);
    }


  }
}