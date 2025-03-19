using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Services;

public class SidebarStateService
{
    public event Action? SidebarStateChanged;

    private bool _isSidebarVisible = false;
    public bool IsSidebarVisible
    {
        get => _isSidebarVisible;
        set
        {
            if (_isSidebarVisible != value)
            {
                _isSidebarVisible = value;
                SidebarStateChanged?.Invoke();
            }
        }
    }

    public event Action? OnSidebarOpenChanged;

    private bool _isSidebarOpen = false;
    public bool IsSidebarOpen
    {
        get => _isSidebarOpen;
        set
        {
            if (_isSidebarOpen != value)
            {
                _isSidebarOpen = value;
                SidebarStateChanged?.Invoke();
            }
        }
    }

    public event Func<CategoryBase, Task>? OnCategorySelected;

    public async Task SelectCategory(CategoryBase category)
    {
        if (OnCategorySelected is not null)
        {
            var handlers = OnCategorySelected.GetInvocationList()
                                             .Cast<Func<CategoryBase, Task>>();

            await Task.WhenAll(handlers.Select(handler => handler(category)));
        }
    }
}