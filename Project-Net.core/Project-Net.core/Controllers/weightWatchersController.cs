using Microsoft.AspNetCore.Mvc;
using Weight_Watchers.core.DTO;
using Weight_Watchers.core.interfaces_Service;
using Weight_Watchers.core.Response;

namespace Project_Net.core.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class weightWatchersController:ControllerBase
    {
        readonly IWeightWatcherService _weightWatcherService;
        public weightWatchersController(IWeightWatcherService weightWatcherService)
        {
            _weightWatcherService= weightWatcherService;
        }
        //POST -- LOGIN
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<BaseResponseGeneral<int?>>> Login(string email,string password)
        {
            BaseResponseGeneral<int?> response = new BaseResponseGeneral<int?>();
            response=  await _weightWatcherService.Login(email, password);
            if (response.Data == null)
                return   Unauthorized(response);
            //להעביר ל-BL
            response.Succeed=true;
            response.Message = "login succeede. get card id as response";
            return Ok(response);

        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<BaseResponseGeneral<SubscriberAndCard>>> GetById(int id)
        {
            BaseResponseGeneral<SubscriberAndCard> response = new BaseResponseGeneral<SubscriberAndCard>();
            response= await _weightWatcherService.GetById(id);
            if (response.Succeed==false)
                return NotFound(response);
            return Ok(response);
        }
        //POST-- REGISTER
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<BaseResponse>>Register (SubscriberDTO s1)
        {
            BaseResponse response =await _weightWatcherService.Register(s1);
            if(!response.Succeed)
                return Conflict(response);
            return Ok(response);
        }

    }
}
