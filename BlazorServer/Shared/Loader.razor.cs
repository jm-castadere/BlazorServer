using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServer.Shared
{
    public partial class Loader
    {
        
        //IMPORTANT name ChildContent
        [Parameter] public RenderFragment ChildContent { get; set; }

        //time to show
        [Parameter] public int TimeToShow { get; set; }

        //flag to show message
        private bool _showMessage = true;

        //Timer
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Debug.WriteLine("OnAfterRenderAsync START" + _showMessage.ToString());

            _ = Task.Delay(TimeToShow, cancelToken.Token).ContinueWith(async t =>
            {
                if (t.IsCompletedSuccessfully)
                {

                    //change flag
                    //showMessage = true;

                    Debug.WriteLine("OnAfterRenderAsync END" + _showMessage.ToString());

                    //refresh
                    await InvokeAsync(StateHasChanged);
                }


            });
            
            await base.OnAfterRenderAsync(firstRender);
        }

        
        /// <summary>
        /// before close
        /// </summary>
        public void Dispose()
        {
            //cancel timer
            cancelToken.Cancel();
        }

    }
}
