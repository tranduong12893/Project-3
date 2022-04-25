using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagement.Models
{
    public class ValidateUser
    {
        public static bool IsUserLogin()
        {
            HttpContext context = HttpContext.Current;
            if(context.Session["user_id"] != null )
            {
                return true;
            }
            return false;
        }
    }
}