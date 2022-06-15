using MediatR;

namespace UserAdministrator.Services.Commands
{
    public class CreateUserDTO : IRequest<bool>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}