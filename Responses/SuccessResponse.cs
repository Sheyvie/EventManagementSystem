namespace EventManagement.Responses
{
    public class SuccessResponse
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public SuccessResponse(int c, string m)
        {
            this.Code = c;
            this.Message = m;
        }
    }
}
