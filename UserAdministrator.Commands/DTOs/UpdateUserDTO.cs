using MediatR;

namespace UserAdministrator.Services.Commands
{
    public class UpdateUserDTO : IRequest<bool>
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
