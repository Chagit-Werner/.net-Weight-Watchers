using AutoMapper;
using Weight_Watchers.core.DTO;
using Weight_Watchers.core.Request;
using Weight_Watchers.data.Entities;

namespace Project_Net.core.config
{
    public class WeightWatcherProfile:Profile
    {
        public WeightWatcherProfile()
        {
            CreateMap<Subscriber, SubscriberDTO>().ForMember(dest => dest.Height, opt => opt.Ignore()).ReverseMap();



            CreateMap<Card, cardDTO>().ReverseMap();
        }
    }
}
