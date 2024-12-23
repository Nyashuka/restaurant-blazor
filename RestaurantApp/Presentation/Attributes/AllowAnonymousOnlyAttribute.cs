using Microsoft.AspNetCore.Authorization;

namespace RestaurantApp.Presentation.Attributes;

public class AllowAnonymousOnlyAttribute : AuthorizeAttribute
{
    public AllowAnonymousOnlyAttribute()
    {
        Policy = "AnonymousOnly";
    }
}