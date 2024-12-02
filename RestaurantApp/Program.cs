
// Configure the Dependency Injection
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddRazorPages(options =>
    {
        options.RootDirectory = "/Presentation/Pages";
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
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
