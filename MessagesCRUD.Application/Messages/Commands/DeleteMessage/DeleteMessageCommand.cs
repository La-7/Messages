using MediatR;
using System;

namespace MessagesCRUD.Application.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
