namespace api_2.Resources.Response
{
    public class ReturnsAmountWithInterestResponse : BaseResponse
    {
        public double Total { get; set; }

        public ReturnsAmountWithInterestResponse(bool success, string message, double total) : base(success, message)
        {
            Total = total;
        }

        public ReturnsAmountWithInterestResponse(double total) : this(true, string.Empty, total) { }

        public ReturnsAmountWithInterestResponse(string message) : this(false, message, 0) { }
    }
}