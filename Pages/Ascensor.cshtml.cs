using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webAscensor.Models;

namespace webAscensor.Pages
{
    public class AscensorModel : PageModel
    {
       
        private readonly IHttpClientFactory _httpClientFactory; 
        public AscensorModel(IHttpClientFactory httpClientFactory) { _httpClientFactory = httpClientFactory; }
        public AscensorStatus Status { get; private set; }
        public async Task OnGetAsync() 
        { 
            var client = _httpClientFactory.CreateClient(); 
            Status = await client.GetFromJsonAsync<AscensorStatus>("https://localhost:7242/api/Ascensor/status");
        }
        public async Task<IActionResult> OnPostCallElevatorAsync(int floor) 
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7242/api/Ascensor/call", new AscensorRequest { Floor = floor });
            Status = await response.Content.ReadFromJsonAsync<AscensorStatus>();
            return Page();
        }
        public async Task<IActionResult> OnPostOpenDoorsAsync()
        { 
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7242/api/Ascensor/open", null);
            Status = await response.Content.ReadFromJsonAsync<AscensorStatus>();
            return Page();
        }
        public async Task<IActionResult> OnPostCloseDoorsAsync() 
        { 
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7242/api/Ascensor/close", null);
            Status = await response.Content.ReadFromJsonAsync<AscensorStatus>(); 
            return Page();
        }
        public async Task<IActionResult> OnPostStartElevatorAsync()
        { 
            var client = _httpClientFactory.CreateClient(); 
            var response = await client.PostAsync("https://localhost:7242/api/Ascensor/start", null);
            Status = await response.Content.ReadFromJsonAsync<AscensorStatus>();
            return Page(); 
        }
        public async Task<IActionResult> OnPostStopElevatorAsync() 
        {
            var client = _httpClientFactory.CreateClient(); 
            var response = await client.PostAsync("https://localhost:7242/api/Ascensor/stop", null);
            Status = await response.Content.ReadFromJsonAsync<AscensorStatus>(); 
            return Page(); 
        }
    }
}
