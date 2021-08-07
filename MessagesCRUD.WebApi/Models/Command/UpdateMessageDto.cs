using AutoMapper;
using MessagesCRUD.Application.Common.Mappings;
using MessagesCRUD.Application.Messages.Commands.UpdateMessage;
using System;

namespace MessagesCRUD.WebApi.Models.Command
{
    public class UpdateMessageDto : IMapWith<UpdateMessageCommand>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMessageDto, UpdateMessageCommand>()
                .ForMember(messageCommand => messageCommand.Id,
                    opt => opt.MapFrom(messageDto => messageDto.Id))
                .ForMember(messageCommand => messageCommand.Text,
                    opt => opt.MapFrom(messageDto => messageDto.Text));
        }
    }
}
