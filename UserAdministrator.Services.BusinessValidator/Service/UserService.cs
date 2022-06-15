using MediatR;
using UserAdministrator.Common.DataCollection;
using UserAdministrator.Common.Exceptions;
using UserAdministrator.Queries;
using UserAdministrator.Services.BusinessValidator.Interface;
using UserAdministrator.Services.Commands;
using UserAdministrator.Services.Queries;

namespace UserAdministrator.Services.BusinessValidator.Service
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IUserQueries _userQueries;

        public UserService(IMediator mediator, IUserQueries userQueries)
        {
            _mediator = mediator;
            _userQueries = userQueries;
        }
        public Task<bool> DeleteUser(DeleteUserDTO deleteUserDTO)
        {
            if (deleteUserDTO == null)
            {
                throw new BusinessException("El mensaje no puede estar vacio.");
            }

            var response = _mediator.Send(deleteUserDTO);
            return response;
        }

        public async Task<DataCollection<UserDTO>> GetActivesAsync(int page, int take)
        {
            var response = await _userQueries.GetActivesAsync(page, take);

            return response;
        }

        public Task<bool> PostUser(CreateUserDTO createUserDTO)
        {
            if (createUserDTO == null)
            {
                throw new BusinessException("El mensaje no puede estar vacio.");
            }
            if (createUserDTO.Name == null)
            {
                throw new BusinessException("Debe especificar nombre del User.");
            }

            var response = _mediator.Send(createUserDTO);
            return response;
        }

        public Task<bool> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null)
            {
                throw new BusinessException("El mensaje no puede estar vacio.");
            }

            var response = _mediator.Send(updateUserDTO);
            return response;
        }
    }
}
