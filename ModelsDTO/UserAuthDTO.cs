using Microsoft.AspNetCore.Identity;

namespace AHRestAPI.ModelsDTO
{
    public class UserAuthDTO
    {
        public string userPhone { get; set; }
        public string userPassword { get; set; }
    }
}
