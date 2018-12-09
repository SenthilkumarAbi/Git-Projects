using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwitterClone_MVC_WebAPI.Models
{
    public class Person
    {
        //       [user_id] int IDENTITY(300,1) ,
        //[password] varchar(50) not null,
        //fullname varchar(30) not null,
        //email varchar(50) not null,
        //joined datetime not null,
        //active bit not null,
        //primary key ([user_id])
        public int user_id { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="required")]
        public string password { get; set; }

        [Required(ErrorMessage = "required")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "required")]
        [EmailAddress(ErrorMessage ="InValid Email")]
        public string email { get; set; }

        public DateTime joined { get; set; }

        public bool active { get; set; }


    }
}