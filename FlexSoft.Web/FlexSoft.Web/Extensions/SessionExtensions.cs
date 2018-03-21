using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlexSoft.Infrastructure.Entites.IdentityModels;

namespace FlexSoft.Web.Extensions
{
    public static class SessionExtensions
    {
        private static string UserKey = "user";
        public static User User(this HttpSessionStateBase session) => (User)session[UserKey];

        public static void SetUser(this HttpSessionStateBase session, User user)
        {
            session[UserKey] = user;
        }
    }
}