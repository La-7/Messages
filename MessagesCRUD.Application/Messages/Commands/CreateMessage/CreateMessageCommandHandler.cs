using MediatR;
using MessagesCRUD.Application.Interfaces;
using MessagesCRUD.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesCRUD.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommandHandler
        : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateMessageCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateMessageCommand request, 
            CancellationToken cancellationToken)
        {
            var message = new Message
            {
                UserId = request.UserId,
                Text = request.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditTime = null
            };

            await _dbContext.Messages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.Id;
        }
    }
}
