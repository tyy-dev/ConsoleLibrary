using consoletestproject.ConsoleHelper;
using consoletestproject.Extensions;

namespace consoletestproject.Menus
{
    /// <summary>
    /// Represents a service for managing menu and menu interaction.
    /// </summary>
    public class MenuService
    {

        #region Public Fields

        /// <summary>
        /// Represents the current menu being displayed / visited.
        /// </summary>
        /// <typeinfo>public static Menu?</typeinfo>
        public static Menu? currentMenu = null;

        /// <summary>
        /// Keeps track of the history of menus that have been displayed / visited.
        /// </summary>
        /// <typeinfo>public static List&lt;Menu></typeinfo>
        public static List<Menu> menuHistory = [];

        /// <summary>
        /// The list of menus managed by the service, this variable is automatically updated everytime a new menu is created
        /// </summary>
        /// <typeinfo>public static List&lt;Menu></typeinfo>
        public static List<Menu> menus = [];

        #endregion Public Fields

        #region Private Fields

        /// <summary>
        /// Backing field to avoid recursion in the selectedMenuOptionIndex property. <br> </br>
        /// See <see cref="selectedMenuOptionIndex"/>
        /// </summary>
        /// <typeinfo>public static int</typeinfo>
        private static int _selectedMenuOptionIndex = -1;

        #endregion Private Fields

        #region Public Properties

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
        /// <typeinfo>public static int</typeinfo>
        public static int selectedMenuOptionIndex {
            get => _selectedMenuOptionIndex;
            set {
                _selectedMenuOptionIndex = value;
                if (value != -1)
                    MenuService.SetMenuOptionSelected(value);
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Adds one or more menus to the service. However, there is no need to use this method directly as the list is automatically managed every time you create a new menu.
        /// </summary>
        /// <param name="menuOptions">The menus to be added.</param>
        /// <typeinfo>static public void</typeinfo>
        public static void AddMenus(params Menu[] menuOptions) => MenuService.menus.AddRange(menuOptions);

        /// <summary>
        /// Clears all menus from the service, resetting the list to an empty state.
        /// </summary>
        /// <typeinfo>static public void</typeinfo>
        public static void Clear() => menus.Clear();

        /// <summary>
        /// Retrieves a menu by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the menu.</param>
        /// <returns>The menu with the specified ID, or <c>null</c> if not found.</returns>
        /// <typeinfo>static public Menu?</typeinfo>
        public static Menu? GetMenuById(int id) => MenuService.menus.Find(menu => menu.id == id);

        /// <summary>
        /// Retrieves the first menu found with a specific name.
        /// </summary>
        /// <param name="name">The name of the menu to retrieve.</param>
        /// <returns>The first menu with the specified name, or <c>null</c> if none is found.</returns>
        /// <typeinfo>static public Menu?</typeinfo>
        public static Menu? GetMenuByName(string name) => MenuService.menus.Find(menu => menu.name == name);

        /// <summary>
        /// Retrieves the entire menu history.
        /// </summary>
        /// <returns>The list of menus displayed / visited.</returns>
        /// <typeinfo>static public List&lt;Menu></typeinfo>
        public static List<Menu> GetMenuHistory() => MenuService.menuHistory;

        /// <summary>
        /// Retrieves all menus managed by the service.
        /// </summary>
        /// <returns>The list of menus.</returns>
        /// <typeinfo>static public List&lt;Menu></typeinfo>
        public static List<Menu> GetMenus() => MenuService.menus;

        /// <summary>
        /// Retrieves all menus with a specific name.
        /// </summary>
        /// <param name="name">The name of the menus to retrieve.</param>
        /// <returns>The list of menus with the specified name, or <c>null</c> if none are found.</returns>
        /// <typeinfo>static public List&lt;Menu>?</typeinfo>
        public static List<Menu>? GetMenusByName(string name) {
            List<Menu> foundMenus = [.. MenuService.menus.FindAll(menu => menu.name == name)];
            return foundMenus.Count > 0 ? foundMenus : null;
        }

        /// <summary>
        /// Retrieves the previous menu from the history of menus displayed / visited, it will keep going back in history till it finds the previous menu
        /// </summary>
        /// <returns>The previous menu from the history, or <c>null</c> if there's no previous menu.</returns>
        /// <typeinfo>public static Menu?</typeinfo>
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
        /// Generates a unique menu ID that is not already in use by any existing menu. <br> </br>
        /// The unique id is also offsetted by 1337 to avoid future id conflicts.
        /// </summary>
        /// <returns>A unique menu ID.</returns>
        /// <typeinfo>public static int</typeinfo>
        public static int GetUniqueMenuId() {
            // Find the maximum ID currently used in menus
            int maxIdInUse = menus.Count > 0 ? menus.Max(menu => menu.id) : 0;
            return maxIdInUse + 1337; // Add a large num like 1337 so the id won't interfere with other ids.
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
        /// <typeinfo>public static void</typeinfo>
        public static void HandleMenuKeyboardInput(ConsoleKey? keyPressed = null) {
            keyPressed ??= ConsoleInput.GetKey();

            // Check if there's a current menu to operate on, if not don't try to handle keyboard input
            if (MenuService.currentMenu == null)
                return;

            switch (keyPressed) {
                case ConsoleKey.NumPad8: // numpad up
                case ConsoleKey.UpArrow:
                    MenuService.MoveMenuSelectionUp();
                    break;

                case ConsoleKey.NumPad2: // numpad down
                case ConsoleKey.DownArrow:
                    MenuService.MoveMenuSelectionDown();
                    break;

                case ConsoleKey.NumPad6: //numpad right
                case ConsoleKey.RightArrow:
                case ConsoleKey.Enter:
                    MenuService.ExecuteSelectedMenuOption();
                    break;
            }
        }

        /// <summary>
        /// Removes a menu from the service based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the menu to remove.</param>
        /// <c>true</c> if the menu was removed; <c>false</c> if no menu was found by the specified id.
        /// <typeinfo>static public bool</typeinfo>
        public static bool RemoveById(int id) {
            int numRemoved = MenuService.menus.RemoveAll(menu => menu.id == id);
            return numRemoved > 0;
        }

        /// <summary>
        /// Sets the current menu to the specified menu and adds it to the menu history.
        /// </summary>
        /// <param name="menu">The menu to set as the current menu.</param>
        /// <typeinfo>public static void</typeinfo>
        public static void SetCurrentMenu(Menu menu) {
            if (MenuConfig.displayCurrentMenuAsConsoleTitle)
                Console.Title = $"{menu.name} [{menu.id}]";

            MenuService.currentMenu = menu;
            MenuService.menuHistory.Add(menu);
        }

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
        /// <typeinfo>static public void</typeinfo>
        public static void SetMenuOptionSelected(int index) {
            if (MenuService.currentMenu != null) {
                List<MenuOption>? menuOptions = MenuService.currentMenu.GetMenuOptions();
                if (menuOptions != null && menuOptions.IsValidIndex(index)) {
                    if (menuOptions[index].isDisabled) // if the option is disabled it will be skipped for selection since disabled options cant be selected
                        return;

                    MenuService.currentMenu.SetOptionSelectedDecoration(index);
                    Console.Clear();
                    MenuService.currentMenu.Show();
                }
            }
        }

        /// <summary>
        /// Displays the menu with the specified unique identifier on the console
        /// </summary>
        /// <param name="id">The unique identifier of the menu to be displayed.</param>
        /// <typeinfo>static public void</typeinfo>
        public static void ShowById(int id) => MenuService.GetMenuById(id)?.Show();

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Executes the action associated with the currently selected menu option.
        /// </summary>
        /// <typeinfo>private static void</typeinfo>
        private static void ExecuteSelectedMenuOption() {
            if (MenuService.currentMenu == null)
                return;

            if (MenuService.currentMenu?.menuOptions.IsValidIndex(MenuService.selectedMenuOptionIndex) == true) {
                Console.WriteLine();
                MenuService.currentMenu.menuOptions[MenuService.selectedMenuOptionIndex].Execute();
            }
        }

        /// <summary>
        /// Checks if the specified menu option index is valid and not disabled.
        /// </summary>
        /// <param name="index">The index of the menu option to check.</param>
        /// <returns><c>true</c> if the menu option index is valid and not disabled; otherwise, <c>false</c>.</returns>
        /// <typeinfo>public static bool</typeinfo>
        private static bool IsMenuOptionSelectable(int index) {
            if (MenuService.currentMenu == null)
                return false;

            return MenuService.currentMenu.menuOptions.IsValidIndex(index) && !MenuService.currentMenu.menuOptions[index].isDisabled;
        }

        /// <summary>
        /// Moves the menu selection downwards in the menu options list.
        /// If already at the bottom, wraps around to the top.
        /// Skips disabled menu options.
        /// </summary>
        /// <typeinfo>private static void</typeinfo>
        private static void MoveMenuSelectionDown() {
            if (MenuService.currentMenu == null)
                return;

            if (MenuService.selectedMenuOptionIndex < 0 || !MenuService.currentMenu.menuOptions.IsValidIndex(MenuService.selectedMenuOptionIndex))
                MenuService.selectedMenuOptionIndex = 0;
            else {
                do {
                    MenuService.selectedMenuOptionIndex++; // Move selection downwards
                } while (!MenuService.IsMenuOptionSelectable(MenuService.selectedMenuOptionIndex));
            }
        }

        /// <summary>
        /// Moves the menu selection upwards in the menu options list.
        /// If already at the top, wraps around to the bottom.
        /// Skips disabled menu options.
        /// </summary>
        /// <typeinfo>private static void</typeinfo>
        private static void MoveMenuSelectionUp() {
            if (MenuService.currentMenu == null)
                return;

            if (MenuService.selectedMenuOptionIndex == 0)
                MenuService.selectedMenuOptionIndex = MenuService.currentMenu.menuOptions.Count - 1;
            else {
                do {
                    MenuService.selectedMenuOptionIndex--; // Move selection upwards
                } while (!MenuService.IsMenuOptionSelectable(MenuService.selectedMenuOptionIndex));
            }
        }

        #endregion Private Methods

    }
}