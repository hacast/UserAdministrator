using MediatR;

namespace UserAdministrator.Services.Commands
{
    public class DeleteUserDTO : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
