using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack;

namespace ProtienTrackerMvc.Api
{
    [Route("/users/{userid}", "POST")]
   public  class AddProtien
    {
       public long UserId { get; set; }

       public int Amount { get; set; }
    }
}
