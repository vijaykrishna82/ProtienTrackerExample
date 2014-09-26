using System;
using System.Collections.Generic;
using ServiceStack.Redis;

namespace ProtienTrackerMvc.Api
{
    public class UserRepository : IUserRepository
    {
        private ServiceStack.Redis.IRedisClientsManager RedisClientsManager;

        public UserRepository(IRedisClientsManager redisClientsManager)
        {
            RedisClientsManager = redisClientsManager;
        }

        #region IUserRepository Members

        public long AddUser(AddUser request)
        {
            using (var redisClient = RedisClientsManager.GetClient())
            {
                var redisUsers = redisClient.As<User>();
                var user = new User {Name = request.Name, Goal = request.Goal, Id = redisUsers.GetNextSequence()};
                redisUsers.Store(user);

                return user.Id;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var redisClient = RedisClientsManager.GetClient())
            {
                var redisUsers = redisClient.As<User>();
                return redisUsers.GetAll();
            }
        }

        public User GetUser(long id)
        {
            using (var redisClient = RedisClientsManager.GetClient())
            {
                var redisUsers = redisClient.As<User>();
                return redisUsers.GetById(id);
            }
        }
        public void UpdateUser(User user)
        {
            using (var redisClient = RedisClientsManager.GetClient())
            {
                var redisUsers = redisClient.As<User>();
                redisUsers.Store(user);
            }
        }

        #endregion
    }

    public interface IUserRepository
    {

        long AddUser(AddUser user);

        IEnumerable<User> GetUsers();

        User GetUser(long id);

        void UpdateUser(User user);
    }
}
