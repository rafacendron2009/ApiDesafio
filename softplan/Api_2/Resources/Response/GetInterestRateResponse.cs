namespace api_2.Resources.Response
{
    public class GetInterestRateResponse : BaseResponse
    {
        public double InterestRate { get; set; }

        public GetInterestRateResponse(bool success, string message,  double interestRate) : base(success, message)
        {
            InterestRate = interestRate;
        }

        public GetInterestRateResponse( double interestRate) : this(true, string.Empty, interestRate) { }

        public GetInterestRateResponse(string message) : this(false, message, 0) { }
    }
}