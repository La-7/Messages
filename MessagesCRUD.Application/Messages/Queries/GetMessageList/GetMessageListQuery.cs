using MediatR;
using System;

namespace MessagesCRUD.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListVm>
    {
        public Guid UserId { get; set; }
    }
}
