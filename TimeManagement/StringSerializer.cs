using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManagement
{
    static class StringSerializer
    {
        public static string jSonSerializer(string message)
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                message = new { text = message },
                endpoints = new[] { "dsdsd", "abc", "123" }
            });

            return json;
        }
    }
}
