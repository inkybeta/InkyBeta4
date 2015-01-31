using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkyBeta.Core;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InkyBeta.Data.DataContext
{
    public class UserContext : IdentityDbContext<User>
    {
	    public UserContext() : base("UserConnected")
	    {
		    
	    }
    }
}
