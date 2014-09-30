using ServiceStack;

namespace ProteinTrackerContract.Data
{
    [Route("/users/{userid}", "POST")]
   public  class AddProtien
    {
       public long UserId { get; set; }

       public int Amount { get; set; }
    }
}
