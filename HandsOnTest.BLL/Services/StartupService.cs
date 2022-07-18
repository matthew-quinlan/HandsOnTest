using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HandsOnTest.BLL.Services
{
    /// <summary>
    /// Service for db migrations
    /// </summary>
    public class StartupService
    {
        public StartupService()
        {
            new HandsOnTestContext().Database.Migrate();
        }
    }
}
