using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.DTO;
using Weight_Watchers.core.Response;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.core.interfaces_Service
{
    public interface IWeightWatcherService
    {

        public Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id);

        public  Task<BaseResponseGeneral<int?>> Login(string email, string password);
        public Task<BaseResponse> Register(SubscriberDTO s1);

    }
}
