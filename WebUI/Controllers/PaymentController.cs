using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos;

namespace WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ICoreService<Order> _db;
        private readonly IMapper _mapper;

        public PaymentController(ICoreService<Order> coreService, IMapper mapper)
        {
            _db = coreService;
            _mapper = mapper;
        }

        public IActionResult Payment()
        {
            return View();
        }


        public async Task<IActionResult> Pay(PayDto data)
        {

            using (HttpClient client = new HttpClient())
            {
                //var data = new PayDto()
                //{
                //    Name = p.Name,
                //    Surname = p.Surname,
                //    IdentityNumber = p.IdentityNumber,
                //    CardNumber = p.CardNumber,
                //    CardDate = p.CardDate,
                //    CVV = p.CVV,
                //    Price = p.Price
                //};

                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5106/api/Pay/Take", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

                    if (result)
                    {
                        //Order siparis = new()
                        //{
                        //    BillingAddress = data.BillingAddress,
                        //    OrderDate = DateTime.Now,                           
                        //    DiscountCode = data.DiscountCode,
                        //    ShippingAddress = data.ShippingAddress,
                        //    CreatedDate = DateTime.Now,
                        //    TotalAmount = data.Price,
                        //};

                        Order siparis = _mapper.Map<Order>(data);

                        bool orderResult = _db.Create(siparis);

                        return orderResult ? View("PaymentSuccess") : View("PaymentError");
                    }
                }
            }

            return View();
            
        }
    }
}
