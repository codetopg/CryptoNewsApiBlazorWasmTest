using Microsoft.AspNetCore.Components;

namespace CryptoNewBlazorWasm.Pages
{
    public partial class Counter
    {
        [Parameter]
        public int? Increment { get; set; }
        [Parameter]
        public string? RouteName { get; set; }

        private int increment = 1;


        protected override void OnParametersSet()
        {
            if (Increment.HasValue)
            {
                increment = Increment.Value;
            }
        }

        private int currentCount = 0;
        private void IncrementCount()
        {
            currentCount += increment;
        }



        protected override void OnInitialized()
        {
            RouteName = RouteName ?? "Tom";
        }
    }
}