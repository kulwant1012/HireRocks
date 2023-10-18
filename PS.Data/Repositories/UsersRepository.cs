using PS.Data.Entities;
using PS.Data.Entities.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Repositories
{
    public class UsersRepository : Repository<User>
    {
        public User GetUser(string email, string password)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<User>().SingleOrDefault(i => i.Email == email && i.Password == password);
            }
        }

        public User GetUser(string email)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<User>().SingleOrDefault(i => i.Email == email);
            }
        }

        public void UpdateUser(User user)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(user);
                session.SaveChanges();
            }
        }

        public void ChangePassword(string userId, string newPassword)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var user = session.Query<User>().SingleOrDefault(i => i.Id == userId);
                if (user != null)
                {
                    user.Password = newPassword;
                    session.Store(user);
                    session.SaveChanges();
                }
            }
        }

        #region VerifyEmail
        public void ChangeEmail(string userId, string newEmail)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var user = session.Query<User>().SingleOrDefault(i => i.Id == userId);
                if (user != null)
                {
                    user.Email = newEmail;
                    session.Store(user);
                    session.SaveChanges();
                }
            }
        }
        #endregion

        public bool Register(User user)
        {
            using (var session = DocumentStore.OpenSession())
            {
                bool registrationResult = false;
                var existingUser = session.Query<User>().SingleOrDefault(i => i.Email == user.Email);
                if (existingUser == null)
                {
                    user.Wallet = new Wallet();
                    user.Created = DateTime.UtcNow;
                    user.Sector = SectorType.Creation;
                    user.CanProduceTasks = true;

                    session.Store(user);
                    session.SaveChanges();
                    registrationResult = true;
                }
                return registrationResult;
            }
        }

        public void UpdateUserPhotoId(string userId, List<string> photoIds)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var user = session.Query<User>().SingleOrDefault(i => i.Id == userId);
                if (user != null)
                {
                    user.PhotoIds = photoIds;
                    session.Store(user);
                    session.SaveChanges();
                }
            }
        }

        public List<User> GetFriends(string email)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var user = session.Query<User>().SingleOrDefault(i => i.Email == email);
                var friends = new List<User>();
                if (user != null)
                {
                    foreach (var friendId in user.FriendIds)
                    {
                        var friend = session.Query<User>().SingleOrDefault(i => i.Id == friendId);
                        if (friend != null)
                            friends.Add(friend);
                    }
                }

                return friends;
            }
        }

        public List<User> SearchUsers(string query)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<User>().Where(i => i.FirstName.StartsWith(query.ToLower())
                    || i.LastName.StartsWith(query.ToLower())).ToList();
            }
        }


        public void AddFriend(string email, string friendEmail)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var user = session.Query<User>().SingleOrDefault(i => i.Email == email);
                var firend = session.Query<User>().SingleOrDefault(i => i.Email == friendEmail);
                if (user != null && firend != null && user.FriendIds.FirstOrDefault(x => x.Equals(firend.Id)) == null)
                {
                    user.FriendIds.Add(firend.Id);
                    session.Store(user);
                    session.SaveChanges();
                }
            }
        }

        public void RemoveFriend(string email, string friendEmail)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var user = session.Query<User>().SingleOrDefault(i => i.Email == email);
                var firend = session.Query<User>().SingleOrDefault(i => i.Email == friendEmail);
                if (user != null && firend != null && user.FriendIds.FirstOrDefault(x => x.Equals(firend.Id)) != null)
                {
                    user.FriendIds.Remove(firend.Id);
                    session.Store(user);
                    session.SaveChanges();
                }
            }
        }
    }
}
