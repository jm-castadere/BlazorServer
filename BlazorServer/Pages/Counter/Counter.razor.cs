using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.JSInterop;

namespace BlazorServer.Pages
{
    public class CounterBase : ComponentBase
    {

        protected int currentCount = 0;

        //inject JS Runtime
        [Inject] protected IJSRuntime JSRuntine { get; set; }

        //Parameter of URL
        [Parameter]
        public int Valuecount
        {
            get => currentCount;
            set => currentCount = value;
        }

        //Parameter
        [Parameter] public int InitialCount { get; set; }


        protected bool Loading { get; private set; }

        protected string Color { get; private set; }


        /// <summary>
        /// increment
        /// </summary>
        /// <param name="e">button events</param>
        protected async void IncrementCount(MouseEventArgs e)
        {
            //task key down
            if (e.AltKey)
            {
                currentCount += 5;
            }
            else
            {
                currentCount++;
            }

            Color = currentCount >= 10 ? "red" : "blue";

            //Call javascript
            if (currentCount >= 8)
            {
                //CALL global js function window.displayAlert
                await JSRuntine.InvokeVoidAsync("displayAlert", currentCount - 1);
            }
        }

        
        /// <summary>
        /// function call with JS
        /// </summary>
        [JSInvokable]
        public async Task IncrementBy3()
        {
            currentCount += 3;

            await InvokeAsync(StateHasChanged);
        }

        
        /// <summary>
        /// Call first
        /// </summary>
        protected override void OnInitialized()
        {
            Console.WriteLine("OnInitialized");
            Loading = true;

            //test wait time  seconde
            _ = Task.Delay(1500).ContinueWith(_ =>
            {
                Loading = false;

                //important ->grafic changed
                InvokeAsync(StateHasChanged);
            });


            base.OnInitialized();
        }

        /// <summary>
        /// after render
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //first render
            if (firstRender)
            {
                //JS create reference of object for JS
                var thisRef = DotNetObjectReference.Create(this);
                //save component ref in js global
                await JSRuntine.InvokeVoidAsync("storeRefComponent", thisRef);
            }

            await base.OnAfterRenderAsync(firstRender);
        }


        /// <summary>
        /// Paremetr of page changed
        /// </summary>
        protected override void OnParametersSet()
        {
            if (InitialCount > 0)
            {
                currentCount = InitialCount;
            }

            base.OnParametersSet();
        }
    }
}








