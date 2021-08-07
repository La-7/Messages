using AutoMapper;
using MessagesCRUD.Application.Common.Mappings;
using MessagesCRUD.Domain;
using System;

namespace MessagesCRUD.Application.Messages.Queries
{
    public class MessageLookupDto : IMapWith<Message>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageLookupDto>()
                .ForMember(messageDto => messageDto.Id,
                    opt => opt.MapFrom(message => message.Id))
                .ForMember(messageDto => messageDto.Text,
                    opt => opt.MapFrom(message => message.Text));
        }
    }
}
