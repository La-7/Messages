using MessagesCRUD.Application.Common.Exceptions;
using MessagesCRUD.Application.Messages.Commands.CreateMessage;
using MessagesCRUD.Application.Messages.Commands.DeleteMessage;
using MessagesCRUD.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MessagesCRUD.Tests.Messages.Commands
{
    public class DeleteMessageCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteMessageCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteMessageCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteMessageCommand
            {
                Id = MessagesContextFactory.MessageIdForDelete,
                UserId = MessagesContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Messages.SingleOrDefault(message =>
                message.Id == MessagesContextFactory.MessageIdForDelete));
        }

        [Fact]
        public async Task DeleteMessageCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteMessageCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteMessageCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = MessagesContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteMessageCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteMessageCommandHandler(Context);
            var createHandler = new CreateMessageCommandHandler(Context);
            var messageId = await createHandler.Handle(
                new CreateMessageCommand
                {
                    Text = "messageText",
                    UserId = MessagesContextFactory.UserAId
                }, CancellationToken.None);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteMessageCommand
                    {
                        Id = messageId,
                        UserId = MessagesContextFactory.USerBId
                    }, CancellationToken.None));
        }
    }
}
