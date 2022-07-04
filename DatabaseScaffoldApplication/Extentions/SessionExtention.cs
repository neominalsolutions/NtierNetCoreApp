using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DatabaseScaffoldApplication.Extentions
{
    public static class SessionExtention
    {

        public static void SetObject<T>(this ISession session,string key,T value)
        {
            var jsonString = JsonSerializer.Serialize(value);
            session.SetString(key, jsonString);

        }

        public static T GetObject<T>(this ISession session,string key) 
            where T:class
        {


            if (session.Get(key) != null)
            {
                var jsonObject = JsonSerializer.Deserialize<T>(session.GetString(key));

                return jsonObject;
            }

            return null;
            
        }
    }
}
