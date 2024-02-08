using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.Request;
using Weight_Watchers.core.Response;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.core.interfaces_DAL
{
    public interface IWeightWatchersRepository
    {
        //להוסיף MIDDLEWARE
        //GET
        public bool IsCardExist(int cardId);

        public bool IsSubscriberExist(string email);
        
        public  Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id);

        public  Task<int?> Login(string email, string password );
        public  Task<BaseResponse> Register(Subscriber s1, double h);

    }
}
