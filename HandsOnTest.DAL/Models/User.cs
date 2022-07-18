using System;
using System.Collections.Generic;

namespace HandsOnTest.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
