using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            decimal totalAmount = 0;
            foreach (var item in GetSessionData())
            {
                totalAmount += item.Amount;
            }

            var cart = new ShoppingCart()
            {
                shoppingCartItems = GetSessionData(),
                TotalAmount = totalAmount,
            };
            return View(cart);
        }

        public List<ShoppingCartItem> GetSessionData()
        {
            var cartItems = HttpContext.Session.GetString("items");
            if (cartItems is null)
            {
                return new List<ShoppingCartItem>();
            }

            var data = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(cartItems);
            return data!;
        }

        public IActionResult AddToCart(Product p, int Quantity = 1)
        {
            var products = GetSessionData();
            AddProduct(products, p, Quantity);

            SetSessionData(products);

            return RedirectToAction("Index");
        }
        private void AddProduct(List<ShoppingCartItem> shoppingCartItems, Product p, int Adet)
        {
            var result = shoppingCartItems.FirstOrDefault(x => x.ProductID == p.ID);

            if (result is not null)
            {
                result.Quantity += Adet;
            }
            else
            {
                shoppingCartItems.Add(new ShoppingCartItem()
                {
                    ProductID = p.ID,
                    ProductName = p.Name,
                    ProductUnitPrice = p.Price,
                    Quantity = Adet
                }
                );
            }
        }
        private void RemoveProduct(List<ShoppingCartItem> shoppingCartItems, int id, int adet)
        {
            var record = shoppingCartItems.FirstOrDefault(x=> x.ProductID == id);

            if (record is not null)
            {
                if (record.Quantity > adet)
                {
                    record.Quantity -= adet;
                }
                else
                {
                    shoppingCartItems.Remove(record);
                }
            }
        }
        public IActionResult RemoveToCart(int id, int Quantity = 1)
        {
            var products = GetSessionData();

            RemoveProduct(products, id, Quantity);

            SetSessionData(products);

            return RedirectToAction("Index");
        }
        public IActionResult ClearSession()
        {
            return View();
        }
        public void SetSessionData(List<ShoppingCartItem> shoppingCartItems)
        {
            var data = JsonConvert.SerializeObject(shoppingCartItems);


            HttpContext.Session.SetString("items", data);

            
        }



    }
}
