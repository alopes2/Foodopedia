using System;
using System.Net;

namespace Foodopedia.Core.Exceptions
{
    public class HttpErrorException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Title { get; set; }

        public HttpErrorException(string message, HttpStatusCode status, string title = "An unexpected error occurred.")
            : base(message)
        {
            StatusCode = status;
            Title = title;
        }
    }
}