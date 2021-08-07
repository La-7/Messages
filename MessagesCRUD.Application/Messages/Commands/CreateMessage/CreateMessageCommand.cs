using MediatR;
using System;

namespace MessagesCRUD.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}
