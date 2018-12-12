using System;
using System.Collections.Generic;
using System.Linq;


namespace CommonCommunicationHelper.DTO
{
  public class Tweet
  { 
    public int tweet_id { get; set; }
    public int user_id { get; set; }
    public string fullname { get; set; }
    public string message { get; set; }
    public DateTime created { get; set; }
  }
}