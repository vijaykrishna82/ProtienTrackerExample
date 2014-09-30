using ServiceStack;

namespace ProteinTrackerContract.Data
{
    [Route("/users", "POST")]
    public class AddUser
    {
        public string Name { get; set; }

        public int Goal { get; set; }
    }
}
