using HandsOnTest.DAL.Models;
using System;
using System.Collections.Generic;

namespace HandsOnTest.BLL.DAO
{
    public partial class UserDAO
    {
        public UserDAO()
        {
            this.UserName = String.Empty;
        }
        
        public UserDAO(User user)
        {
            this.UserName = user.UserName;
            this.UserId = user.UserId;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
