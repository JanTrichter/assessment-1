using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private static UserModel user = new UserModel()
        {
            AccountBalance = 10000M,
            Username = "Jeff"
        };

        private static ShareModel share = new ShareModel()
        {
            SharePrice = 132.48M,
            ShareName = "Apple"
        };


        [HttpGet("/user")]
        public async Task<ActionResult<UserModel>> GetUserInfo()
        {
            return Ok(user);
        }

        [HttpGet("/share")]
        public async Task<ActionResult<ShareModel>> GetShareInfo()
        {
            return Ok(share);
        }

        [HttpPost("buy/{amount}")]
        public async Task<ActionResult<UserModel>> BuyShares(int amount)
        {
            var totalOrderVolume = amount * share.SharePrice;

            if (amount < 1)
            {
                return BadRequest("You cannot order less than 1 share");
            }

            if (totalOrderVolume > user.AccountBalance)
            {
                return BadRequest("Your account balance is too low for this purchase!");
            }

            user.NumberOfShares += amount;
            user.AccountBalance -= totalOrderVolume;

            return Ok(user);
        }
    }
}
