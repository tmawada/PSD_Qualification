using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFrontend.Modules
{
    public class Response<T>
    {
        public Boolean IsSuccess { get; set; }
        public String Message { get; set; }
        public T Payload { get; set; }
    }
}