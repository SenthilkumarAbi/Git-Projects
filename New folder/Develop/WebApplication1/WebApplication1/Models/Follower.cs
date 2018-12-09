using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone_MVC_WebAPI.Models
{
    public class Follower
    {
        //       [FR_ID] int IDENTITY(1,1) ,
        //[user_id]
        //       int Not null,

        //   [follower_Id] int not null,
        public int FR_ID { get; set; }
        public int user_id { get; set; }

        public int follower_Id { get; set; }
    }
}