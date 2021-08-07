using MediatR;
using MessagesCRUD.Application.Common.Exceptions;
using MessagesCRUD.Application.Interfaces;
using MessagesCRUD.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesCRUD.Application.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommandHandler 
        : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteMessageCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteMessageCommand request, 
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            _dbContext.Messages.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
