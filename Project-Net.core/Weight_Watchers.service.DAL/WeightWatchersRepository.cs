using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.Response;
using Weight_Watchers.data.Entities;
using Weight_Watchers.data;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.data;
using Weight_Watchers.core.Request;
using System.ComponentModel.DataAnnotations;

namespace Weight_Watchers.service.DAL
{
    public class WeightWatchersRepository:IWeightWatchersRepository
    {
        //להוסיף 2 פונקציות ISEXISTR
        //אחת לפי Id של הכרטיס!!!!!!!!!!
        //אחת לפי EMAIL
        //ה-BL ירד למטה רק אם יקרב TRUE/FALSE 
        //לפי הענין
        //לשנות את הפונקציה GET שתקרא לפונקציה LOGIN

        readonly Weight_Watchers_Context _weightWatcherContext;
        public WeightWatchersRepository(Weight_Watchers_Context weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }
        public bool IsCardExist(int cardId)
        {
            Card c = _weightWatcherContext.Cards.Where(x => x.Id == cardId).FirstOrDefault();
            return c != null;
        }
        public bool IsSubscriberExist(string email)
        {
            Subscriber s = _weightWatcherContext.Subscribers.Where(x => x.Email.Equals(email)).FirstOrDefault();
            return s != null;
        }

        public async Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id)
        {
            //הפונקציה הזאת מקבלת כבר את וד הכרטיס של בנ"א מסוים!!!!!
            try
            {
                //if(s == null) return null;
                Card c = _weightWatcherContext.Cards.Where(x => x.Id == id).FirstOrDefault();
                BaseResponseGeneral<SubscriberAndCard> result = new BaseResponseGeneral<SubscriberAndCard>();
                Subscriber s = _weightWatcherContext.Subscribers.Where(x => x.Id == c.SubscriberId).FirstOrDefault();

                if (c != null)
                {
                    result.Data =  new SubscriberAndCard();
                    result.Data.FirstName = s.FirstName;
                    result.Data.LastName = s.LastName;
                    result.Data.Height = c.Height;
                    result.Data.Weight = c.Weight;
                    result.Data.BMI = c.BMI;
                    
                    return result;
                }
                else
                {
                    result.Succeed=false;
                    result.Message = "cannot get details!";
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Failed return card Details;");
            }

        }
        public async Task<int?> Login( string email,string password)
        {
            Subscriber s = _weightWatcherContext.Subscribers.Where(x => x.Email.Equals(email)).FirstOrDefault();
            Card c; 
                if(s.Password.Equals(password))
                {
                    c = _weightWatcherContext.Cards.Where(c1 => c1.SubscriberId == s.Id).FirstOrDefault();
                    //להחזיר את הIDה של הכרטיס לפי הדרישה
                    return c.Id;
                }
                //יש כזה בן אדם אבל הסיסמא לא תקינה
            return null;
        }

        public async Task<BaseResponse> Register(Subscriber s, double h )
        {
           
            //בטוח שמחזיר אחרי השינויים בטבלה??????
            //שווה בדיקה!!!!
            var ss = await _weightWatcherContext.Subscribers.AddAsync(s);
            await _weightWatcherContext.SaveChangesAsync();
            Card c = new Card()
            {
                SubscriberId = s.Id,
                Height = h,
                Weight = 0,
                BMI = 0,
                OpenDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            _weightWatcherContext.Cards.Add(c);
           await _weightWatcherContext.SaveChangesAsync();
            BaseResponse b2 = new BaseResponse();
            b2.Succeed = true;
            b2.Message = "Added successfully";
            return b2;

        }


    }
}
