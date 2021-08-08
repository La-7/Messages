using MediatR;
using System;

namespace MessagesCRUD.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListVm>
    {
        public string UserId { get; set; }
    }
}
