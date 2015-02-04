using InkyBeta.Core;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InkyBeta.Data.DataContext
{
    public class UserContext : IdentityDbContext<User>
    {
	    public UserContext() : base("UserConnection")
	    {
	    }
    }
}
