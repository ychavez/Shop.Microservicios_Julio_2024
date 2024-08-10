using Authentication.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Context
{
    public class AccountDbContext : IdentityDbContext<DWUser>
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
