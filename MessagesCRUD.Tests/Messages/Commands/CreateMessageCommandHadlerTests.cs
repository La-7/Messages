using MessagesCRUD.Application.Messages.Commands.CreateMessage;
using MessagesCRUD.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MessagesCRUD.Tests.Messages.Commands
{
    public class CreateMessageCommandHadlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateMessageCommandHanler_Success()
        {
            // Arrange
            var handler = new CreateMessageCommandHandler(Context);
            var messageText = "message1";

            // Act
            var messageId = await handler.Handle(
                    new CreateMessageCommand
                    {
                        Text = messageText, 
                        UserId = MessagesContextFactory.UserAId
                    }, CancellationToken.None
                );

            // Assert
            Assert.NotNull(
                await Context.Messages.SingleOrDefaultAsync(message =>
                    message.Id == messageId && message.Text == messageText));
        }
    }
}
