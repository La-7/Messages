using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MessagesCRUD.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesCRUD.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQueryHandler 
        : IRequestHandler<GetMessageListQuery, MessageListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMessageListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MessageListVm> Handle(GetMessageListQuery request,
            CancellationToken cancellationToken)
        {
            var messagesQuery = await _dbContext.Messages
                .Where(message => message.UserId == request.UserId)
                .ProjectTo<MessageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MessageListVm { Messages = messagesQuery };
        }
    }
}
