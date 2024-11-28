namespace RestaurantApp.Domain.Constants;

using RestaurantApp.Domain.Enums;

public class RoleStorage
{
    public static readonly Dictionary<RoleEnum, string> Roles = new Dictionary<RoleEnum, string>()
    {
        { RoleEnum.User, "User" },
        { RoleEnum.Chief, "Chief" },
        { RoleEnum.Manager, "Manager" },
    };

    public static string GetRoleName(RoleEnum roleEnum)
    {
        return Roles[roleEnum];
    }
}