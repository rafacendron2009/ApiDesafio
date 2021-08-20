using api_1.Services;
using Xunit;

namespace teste.test.Api1
{
    public class TaxaJuros
    {
        [Fact]
        public void GetInterestRate()
        {

            var interestRateController = new InterestRateServices();
            var actionResult = interestRateController.GetInterestRate();
            Assert.NotNull(actionResult);
            Assert.Contains(actionResult.Result.Success.ToString(), "True");
        }
    }
}
