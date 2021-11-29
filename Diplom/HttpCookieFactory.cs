using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom
{

    public class HttpCookieFactory
    {
        public HttpCookie Create(string userLogin, bool isAdmin)
        {
            var cookie = new HttpCookie("Diplom");
            cookie["UserLogin"] = userLogin;
            cookie["IsAdmin"] = isAdmin.ToString(); 
            // если куки нужно сохранять после закрытия браузера
            //cookie.Expires.AddDays(1);
            return cookie;
        }
    }
}