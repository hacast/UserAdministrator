using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Domain;
using Users.Persistence.DataBase;

namespace UserAdministrator.Services.Commands
{
    public class UserCommands : IRequestHandler<CreateUserDTO, bool>, IRequestHandler<UpdateUserDTO, bool>, IRequestHandler<DeleteUserDTO, bool>
    {
        private readonly ApplicationDbContext _dbContext;
        public UserCommands(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(CreateUserDTO request, CancellationToken cancellationToken)
        {
            User entity = new User();

            try
            {
                using (var trx = await _dbContext.Database.BeginTransactionAsync())
                {
                    // 01. Preparo la informacion
                    entity = MapToCreate(request);

                    // 02. Agrego el registro a la tabla
                    await _dbContext.AddRangeAsync(entity);

                    // 03. Guardo el registro
                    int res = await _dbContext.SaveChangesAsync(cancellationToken);

                    trx.Commit();

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Handle(UpdateUserDTO request, CancellationToken cancellationToken)
        {
            try
            {

                using (var trx = await _dbContext.Database.BeginTransactionAsync())
                {
                    // 01. Preparo la informacion
                    var entity = await _dbContext.Users
                     .FirstOrDefaultAsync(x => x.Id == request.Id);

                    if (entity != null)
                    {
                        entity.Active = request.Active;
                        // 03. Guardo el registro
                        await _dbContext.SaveChangesAsync(cancellationToken);
                        
                        trx.Commit();

                        return true;
                    }
                    else
                    {
                        trx.Commit();

                        return false;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Handle(DeleteUserDTO request, CancellationToken cancellationToken)
        {
            try
            {

                using (var trx = await _dbContext.Database.BeginTransactionAsync())
                {
                    // 01. Preparo la informacion
                    var entity = await _dbContext.Users
                     .FirstOrDefaultAsync(x => x.Id == request.Id);

                    if (entity != null)
                    {
                        _dbContext.Users.Remove(entity);

                        // 03. Guardo el registro
                        await _dbContext.SaveChangesAsync(cancellationToken);

                        trx.Commit();
                        return true;
                    }
                    else
                    {
                        trx.Commit();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private User MapToCreate(CreateUserDTO request)
        {
            var user = new User();

            user.Name = request.Name;
            user.BirthDate = request.BirthDate;
            user.Active = true;

            return user;
        }
    }
}
