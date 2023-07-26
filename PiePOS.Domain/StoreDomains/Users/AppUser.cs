using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiePOS.Domain.StoreDomains.Users
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public Guid StoreId { get; set; }
        public virtual AppStore AppStore { get; set; }
    }
}
