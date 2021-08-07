using System.Collections.Generic;

namespace MessagesCRUD.Application.Messages.Queries
{
    public class MessageListVm
    {
        public IList<MessageLookupDto> Messages { get; set; }
    }
}
