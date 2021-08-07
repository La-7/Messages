using AutoMapper;
using MessagesCRUD.Application.Common.Mappings;
using MessagesCRUD.Application.Messages.Commands.CreateMessage;
using System.ComponentModel.DataAnnotations;

namespace MessagesCRUD.WebApi.Models.Command
{
    public class CreateMessageDto : IMapWith<CreateMessageCommand>
    {
        [Required]
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMessageDto, CreateMessageCommand>()
                .ForMember(messageCommand => messageCommand.Text,
                    opt => opt.MapFrom(messageDto => messageDto.Text));
        }
    }
}
