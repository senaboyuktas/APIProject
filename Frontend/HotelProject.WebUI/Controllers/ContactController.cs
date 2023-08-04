using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Authorization;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        { 
            return View(); 
        }
        
        //public async Task<IActionResult> Index()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:22261/api/MessageCategory");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

        //        List<SelectListItem> categoyValues = (from x in values
        //                                              select new SelectListItem
        //                                              {
        //                                                  Text = x.Name,
        //                                                  Value = x.MessageCategoryID.ToString()
        //                                              }).ToList();

        //        ViewBag.categories = categoyValues;

        //        return View();
        //    }

        //    return View();
        //}

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:22261/api/Contact", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
