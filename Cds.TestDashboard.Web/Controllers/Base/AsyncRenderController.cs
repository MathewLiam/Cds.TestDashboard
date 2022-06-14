using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Cds.TestDashboard.Web.Controllers.Base
{
    public abstract class AsyncRenderController : RenderController
    {
        protected AsyncRenderController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }

        [NonAction]
        public override IActionResult Index() => throw new NotImplementedException();

        public abstract Task<IActionResult> Index(CancellationToken cancellationToken = default(CancellationToken));
    }
}
