using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoV10.Controllers {
    public class PageController : RenderController {
        private readonly ILogger<RenderController> _logger;

        public PageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override IActionResult Index() {
            _logger.LogInformation("Someone Viewed the Index");

            if (Request.Query.ContainsKey("warn")) {
                _logger.LogWarning("Someone found the warning inducer.");
            }

            if (Request.Query.ContainsKey("error")) {
                throw new Exception("Someone found the error inducer.");
            }


            return base.Index();
        }
    }
}
