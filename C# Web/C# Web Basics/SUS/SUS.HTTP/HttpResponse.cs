using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            this.StatusCode = statusCode;
            this.Body = body;
            this.Headers = new List<Header>
            {
                { new Header("Content-Type", contentType) },
                { new Header("Content-Length", body.Length.ToString()) },
                { new Header("Server", "SUS Server 1.0") },
            };
        }
        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + "\n\r");
            foreach (var header in this.Headers)
            {
                responseBuilder.Append(header.ToString() + "\n\r");
            }

            responseBuilder.Append("\r\n");

            return responseBuilder.ToString();
        }
    }
}
