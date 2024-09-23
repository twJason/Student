using Newtonsoft.Json;
using YunTech.Models;

namespace YunTech.Services
{
    public class ResponseConver
    {
        public static ResponseModel Suc(object data)
        {
            return new ResponseModel()
            {
                Code = 1,
                Data = JsonConvert.SerializeObject(data)
            };
        }

        public static ResponseModel Err(string errMsg)
        {
            return new ResponseModel()
            {
                Code = 0,
                Data = errMsg
            };
        }

    }
}
