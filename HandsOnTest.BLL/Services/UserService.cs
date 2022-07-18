using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.BLL.DAO;
using HandsOnTest.DAL.Models;

namespace HandsOnTest.BLL.Services
{
    /// <summary>
    /// Service for adding and retrieving user
    /// </summary>
    public class UserService
    {
        public UserDAO? GetUser(string userName)
        {
            try
            {
                using (var context = new HandsOnTestContext())
                {
                    var user = context.Users.Where(x => x.UserName == userName).FirstOrDefault();
                    if (user == null)
                    {
                        AddUpdateUser(userName);
                        user = context.Users.Where(x => x.UserName == userName).First();
                    }
                    return new UserDAO(user);
                }
            }
            catch(Exception)
            {

            }
            return null;
        }

        public void AddUpdateUser(string userName)
        {
            using (var context = new HandsOnTestContext())
            {
                if (!context.Users.Any(x => x.UserName == userName))
                {
                    context.Users.Add(new User()
                    {
                        UserName = userName
                    });
                }
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
