using consoletestproject.ConsoleHelper;
using consoletestproject.Extensions;

namespace consoletestproject.Menus
{
    /// <summary>
    /// Represents a service for managing menu and menu interaction.
    /// </summary>
    public class MenuService
    {
        /// <summary>
        /// The list of menus managed by the service, this variable is automatically updated everytime a new menu is created
        /// </summary>
        public static List<Menu> menus = [];

        /// <summary>
        /// Represents the current menu being displayed / visited.
        /// </summary>
        /// 
        public static Menu? currentMenu = null;

        /// <summary>
        /// Backing field to avoid recursion in the selectedMenuOptionIndex proprety.
        /// </summary>
        private static int _selectedMenuOptionIndex = -1;

        /// <summary>
        /// Gets or sets the index of the currently selected menu option.
        /// </summary>
        /// <remarks>
        /// This property manages the index of the currently selected menu option within the <see cref="MenuService.currentMenu"/>.
        /// When the index is set, it updates the internal state and triggers actions associated <see cref="MenuService.SetMenuOptionSelected(int)"/> with the selected menu option index.
        /// </remarks>
        /// <value>
        /// The index of the currently selected menu option. Initialized to -1 if no option is selected.
        /// </value>
        public static int selectedMenuOptionIndex {
            get => _selectedMenuOptionIndex;
            set {
                _selectedMenuOptionIndex = value;
                if (value != -1)
                    MenuService.SetMenuOptionSelected(value);
            }

        }

        /// <summary>
        /// Handles user input for menu navigation and option selection based on keyboard arrow keys (Up, Down) and Enter key.
        /// </summary>
        /// <param name="keyPressed">If <c>null</c> the function calls ConsoleInput.GetKey() themselves, if not <c>null</c> the function will use this parameter</param>
        /// <remarks>
        /// This method listens for specific keystrokes from the user and adjusts the selected menu option index accordingly: <br> </br>
        /// - UpArrow/NumpadUp: Moves selection upwards in the menu options list. If already at the top, wraps around to the bottom. <br> </br>
        /// - DownArrow/NumpadDown: Moves selection downwards in the menu options list. If already at the bottom, wraps around to the top. <br> </br>
        /// - Enter/RightArrow/NumpadRight: Executes the action associated with the currently selected menu option. <br> </br>
        /// </remarks>
        /// <seealso cref="MenuService.selectedMenuOptionIndex"/>
        /// <seealso cref="Menu"/>
        public static void HandleMenuKeyboardInput(ConsoleKey? keyPressed = null) {
            keyPressed ??= ConsoleInput.GetKey();

            // Check if there's a current menu to operate on
            if (MenuService.currentMenu == null)
                return;

            switch (keyPressed) {
                case ConsoleKey.NumPad8: // numpad up
                case ConsoleKey.UpArrow:
                    if (MenuService.selectedMenuOptionIndex == 0)
                        MenuService.selectedMenuOptionIndex = MenuService.currentMenu.menuOptions.Count - 1;
                    else if (MenuService.currentMenu?.menuOptions.IsValidIndex(selectedMenuOptionIndex) == true)
                        do {
                            selectedMenuOptionIndex--; // Move selection upwards
                        } // Till it finds a valid to "select" / go to
                        while (MenuService.currentMenu.menuOptions.IsValidIndex(selectedMenuOptionIndex) && MenuService.currentMenu.menuOptions[selectedMenuOptionIndex].isDisabled);
                    break;
                case ConsoleKey.NumPad2: // numpad down
                case ConsoleKey.DownArrow:
                    if (MenuService.selectedMenuOptionIndex < 0 || MenuService.currentMenu.menuOptions.IsValidIndex(MenuService.selectedMenuOptionIndex) == true)
                        do {
                            selectedMenuOptionIndex++; // Move selection downwards
                        } // Till it finds a valid place to "select" / go to
                        while (MenuService.currentMenu.menuOptions.IsValidIndex(selectedMenuOptionIndex) && MenuService.currentMenu.menuOptions[selectedMenuOptionIndex].isDisabled);
                    if (MenuService.currentMenu?.menuOptions.Count == MenuService.selectedMenuOptionIndex)
                        MenuService.selectedMenuOptionIndex = 0;
                    break;
                case ConsoleKey.NumPad6: //numpad right
                case ConsoleKey.RightArrow:
                case ConsoleKey.Enter:
                    Console.WriteLine();
                    if (MenuService.currentMenu?.menuOptions.IsValidIndex(MenuService.selectedMenuOptionIndex) == true)
                        MenuService.currentMenu?.menuOptions[MenuService.selectedMenuOptionIndex].Execute();
                    break;
            }
        }

        /// <summary>
        /// Keeps track of the history of menus that have been displayed / visited.
        /// </summary>
        public static List<Menu> menuHistory = [];

        /// <summary>
        /// Sets the current menu to the specified menu and adds it to the menu history.
        /// </summary>
        /// <param name="menu">The menu to set as the current menu.</param>
        public static void SetCurrentMenu(Menu menu) {
            if (MenuConfig.displayCurrentMenuAsConsoleTitle)
                Console.Title = $"{menu.name} [{menu.id}]";

            MenuService.currentMenu = menu;
            MenuService.menuHistory.Add(menu);
        }

        /// <summary>
        /// Retrieves the previous menu from the history of menus displayed / visited, it will keep going back in history till it finds the previous menu
        /// </summary>
        /// <returns>The previous menu from the history, or <c>null</c> if there's no previous menu.</returns>
        public static Menu? GetPreviousMenuFromHistory() {
            List<Menu> menuHistory = MenuService.GetMenuHistory();
            int historyIndex = menuHistory.Count - 1; // Start from the end of the history

            // Traverse the menu history from the end towards the beginning
            while (historyIndex > 0 && MenuService.currentMenu?.id == menuHistory[historyIndex - 1].id) {
                historyIndex--; // Move to the previous menu until finding a different one
            }

            // If a different menu is found before reaching the beginning of the history, return it; otherwise, return null
            return historyIndex > 0 ? menuHistory[historyIndex - 1] : null;
        }

        /// <summary>
        /// Retrieves the entire menu history.
        /// </summary>
        /// <returns>The list of menus displayed / visited.</returns>
        public static List<Menu> GetMenuHistory() => MenuService.menuHistory;

        /// <summary>
        /// Adds one or more menus to the service. However, there is no need to use this method directly as the list is automatically managed every time you create a new menu.
        /// </summary>
        /// <param name="menuOptions">The menus to be added.</param>
        static public void AddMenus(params Menu[] menuOptions) => MenuService.menus.AddRange(menuOptions);

        /// <summary>
        /// Retrieves all menus managed by the service.
        /// </summary>
        /// <returns>The list of menus.</returns>
        static public List<Menu> GetMenus() => MenuService.menus;

        /// <summary>
        /// Retrieves a menu by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the menu.</param>
        /// <returns>The menu with the specified ID, or <c>null</c> if not found.</returns>
        static public Menu? GetMenuById(int id) => MenuService.menus.Find(menu => menu.id == id);

        /// <summary>
        /// Displays the menu with the specified unique identifier on the console
        /// </summary>
        /// <param name="id">The unique identifier of the menu to be displayed.</param>
        static public void ShowById(int id) => MenuService.GetMenuById(id)?.Show();

        /// <summary>
        /// Sets the specified menu option as selected and updates the display accordingly.
        /// </summary>
        /// <param name="index">The zero-based index of the menu option to select.</param>
        /// <remarks>
        /// This method checks if there is a current menu set in <see cref="MenuService.currentMenu"/>.
        /// If the current menu exists and contains valid menu options at the specified index,
        /// it sets the specified menu option to appear as selected (typically underlined) and refreshes the console display
        /// to reflect the updated selection.
        /// </remarks>
        static public void SetMenuOptionSelected(int index) {
            if (MenuService.currentMenu != null) {
                List<MenuOption>? menuOptions = MenuService.currentMenu.GetMenuOptions();
                if (menuOptions != null && menuOptions.IsValidIndex(index)) {
                    if (menuOptions[index].isDisabled)
                        return;
                    MenuService.currentMenu.SetOptionSelectedDecoration(index);
                    Console.Clear();
                    MenuService.currentMenu.Show();
                }
            }
        }

        /// <summary>
        /// Removes a menu from the service based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the menu to remove.</param>
        /// <c>true</c> if the menu was removed; <c>false</c> if no menu was found by the specified id.
        static public bool RemoveById(int id) {
            int numRemoved = MenuService.menus.RemoveAll(menu => menu.id == id);
            return numRemoved > 0;
        }

        /// <summary>
        /// Clears all menus from the service, resetting the list to an empty state.
        /// </summary>
        static public void Clear() => menus.Clear();

        /// <summary>
        /// Retrieves the first menu found with a specific name.
        /// </summary>
        /// <param name="name">The name of the menu to retrieve.</param>
        /// <returns>The first menu with the specified name, or <c>null</c> if none is found.</returns>
        static public Menu? GetMenuByName(string name) => MenuService.menus.Find(menu => menu.name == name);

        /// <summary>
        /// Retrieves all menus with a specific name.
        /// </summary>
        /// <param name="name">The name of the menus to retrieve.</param>
        /// <returns>The list of menus with the specified name, or <c>null</c> if none are found.</returns>
        static public List<Menu>? GetMenusByName(string name) {
            List<Menu> foundMenus = [.. MenuService.menus.FindAll(menu => menu.name == name)];
            return foundMenus.Count > 0 ? foundMenus : null;
        }

        /// <summary>
        /// Generates a unique menu ID that is not already in use by any existing menu.
        /// </summary>
        /// <returns>A unique menu ID.</returns>
        public static int GetUniqueMenuId() {
            // Find the maximum ID currently used in menus
            int maxIdInUse = menus.Count > 0 ? menus.Max(menu => menu.id) : 0;

            return maxIdInUse + 1337; // Add a large num like 1337 so the id won't interfere with other ids.
        }
    }
}
