using MessagesCRUD.Persistence;
using System;

namespace MessagesCRUD.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;

        public TestCommandBase()
        {
            Context = MessagesContextFactory.Create();
        }

        public void Dispose()
        {
            MessagesContextFactory.Destroy(Context);
        }
    }
}
