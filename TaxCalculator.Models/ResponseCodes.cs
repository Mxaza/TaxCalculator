namespace TaxCalculator.Models
{
    public static class ResponseCodes
    {
        public const int Ok = 200;
        public const int NoContent = 204;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int ImATeapot = 418;
        public const int InternalServerError = 500;
        public const int ServiceUnavailable = 503;        
    }
}
