using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone_MVC_WebAPI.Models
{
    public class Tweet
    {
        //       [tweet_id] int IDENTITY(1,1) ,
        //[user_id]
        //       int Not null,

        //   [message] varchar(140),
        //[created] datetime,
        public int tweet_id { get; set; }
        public int user_id { get; set; }

        public  string message { get; set; }

        public DateTime created { get; set; }
    }
}