using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Repository.Data;

namespace Talabat.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly StoreContext context;

        public BuggyController( StoreContext context)
        {
            this.context = context;
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = context.products.Find(100);

            return Ok(product.ToString());

        }
    }
}
