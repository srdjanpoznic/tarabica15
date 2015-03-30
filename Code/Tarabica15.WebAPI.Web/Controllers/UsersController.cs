using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Web.Controllers
{
    public class UsersController : BaseApiController
    {
        //private readonly IUserManager _userManager;

        //public UsersController(IUserManager userManager)
        //{
        //    _userManager = userManager;
        //}

        //// GET api/users/GetStartModalities
        //[HttpGet]
        //public IQueryable<StartModality> GetStartModalities(int roleId)
        //{
        //    var userId = UserDetails.Id;
        //    var userRoles = _userManager.GetStartModalities(userId, false);
        //    return FilterRoles(userRoles).AsQueryable();
        //}

        //// GET api/users/GetPlantStartModalities
        //[HttpGet]
        //public IQueryable<StartModality> GetPlantStartModalities()
        //{
        //    var userId = UserDetails.Id;
        //    var userRoles = _userManager.GetStartModalities(userId, true);
        //    return FilterRoles(userRoles).AsQueryable();
        //}

        //// GET api/users/GetPlantStartModalities
        //[HttpGet]
        //public IQueryable<StartModality> GetPlantStartModalities(int roleId)
        //{
        //    var userId = UserDetails.Id;
        //    var userRoles = _userManager.GetStartModalities(userId, roleId, true);
        //    return FilterRoles(userRoles).AsQueryable();
        //}

        //// GET api/users/GetPlantStartModalities
        //[HttpGet]
        //public IEnumerable<StartModality> GetPlantStartModalities(int roleId, int entityTypeId)
        //{
        //    var userId = UserDetails.Id;
        //    var userRoles = _userManager.GetStartModalities(userId, roleId, entityTypeId, true);
        //    return FilterRoles(userRoles).AsQueryable();
        //}

        //// GET api/users/GetUserLocalization
        //[HttpGet]
        //public UserLocalizationDetails GetUserLocalization()
        //{
        //    var username = UserDetails.UserName;
        //    return _userManager.GetUserLocalization(username);
        //}

        //// GET api/users/GetUserLocalizatioForActiveUsers
        //[HttpGet]
        //public UserLocalizationDetails GetUserLocalizatioForActiveUsers()
        //{
        //    var username = UserDetails.UserName;
        //    return _userManager.GetUserLocalizationForActiveUsers(username);
        //}

        //// GET api/users/GetUserLocalizationForActiveUserGroups
        //[HttpGet]
        //public UserLocalizationDetails GetUserLocalizationForActiveUserGroups()
        //{
        //    var username = UserDetails.UserName;
        //    return _userManager.GetUserLocalizationForActiveUserGroups(username);
        //}

        //// GET api/users/GetCountSameUserRoles
        //[HttpGet]
        //public int GetCountSameUserRoles(int userId, int entityTypeId, int roleId)
        //{
        //    return _userManager.GetCountSameUserRoles(userId, entityTypeId, roleId);
        //}

        //// GET api/users/Get
        //[HttpGet]
        //public IQueryable<UserDetails> Get()
        //{
        //    return _userManager.GetUsers().AsQueryable();
        //}


        //[HttpGet]
        //public UserDetails GetUser(int userId)
        //{
        //    return _userManager.GetUser(userId);
        //}
    }
}
