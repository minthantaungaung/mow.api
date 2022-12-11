using System.Net;
using api.mov.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.mov.Controllers
{
    [AllowAnonymous]
    public static class Orders
    {
        static db_a8f2df_4fandaContext ctx = new db_a8f2df_4fandaContext();
        public static void OrderEndpoints(this WebApplication app)
        {
            app.MapGet("api/order/GetAll", () =>
            {
                var result = ctx.Orders.ToList();
                return result;
            });

            app.MapPost("api/order/AddOrder", (Order order) =>
            {
                try{
                    ctx.Add(order);
                    ctx.SaveChangesAsync();
                    return true;
                }catch{ return false; }
            });

            app.MapGet("api/order/GetOrderByID", (int ID) =>
            {
                var result = ctx.Orders.FirstOrDefault(x => x.OrderId == ID);
                return result;
            });

            app.MapPost("api/order/UpdateOrder", (Order order) =>
            {
                var result = ctx.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                try
                {
                    if (result != null)
                    {
                        result.OrderNo = order.OrderNo;
                        result.OrderDesc = order.OrderDesc;
                        result.OrderDatetime = order.OrderDatetime;
                        result.VolundeerId = order.VolundeerId;
                        ctx.Orders.Update(result);
                        ctx.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return result;
            });
        }
    }
}
