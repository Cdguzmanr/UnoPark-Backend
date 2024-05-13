using TEAM11.UNO.BL;
using Microsoft.Extensions.Options;

namespace TEAM11.UNO.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials.  Your IP address has been saved.")
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }
    }

    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<UNOEntities> options) : base(options) { }


        public static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

        public void Seed()
        {
            List<User> users = Load();

            foreach (User user in users)
            {
                if (user.Password.Length != 28)
                {
                    Update(user);
                }
            }

            if (users.Count == 0)
            {
                // Hardcord a couple of users with hashed passwords
                Insert(new User { Username = "bfoote", FirstName = "Brian", LastName = "Foote", Password = "maple" });
                Insert(new User { Username = "kvicchiollo", FirstName = "Ken", LastName = "Vicchiollo", Password = "password" });
            }
        }


        // Simplified Login
        public bool Login(string username, string password)
        {
            try
            {
                var user = Load().FirstOrDefault(u => u.Username == username);
                if (user != null && user.Password == GetHash(password))
                {
                    return true; // Login successful
                }
                else
                {
                    return false; // Login failed
                }
            }
            catch (Exception)
            {
                throw new LoginFailureException("Cannot log in with these credentials.  Your IP address has been saved.");
            }
        }



        public bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username))
                { 
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (UNOEntities dc = new UNOEntities(options))
                        {
                            tblUser userrow = dc.tblUsers.FirstOrDefault(u => u.Username == user.Username);

                            if (userrow != null)
                            {
                                // check the password
                                if (userrow.Password == GetHash(user.Password))
                                {
                                    // Login was successfull
                                    user.Id = userrow.Id;
                                    user.FirstName = userrow.FirstName;
                                    user.LastName = userrow.LastName;
                                    user.Username = userrow.Username;
                                    user.Password = userrow.Password;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Cannot log in with these credentials.  Your IP address has been saved.");
                                }
                            }
                            else
                            {
                                throw new Exception("User could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<User> Load()
        {
            try
            {
                List<User> users = new List<User>();

                base.Load()
                    .ForEach(u => users
                    .Add(new User
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Username = u.Username,
                        Password = u.Password
                    }));

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User LoadById(Guid id)
        {
            try
            {
                User user = new User();

                using (UNOEntities dc = new UNOEntities())
                {
                    user = (from u in dc.tblUsers
                            where u.Id == id
                            select new User
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Username = u.Username,
                                Password = u.Password
                            }).FirstOrDefault();
                }

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (UNOEntities dc = new UNOEntities(options))
                {
                    // Check if username already exists - do not allow ....
                    bool inuse = dc.tblUsers.Any(u => u.Username.Trim().ToUpper() == user.Username.Trim().ToUpper());

                    if (inuse && rollback == false)
                    {
                        //throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser newUser = new tblUser();

                        newUser.Id = Guid.NewGuid();
                        newUser.FirstName = user.FirstName.Trim();
                        newUser.LastName = user.LastName.Trim();
                        newUser.Username = user.Username.Trim();
                        newUser.Password = GetHash(user.Password.Trim());

                        user.Id = newUser.Id;

                        dc.tblUsers.Add(newUser);

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (UNOEntities dc = new UNOEntities())
                {
                    // Check if username already exists - do not allow ....
                    tblUser existingUser = dc.tblUsers.Where(u => u.Username.Trim().ToUpper() == user.Username.Trim().ToUpper()).FirstOrDefault();

                    if (existingUser != null && existingUser.Id != user.Id && rollback == false)
                    {
                        throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser upDateRow = dc.tblUsers.FirstOrDefault(r => r.Id == user.Id);

                        if (upDateRow != null)
                        {
                            upDateRow.FirstName = user.FirstName.Trim();
                            upDateRow.LastName = user.LastName.Trim();
                            upDateRow.Username = user.Username.Trim();
                            upDateRow.Password = GetHash(user.Password.Trim());

                            dc.tblUsers.Update(upDateRow);

                            // Commit the changes and get the number of rows affected
                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (UNOEntities dc = new UNOEntities())
                {
                    // Check if user is associated with an exisiting Player id - do not allow delete ....
                    bool inuse = dc.tblPlayers.Any(o => o.UserId == id); // TODO: Verify this is the correct way to check for a foreign key relationship

                    if (inuse)
                    {
                        throw new Exception("This user is associated with an existing Player id and therefore cannot be deleted.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser deleteRow = dc.tblUsers.FirstOrDefault(r => r.Id == id);

                        if (deleteRow != null)
                        {
                            dc.tblUsers.Remove(deleteRow);

                            // Commit the changes and get the number of rows affected
                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
