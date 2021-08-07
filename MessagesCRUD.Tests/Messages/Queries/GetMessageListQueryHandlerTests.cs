using AutoMapper;
using MessagesCRUD.Application.Messages.Queries;
using MessagesCRUD.Application.Messages.Queries.GetMessageList;
using MessagesCRUD.Persistence;
using MessagesCRUD.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MessagesCRUD.Tests.Messages.Queries
{
    [Collection("QueryCollection")]
    public class GetMessageListQueryHandlerTests
    {
        private readonly ApplicationDbContext Context;
        private readonly IMapper Mapper;

        public GetMessageListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMessageListHandler_Success()
        {
            // Arrange 
            var handler = new GetMessageListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetMessageListQuery
                {
                    UserId = MessagesContextFactory.USerBId,

                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MessageListVm>();
            result.Messages.Count.ShouldBe(2);
        }
    }
}
