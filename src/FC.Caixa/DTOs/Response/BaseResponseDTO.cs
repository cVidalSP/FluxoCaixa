using System.Net;

namespace FC.Caixa.DTOs.Response
{
    public class BaseResponseDTO
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
