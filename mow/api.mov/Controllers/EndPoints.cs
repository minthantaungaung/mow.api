using api.mov.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.mov.Controller;

public static class member
{
    static db_a8f2df_4fandaContext ctx = new db_a8f2df_4fandaContext();
    public static void TokenProvider(this WebApplication app,IConfiguration configuration)
    {
        app.MapPost("/api/createToken",[AllowAnonymous] (string email, string password) =>
        {
            var checkusr = ctx.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (checkusr != null)
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, checkusr.Name),
                        new Claim(JwtRegisteredClaimNames.Email, checkusr.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                     }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Results.Ok(stringToken);
            }
            return Results.Unauthorized();
        });
    }
    public static void MemberEndpoints(this WebApplication app)
    {
        app.MapPost("/api/user/AddUser", (User user) =>{
            ctx.Users.Add(user);
            ctx.SaveChangesAsync();
            return true;
        }).RequireAuthorization();

        app.MapGet("/api/user/GetAllUser", () => {
            var usr = ctx.Users.ToList();
            return usr;
        }).RequireAuthorization();
        app.MapGet("api/user/GetByID", (int id) =>
        {
            var result = ctx.Users.FirstOrDefault(x => x.UserId == id);
            return result;
        });
        app.MapPost("api/user/UpdateUser", (User usr) =>
        {
            var result = ctx.Users.FirstOrDefault(x => x.UserId == usr.UserId);
            try
            {
                if (result != null)
                {
                    result.Name = usr.Name;
                    result.Role = usr.Role;
                    result.Email = usr.Email;
                    result.Phone = usr.Phone;
                    result.Password = usr.Password;
                    ctx.Users.Update(result);
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
    public static void CustomerEndpoints(this WebApplication app)
    {
        app.MapPost("/api/customer/AddCustomer", (Customer customer) => {
            ctx.Customers.Add(customer);
            ctx.SaveChangesAsync();
            return true;
        }).RequireAuthorization();

        app.MapGet("/api/customer/GetAllCustomer", () => {
            var result = ctx.Customers.ToList();
            return result;
        }).RequireAuthorization();
        
        app.MapGet("api/customer/GetByID", (int ID) =>
        {
            var result = ctx.Customers.FirstOrDefault(x => x.CustomerId == ID);
            return result;
        });
        app.MapPost("api/customer/UpdateCustomer", (Customer cus) =>
        {
            var result = ctx.Customers.FirstOrDefault(x => x.CustomerId == cus.CustomerId);
            try
            {
                if (result != null)
                {
                    result.CustomerName = cus.CustomerName;
                    result.Age = cus.Age;
                    result.Email = cus.Email;
                    result.City = cus.City;
                    result.Township = cus.Township;
                    result.DetailedAddress = cus.DetailedAddress;
                    result.Phone = cus.Phone;
                    ctx.Customers.Update(result);
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
