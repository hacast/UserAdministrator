using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdministrator.Common.DataCollection;
using UserAdministrator.Common.Mapping;
using UserAdministrator.Common.Pagging;
using UserAdministrator.Queries;
using Users.Domain;
using Users.Persistence.DataBase;

namespace UserAdministrator.Services.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly ApplicationDbContext _dbContext;

        public UserQueries(ApplicationDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<DataCollection<UserDTO>> GetActivesAsync(int page, int take)
        {
            try
            {
                var collection = await _dbContext.Users.Where(x => x.Active == true).
                    OrderBy(x => x.Id).GetPagedAsync(page, take);

                return collection.MapTo<DataCollection<UserDTO>>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
