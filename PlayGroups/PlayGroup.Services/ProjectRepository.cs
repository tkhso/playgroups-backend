using Playgroup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playgroup.Services
{
    // ProjectRepository acts as a layer only to do DB CRUDS 
    public class ProjectRepository : IProjectRepository
    {
        private readonly PlaygroupContext Context;

        public ProjectRepository(PlaygroupContext context)
        {
            this.Context = context;
        }

        #region Users
        public User GetUser(string email)
        {
            return this.GetUserDb().FirstOrDefault(x => x.Email == email);
        }
        #endregion

        #region Private Methods
        private IQueryable<User> GetUserDb()
        {
            return this.Context.Users;
        }
        #endregion
    }

    public interface IProjectRepository
    {
        User GetUser(string email);
    }
}
