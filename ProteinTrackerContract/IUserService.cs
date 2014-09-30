using ProteinTrackerContract.Data;

namespace ProteinTrackerContract
{
    public interface IUserService
    {
        AddUserResponse Post(AddUser request);
        UsersResponse Get(Users request);
        AddProtienResponse Post(AddProtien request);
    }
}