namespace RestaurantApp.Presentation.Services;

public class SidebarStateService
{
    public event Action? OnSidebarStateChanged;

    private bool _isSidebarVisible = false;
    public bool IsSidebarVisible
    {
        get => _isSidebarVisible;
        set
        {
            if (_isSidebarVisible != value)
            {
                _isSidebarVisible = value;
                OnSidebarStateChanged?.Invoke();
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
                OnSidebarStateChanged?.Invoke();
            }
        }
    }

    public event Func<int, Task>? OnCategorySelected;

    public async Task SelectCategory(int categoryId)
    {
        if (OnCategorySelected is not null)
        {
            var handlers = OnCategorySelected.GetInvocationList()
                                             .Cast<Func<int, Task>>();

            await Task.WhenAll(handlers.Select(handler => handler(categoryId)));
        }
    }
}