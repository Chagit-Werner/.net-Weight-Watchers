using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.core.interfaces_Service;
using Weight_Watchers.core.Response;
using Weight_Watchers.core.DTO;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.service.BL
{
    public class WeightWatchersService : IWeightWatcherService
    {
        readonly IMapper _mapper;
        readonly IWeightWatchersRepository _weightWatchersRepository;
        public WeightWatchersService(IMapper mapper, IWeightWatchersRepository weightWatchersRepository)
        {
            _mapper = mapper;
            _weightWatchersRepository = weightWatchersRepository;
        }
        public async Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id)
        {
            BaseResponseGeneral<SubscriberAndCard> response = new BaseResponseGeneral<SubscriberAndCard>();
            //אם אין כזה כרטיס
            if (!_weightWatchersRepository.IsCardExist(id))
            {
                response.Succeed = false;
                response.Message = "could not find card with such id.";
            }
            else
            {
                response = await _weightWatchersRepository.GetById(id);
                response.Succeed = true;
                response.Message = "Found by Id!!!!!";
            }
            return response;
        }

        public async Task<BaseResponseGeneral<int?>> Login(string email,string password )
        {
            BaseResponseGeneral<int?> response = new BaseResponseGeneral<int?>();

            if (!IsValidEmail(email) )
            {
                response.Succeed = false;
                response.Message = "InValid Email";
                response.Data = null;
                return response;
            }
            if (!_weightWatchersRepository.IsSubscriberExist(email))
            {
               ///אין כזה בן אדם!!!   

                response.Succeed = false;
                response.Message = "no such person. You have to register";
                response.Data = null;
                return response;
            }
            if (!IsValdPassword(password))
            {
                response.Succeed = false;
                response.Message = "Invalid password";
                response.Data = null;
                return response;
            }
           int? cardId= await _weightWatchersRepository.Login(email, password );
            response.Succeed = true;
            response.Message = "login successfully";
            response.Data = cardId;
            return response;

        }

        public async Task<BaseResponse> Register(SubscriberDTO s1)
        { 
            //קצת מוזר, אבל פעלתי עפ"י ההנחיות
            //המורה דרשה שלא לבדוק האם המייל והסיסמא תקינים.
            BaseResponse b= new BaseResponse();
            if (s1.Email == null)
            { b.Succeed = false; b.Message = "nust add email to register"; }
            if (_weightWatchersRepository.IsSubscriberExist(s1.Email))
            {
                //כבר יש כזה בן אדם ולכן לא יורדים רמה מתחת.
                b.Succeed = false;
                b.Message = "subscriber already exists!";
                return b;
            }
            return await _weightWatchersRepository.Register(_mapper.Map<Subscriber>(s1), s1.Height);


        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValdPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 4;
        }
    }
}
