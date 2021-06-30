using AutoMapper;
using GymManager.Core.DTOs.Subscriptions;

namespace GymManager.Core.Profiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Entities.Subscription, SubscriptionDto>().ReverseMap();
            CreateMap<Entities.Subscription, ActiveSubscriptionDto>().ReverseMap();
            CreateMap<SubscriptionDto, ActiveSubscriptionDto>().ReverseMap();
        }
    }
}
