using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

//*****************************************************
// aþagýdaki satýrlar Authorize iþlemi için gerekli olan admýmlardýr

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

builder.Services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });

//******************************************************

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Birim}/{action=Index}/{id?}");

app.Run();
