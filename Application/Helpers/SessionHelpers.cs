using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Core.Application.Helpers
{
    public static class SessionHelpers
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            string jsonData = JsonConvert.SerializeObject(value);
            byte[] bytesData = Encoding.UTF8.GetBytes(jsonData);
            session.Set(key, bytesData);
        }

        public static T Get<T>(this ISession session, string key)
        {
            byte[] bytesData = session.Get(key);
            if (bytesData == null)
            {
                return default;
            }

            string jsonData = Encoding.UTF8.GetString(bytesData);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}


