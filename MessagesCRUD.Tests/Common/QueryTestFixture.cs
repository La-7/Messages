using AutoMapper;
using MessagesCRUD.Application.Common.Mappings;
using MessagesCRUD.Application.Interfaces;
using MessagesCRUD.Persistence;
using System;
using Xunit;

namespace MessagesCRUD.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ApplicationDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = MessagesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(
                    typeof(IApplicationDbContext).Assembly));
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            MessagesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
