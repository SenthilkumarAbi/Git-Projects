using CommonCommunicationHelper.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone_BAL;
using TwitterClone_DAL;
using DTO = CommonCommunicationHelper.DTO;
using Model = TwitterClone_MVC_WebAPI.Models;
 
namespace WebApplication1.Repository
{
  public class TwitterRepository
  {
    TwitterService _twitterService = new TwitterService();
    public ValidationResult AddUser(Model.Person model,out string _ValidationMessage)
    {
      ValidationResult _validationResult = new ValidationResult();
      _ValidationMessage = string.Empty;
      try
      {
         Person _dtoPerson = new Person { active = true, email = model.email, fullname = model.fullname, password = model.password, username = model.username, joined = DateTime.Now };
        _validationResult = _twitterService.AddUser(_dtoPerson, out _ValidationMessage);
        return ValidationResult.Sucess;
      }
      catch (Exception)
      {

        return ValidationResult.failure;
      }

      finally
      {

      }

    }


    public ValidationResult Validate(string uname, string pwd, out string _ValidationMessage, out Model.Person model)
    {
      ValidationResult _validationResult = new ValidationResult();
      model = new Model.Person();
      _ValidationMessage = string.Empty;
      try
      {
        Person _dtoPerson;

        _validationResult = _twitterService.ValidateUser(uname, pwd, out _ValidationMessage, out _dtoPerson);
        model =  new Model.Person { active = _dtoPerson.active, email = _dtoPerson.email, fullname = _dtoPerson.fullname, password = _dtoPerson.password, user_id = _dtoPerson.user_id, username = _dtoPerson.username, joined = _dtoPerson.joined };
        return ValidationResult.Sucess;
      }
      catch (Exception)
      {

        return ValidationResult.failure;
      }

      finally
      {

      }

    }
  }
}