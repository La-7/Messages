using MediatR;
using System;

namespace MessagesCRUD.Application.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
