using MessagesCRUD.Application.Common.Exceptions;
using MessagesCRUD.Application.Messages.Commands.UpdateMessage;
using MessagesCRUD.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MessagesCRUD.Tests.Messages.Commands
{
    public class UpdateMessageCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateMessageCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateMessageCommandHandler(Context);
            var updateText = "new text";

            // Act 
            await handler.Handle(new UpdateMessageCommand
            {
                Id = MessagesContextFactory.MessageIdForUpdate,
                UserId = MessagesContextFactory.USerBId,
                Text = updateText
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Messages.SingleOrDefaultAsync(message =>
                message.Id == MessagesContextFactory.MessageIdForUpdate &&
                message.Text == updateText));
        }

        [Fact]
        public async Task UpdateMessageCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateMessageCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateMessageCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = MessagesContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateMessageCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateMessageCommandHandler(Context);

            // Act


            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateMessageCommand
                    {
                        Id = MessagesContextFactory.MessageIdForUpdate,
                        UserId = MessagesContextFactory.UserAId
                    }, CancellationToken.None);
            });
        }
    }
}
