using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream(); // Akış oluşturduk
            await file.CopyToAsync(stream); // Dosyayı kopyaladık
            var bytes = stream.ToArray(); // Byte olarak dosyayı tuttuk

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var httpClient = new HttpClient();
            await httpClient.PostAsync("http://localhost:22261/api/FileImage", multipartFormDataContent);

            return View();
        }
    }
}
