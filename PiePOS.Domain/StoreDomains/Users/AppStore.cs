using PiePOS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiePOS.Domain.StoreDomains.Users
{
    public class AppStore : BaseEntity
    {
        public string StoreName { get; set; }
        public string DisplayName { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public string storeId { get; set; }
        public string StoreRegistrationId { get; set; }
    }

}
