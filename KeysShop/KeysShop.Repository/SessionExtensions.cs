using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetObject(key, value);
/*            session.SetString(key, JsonConvert.SerializeObject(value,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));*/
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            //var value = session.GetString(key);
            var value = session.GetObject<T>(key);
            return value == null ? default(T) : value;
        }
    }
}