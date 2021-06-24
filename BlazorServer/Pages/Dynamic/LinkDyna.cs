using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorServer.Pages.Dynamic
{
    public class LinkDyna :ComponentBase
    {
        /// <summary>
        /// Create component
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            builder.OpenElement(0, "a");
            builder.AddAttribute(1, "href","http://www.castadere-web.com");
            builder.AddAttribute(2, "class", "form-control");
            builder.AddContent(3, "Castadere Web");
            builder.CloseElement();
        }
    }
}
