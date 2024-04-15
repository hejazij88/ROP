using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    class UserServices
    {
        public ActionResult<int> UpdateProfile(User user)
        {
            //if (string.IsNullOrEmpty(user.Name))
            //    return ActionResult.Failure<int>("Name Is Required");

            //if (user.Name.Length > 50)
            //    return ActionResult.Failure<int>("Name Must Be Less Than 50");

            //if(string.IsNullOrEmpty(user.Email))
            //    return ActionResult.Failure<int>("Email Is Required");


            var result = ActionResult.CreateValidator(user)
                .Validate(x => string.IsNullOrEmpty(user.Name), "Name Is Required")
                .Validate(x => user.Name.Length > 50, "Name Is Required")
                .Validate(x => string.IsNullOrEmpty(user.Email), "Email Is Required");

            if (!result.IsSuccess)
                return ActionResult.Failure<int>(result.Message);

                return ActionResult.Success<int>(15151);
        }
    }
}
