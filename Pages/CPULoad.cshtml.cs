using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZ_204_WindowsWebApp.Pages
{
    public class CPULoadModel: PageModel
    {
        public long counter = 0;
        public long elapsedMs;

        public void OnGet()
        {
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
