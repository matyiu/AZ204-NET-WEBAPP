using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;

namespace AZ_204_WindowsWebApp.Pages
{
    public class CPULoadModel: PageModel
    {
        private readonly IFeatureManager _featureManager;

        public long counter = 0;
        public long elapsedMs;

        public bool isCpuLoadEnabled;

        public CPULoadModel(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<bool> IsCpuLoadEnabled()
        {
            if (await _featureManager.IsEnabledAsync("CPULoad"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task OnGet()
        {
            if (await _featureManager.IsEnabledAsync("CPULoad"))
            {
                isCpuLoadEnabled = this.IsCpuLoadEnabled().Result;

                var watch = System.Diagnostics.Stopwatch.StartNew();

                while (counter < 1000000000000000)
                {
                    counter = counter + 1;
                }

                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
            }
        }
    }
}
