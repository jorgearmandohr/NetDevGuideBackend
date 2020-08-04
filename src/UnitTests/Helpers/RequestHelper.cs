using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

using Newtonsoft.Json;

namespace UnitTests.Helpers
{
    internal static class RequestHelper
    {
        internal static DefaultHttpRequest MockRequest(string body)
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext());
            var jsonObj = JsonConvert.SerializeObject(body);
            var byteArray = Encoding.ASCII.GetBytes(jsonObj);
            var memoryStream = new MemoryStream(byteArray);

            /*memoryStream.Flush(); memoryStream.Position = 0;*/

            request.Body = memoryStream;

            return request;
        }
    }
}
