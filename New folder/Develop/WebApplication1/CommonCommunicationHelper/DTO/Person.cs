using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonCommunicationHelper.DTO
{
  public class Person
  { 
    public string username { get; set; }
    public int user_id { get; set; }     
    public string password { get; set; }     
    public string fullname { get; set; }     
    public string email { get; set; }
    public DateTime joined { get; set; }
    public bool active { get; set; }

  }
}