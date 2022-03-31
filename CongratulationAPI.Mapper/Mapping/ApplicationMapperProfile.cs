using AutoMapper;
using CongratulationAPI.Contracts.BirthDay;
using CongratulationAPI.Contracts.Congratulation;
using CongratulationAPI.Contracts.Enums;
using CongratulationAPI.Contracts.Know;
using CongratulationAPI.Contracts.User;
using CongratulationAPI.Domain.Entities;

namespace CongratulationAPI.Mapper.Mapping
{
    public class ApplicationMapperProfile: Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<BirthDay,BirthDayDto>()
                .ForMember(dto=>dto.Users, source=>source.MapFrom(entity=>entity.Users))
                .ForMember(dto=>dto.Congratulations, source=>source.MapFrom(entity=>entity.Congratulations));
            CreateMap<BirthDayDtoAdd, BirthDay>();
            CreateMap<BirthDayDtoUpdate, BirthDay>();

            CreateMap<Congratulation, CongratulationDto>()
                .ForMember(dto => dto.ToUserName, sourse => sourse.MapFrom(entity => entity.User.Name))
                .ForMember(dto => dto.ToUserSecondName, sourse => sourse.MapFrom(entity => entity.User.SecondName))
                .ForMember(dto => dto.ToUserLastName, sourse => sourse.MapFrom(entity => entity.User.LastName))
                .ForMember(dto => dto.FromUser, sourse => sourse.MapFrom(entity => entity.FromUser.Id))
                .ForMember(dto => dto.FromUserName, sourse => sourse.MapFrom(entity => entity.FromUser.Name))
                .ForMember(dto => dto.FromUserSecondName, sourse => sourse.MapFrom(entity => entity.FromUser.SecondName))
                .ForMember(dto => dto.FromUserLastName, sourse => sourse.MapFrom(entity => entity.FromUser.LastName));
            CreateMap<CongratulationDtoAdd, Congratulation>()
                .ForMember(entity=> entity.UserId,source=>source.MapFrom(dto=>dto.UserId))
                .ForMember(entity => entity.FromUserId, source => source.MapFrom(dto => dto.FromUserId));
            CreateMap<CongratulationDtoUpdate, Congratulation>()
                .ForMember(entity => entity.UserId, source => source.MapFrom(dto => dto.UserId))
                .ForMember(entity => entity.FromUserId, source => source.MapFrom(dto => dto.FromUserId));

            CreateMap<User, UserDto>()
                 .ForMember(dto => dto.Congratulations, source => source.MapFrom(entity => entity.Congratulations))
                 .ForMember(dto => dto.Knows, source => source.MapFrom(entity => entity.Knows))
                 .ForMember(dto => dto.KnowsToMe, source => source.MapFrom(entity => entity.KnowsToMe))
                 .ForMember(dto => dto.Gender, source => source.MapFrom(entity => entity.Gender.ToString()))
                 .ForMember(dto => dto.BirthDay, source => source.MapFrom(entity => entity.BirthDay));
            CreateMap<UserDtoAdd, User>();
            CreateMap<UserDtoUpdate, User>();

            CreateMap<Know, KnowDto>()
                .ForMember(dto => dto.FromUserName, sourse => sourse.MapFrom(entity => entity.FromUser.Name))
                .ForMember(dto => dto.FromUserSecondName, sourse => sourse.MapFrom(entity => entity.FromUser.SecondName))
                .ForMember(dto => dto.FromUserLastName, sourse => sourse.MapFrom(entity => entity.FromUser.LastName))
                .ForMember(dto => dto.UserStatusId, sourse => sourse.MapFrom(dto => (int)dto.UserStatus))
                .ForMember(dto => dto.UserStatusName, sourse => sourse.MapFrom(dto => dto.UserStatus.ToString()))
                .ForMember(dto => dto.KnowUserName, sourse => sourse.MapFrom(entity => entity.KnowUser.Name))
                .ForMember(dto => dto.KnowUserSecondName, sourse => sourse.MapFrom(entity => entity.KnowUser.SecondName))
                .ForMember(dto => dto.KnowUserLastName, sourse => sourse.MapFrom(entity => entity.KnowUser.LastName))
                ;
            CreateMap<KnowDtoAdd, Know>()
                .ForMember(entity => entity.UserStatus, sourse => sourse.MapFrom(dto => (UserStatus)dto.UserStatusId));
            CreateMap<KnowDtoUpdate, Know>()
                .ForMember(entity => entity.UserStatus, sourse => sourse.MapFrom(dto => (UserStatus)dto.UserStatusId));

        }
    }
}
