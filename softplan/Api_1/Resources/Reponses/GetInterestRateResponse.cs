namespace api_1.Resources.Response
{
    public class GetInterestRateResponse : BaseResponse
    {
        public GetInterestRateResource InterestRate { get; set; }

        public GetInterestRateResponse(bool success, string message, GetInterestRateResource interestRate) : base(success, message)
        {
            InterestRate = interestRate;
        }

        public GetInterestRateResponse(GetInterestRateResource interestRate) : this(true, string.Empty, interestRate) { }

        public GetInterestRateResponse(string message) : this(false, message, null) { }
    }
}