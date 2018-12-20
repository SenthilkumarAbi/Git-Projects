using CommonCommunicationHelper.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = TwitterClone_DAL;


namespace TwitterClone_BAL
{
  public class TwitterService
  {
    Entity.TwitterDataAccessManager _twitterDataAccess = new Entity.TwitterDataAccessManager();
    public ValidationResult AddUser(Entity.Person model, out string _ValidationMessage)
    {


      _twitterDataAccess.AddUser(model, out _ValidationMessage);
      return ValidationResult.Sucess;
    }

    public ValidationResult ValidateUser(string uname, string pwd, out string _ValidationMessage, out Entity.Person model)
    {
      _twitterDataAccess.ValidateUser(uname, pwd, out _ValidationMessage, out model);
      return ValidationResult.Sucess;
    }
  }
}
