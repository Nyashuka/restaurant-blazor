using System.ComponentModel.DataAnnotations;

using RestaurantApp.Domain.Enums;

namespace RestaurantApp.Domain.Models;

public class User
{
    public int Id { get; private set; }
    public RoleEnum Role { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email  { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
}