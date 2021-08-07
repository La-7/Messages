using MessagesCRUD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessagesCRUD.Persistence
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(message => message.Id);
            builder.HasIndex(message => message.Id).IsUnique();
            builder.Property(message => message.Text).HasMaxLength(2000);
        }
    }
}
