using MediatR;
using MessagesCRUD.Application.Common.Exceptions;
using MessagesCRUD.Application.Interfaces;
using MessagesCRUD.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesCRUD.Application.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommandHandler 
        : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateMessageCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateMessageCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                    await _dbContext.Messages.FirstOrDefaultAsync(message =>
                    message.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            entity.Text = request.Text;
            entity.EditTime = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
