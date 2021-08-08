using MessagesCRUD.Domain;
using MessagesCRUD.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace MessagesCRUD.Tests.Common
{
    public static class MessagesContextFactory
    {
        public static string UserAId = Guid.NewGuid().ToString();
        public static string USerBId = Guid.NewGuid().ToString();

        public static Guid MessageIdForDelete = Guid.NewGuid();
        public static Guid MessageIdForUpdate = Guid.NewGuid();

        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            context.Messages.AddRange(
                new Message
                {
                    CreationDate = DateTime.Today,
                    Text = "text1",
                    EditTime = null,
                    Id = Guid.Parse("F5BF76C3-A2C0-46FE-9055-442DB74254A2"),
                    UserId = UserAId
                },
                new Message
                {
                    CreationDate = DateTime.Today,
                    Text = "text2",
                    EditTime = null,
                    Id = Guid.Parse("633D9C0E-FD79-4ECF-89C8-0A1CB532762A"),
                    UserId = USerBId
                },
                new Message
                {
                    CreationDate = DateTime.Today,
                    Text = "text3",
                    EditTime = null,
                    Id = MessageIdForDelete,
                    UserId = UserAId
                },
                new Message
                {
                    CreationDate = DateTime.Today,
                    Text = "text4",
                    EditTime = null,
                    Id = MessageIdForUpdate,
                    UserId = USerBId
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
