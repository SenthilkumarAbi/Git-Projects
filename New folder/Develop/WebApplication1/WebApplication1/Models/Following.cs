using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone_MVC_WebAPI.Models
{
    public class Following
    {
        //       [FG_ID] int IDENTITY(1,1) ,
        //[user_id]
        //       int Not null,

        //   [following_Id] int not null,
        public int FG_ID { get; set; }
        public int user_id { get; set; }
        public int following_Id { get; set; }
    }
}