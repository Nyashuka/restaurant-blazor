
// Configure the Dependency Injection
using Microsoft.AspNetCore.Http.Features;

using RestaurantApp.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddRazorPages(options => 
    {
        options.RootDirectory = "/Presentation/Pages";
    });

    builder.Services.Configure<FormOptions>(options =>
    {
        options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AnonymousOnly", policy =>
        {
            policy.RequireAssertion(context =>
                !context.User.Identity.IsAuthenticated);
        });
    });


    builder.Services.AddServerSideBlazor();

    builder.Services.AddLibraries();
    builder.Services.AddDatabaseService();
    builder.Services.AddRepositories();
    builder.Services.AddServices();
}

// Configure the HTTP request pipeline.
var app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.UseAuthentication();
    app.UseAuthorization();


    app.Run();
}
