using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtienTrackerMvc.Api
{
    class UsersResponse
    {
        public IEnumerable<User> Users { get; set; }
    }
}
