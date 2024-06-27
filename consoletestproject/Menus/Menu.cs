using consoletestproject.ConsoleHelper;
using consoletestproject.Extensions;

namespace consoletestproject.Menus
{
    /// <summary>
    /// Represents a menu with an ID, name, and menu options
    /// </summary>
    public class Menu
    {
        #region Public Fields

        /// <summary>
        /// The unique identifier of the menu.
        /// </summary>
        public int id = 0;

        /// <summary>
        /// The list of menu options available in the menu.
        /// </summary>
        public List<MenuOption> menuOptions = [];

        /// <summary>
        /// The name of the menu.
        /// </summary>
        public string name = "Menu";

        #endregion Public Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the menu.</param>
        /// <param name="name">The name of the menu.</param>
        /// <param name="menuOptions">The options available in the menu.</param>
        /// <exception cref="MenuIdAlreadyExistsException">Thrown when a menu with the same id already exists.</exception>
        public Menu(int id = 0, string name = "Menu", List<MenuOption>? menuOptions = null) {
            Menu? menu = MenuService.GetMenuById(id);
            if (menu != null)
                throw new MenuIdAlreadyExistsException($"Menu id ${id} already exists under {menu.name} ({menu.id})");

            this.id = id;
            this.name = name;
            if (menuOptions == null)
                this.menuOptions = [];
            else
                this.AddMenuOptions(menuOptions);

            MenuService.AddMenus(this);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Adds a "Back" option to the menu with a callback to return to the previous menu that is different to the current one. <br></br>
        /// The ID of the newly added "Back" menu option will be determined based on the existing menu options. <br></br>
        /// If this is the first option being added, the ID will be set to 1. Otherwise, it will be set to the ID of the last menu option in the list plus 1.
        /// </summary>
        /// <returns>The newly added "Back" menu option.</returns>
        public MenuOption AddBackOption() => this.AddMenuOptionWrapper("Back", (MenuOption context) => {
            this.ResetSelectedOption();
            MenuService.GetPreviousMenuFromHistory()?.Show();
        });

        /// <summary>
        /// Adds an "Exit" option to the menu with a callback to terminate the application.
        /// The ID of the newly added "Exit" menu option will be determined based on the existing menu options. <br></br>
        /// If this is the first option being added, the ID will be set to 1. Otherwise, it will be set to the ID of the last menu option in the list plus 1.
        /// </summary>
        /// <remarks>
        /// This method creates a menu option titled "Exit" that, when selected, terminates the application.
        /// </remarks>
        /// <returns>The newly added "Exit" menu option.</returns>
        public MenuOption AddExitOption() => this.AddMenuOptionWrapper("Exit", (MenuOption context) => {
            Environment.Exit(0);
        });

        /// <summary>
        /// Adds menu options to the menu.
        /// </summary>
        /// <param name="options">The options to be added.</param>
        /// <exception cref="MenuIdAlreadyExistsException">Thrown when a menu option with the same id already exists, or when multiple options with the same id are added.</exception>
        public void AddMenuOptions(List<MenuOption> options) {
            foreach (MenuOption option in options) {
                MenuOption? existingOption = this.GetMenuOptionById(option.id);
                if (existingOption != null)
                    throw new MenuIdAlreadyExistsException($"Menu option id ${option.id} already exists under {existingOption.text} ({existingOption.id})");
                if (options.Count(o => o.id == option.id) > 1)
                    throw new MenuIdAlreadyExistsException($"Multiple occurrences of menu option id {option.id} found in the provided parameter.");
                option.parent = this;
            }
            this.menuOptions.AddRange(options);
        }

        /// <summary>
        /// Adds a menu option to the menu.
        /// </summary>
        /// <param name="option">The option to be added.</param>
        /// <exception cref="MenuIdAlreadyExistsException">Thrown when a menu option with the same id already exists, or when multiple options with the same id are added.</exception>
        public void AddMenuOptions(MenuOption option) => this.AddMenuOptions([option]);

        /// <summary>
        /// Wraps the addition of AddMenuOptions.
        /// </summary>
        /// <param name="name">The name of the menu option.</param>
        /// <param name="callback">The callback action to be executed when the menu option is selected.</param>
        /// <returns>The newly added menu option.</returns>
        public MenuOption AddMenuOptionWrapper(string name, Action<MenuOption> callback) {
            int id = this.menuOptions.IsEmptyOrNull() ? 1 : this.menuOptions.Last().id + 1;
            this.AddMenuOptions(new MenuOption(id, name, callback));

            // null-forgiving operator, we tell the compiler that we know for certain this function wont return null,
            // as we just added it in the line above.
            return this.GetMenuOptionById(id)!;
        }

        /// <summary>
        /// Retrieves a menu option by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the menu.</param>
        /// <returns>The menu with the specified ID, or <c>null</c> if not found.</returns>
        public MenuOption? GetMenuOptionById(int id) => this.menuOptions.Find(menu => menu.id == id);

        /// <summary>
        /// Gets the menu options available in the menu.
        /// If <see cref="MenuConfig.shouldShowDebugOptions"/> is set to <c>false</c>,
        /// this will not return menu options where isDebug is set to <c>true</c>
        /// </summary>
        /// <returns>The list of available menu options.</returns>
        public List<MenuOption> GetMenuOptions() => this.menuOptions.Where(option => MenuConfig.shouldShowDebugOptions || !option.isDebug).ToList();

        /// <summary>
        /// Retrieves the index of the menu option with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier (ID) of the menu option to find.</param>
        /// <returns>The zero-based index of the menu option if found; otherwise, <c>null</c>.</returns>
        public int? MenuOptionIdToIndex(int id) {
            MenuOption? menuOption = this.GetMenuOptionById(id);
            if (menuOption == null) return null;

            int indexOfMenuOption = this.menuOptions.IndexOf(menuOption);
            return indexOfMenuOption != -1 ? indexOfMenuOption : null;
        }

        /// <summary>
        /// Retrieves the unique identifier (ID) of the menu option at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the menu option to retrieve the ID for.</param>
        /// <returns>The ID of the menu option if the index is valid; otherwise, <c>null</c>.</returns>
        public int? MenuOptionIndexToId(int index) {
            if (this.menuOptions.IsValidIndex(index))
                return this.menuOptions[index].id;
            return null;
        }

        /// <summary>
        /// Removes this menu from the service.
        /// </summary>
        /// <returns><c>true</c> if the menu was removed; <c>false</c> if no menu was found by the specified id.</returns>
        /// <remarks>
        /// This method removes the menu instance from the <see cref="MenuService"/> by its unique identifier.
        /// </remarks>
        public bool Remove() => MenuService.RemoveById(this.id);

        /// <summary>
        /// Resets the selected menu option, clearing any selection and resetting the display.
        /// </summary>
        /// <remarks>
        /// This method resets the selected menu option within the current menu instance.
        /// It sets the internal index of the selected menu option to -1, indicating no option is selected.
        /// Additionally, it clears any visual indication of selection (such as underlining) from all menu options.
        /// </remarks>
        public void ResetSelectedOption() {
            MenuService.selectedMenuOptionIndex = -1;
            this.SetOptionSelectedDecoration(-1); // Passing -1 ensures no option is set to underlined, resetting all option styles.
        }

        /// <summary>
        /// Disables the specified menu option, when an MenuOption is disabled it cannot be selected / executed. <br> </br>
        /// It also get's this text decoration: [STYLE Faint][STYLE Strikethrough]
        /// </summary>
        /// <param name="index">The zero-based index of the menu option to disable. This is not the option ID but the position in the menu options list aka the index.</param>
        /// <param name="value"></param>
        /// <remarks>
        /// This method sets the <c>isDisabled</c> property of the menu option specified by <paramref name="index"/> to <c>true</c>, making it disabled.
        /// </remarks>
        public void SetOptionDisabled(int index, bool value) {
            if (this.menuOptions.IsValidIndex(index))
                this.menuOptions[index].isDisabled = value;
        }

        /// <summary>
        /// Sets the specified menu option to appear with selected decoration
        /// </summary>
        /// <param name="index">The zero-based index of the menu option to set blinking. This is not the option ID but the position in the menu options list.</param>
        /// <remarks>
        /// This method modifies the appearance of the menu option specified by <paramref name="index"/> to include a selected styled effect.
        /// </remarks>
        public void SetOptionSelectedDecoration(int index) {
            foreach (MenuOption menuOption in this.GetMenuOptions())
                menuOption.SetTextDecoration("");

            if (this.menuOptions.IsValidIndex(index))
                this.menuOptions[index].SetTextDecoration("[STYLE DoubleUnderline][COLOR 251,245,210]");
        }

        /// <summary>
        /// Displays the menu on the console with specified text Colour.
        /// </summary>
        /// <param name="shouldClear">Specifies whether the console should be cleared before displaying the menu. Default is <c>true</c>.</param>
        /// <param name="menuColourHex">The hexadecimal Colour code for the menu title.</param>
        /// <param name="idColourHex">The hexadecimal Colour code for the menu option IDs.</param>
        /// <param name="optionColourHex">The hexadecimal Colour code for the menu option text.</param>
        /// <remarks>
        /// If <paramref name="shouldClear"/> is <c>true</c> and <see cref="MenuConfig.clearConsoleAfterVisit"/> is also <c>true</c>, the console will be cleared before displaying the menu.
        /// The menu is displayed with the specified text Colours for the title, option IDs, and option text.
        /// After displaying the menu, the current menu is set using <see cref="MenuService.SetCurrentMenu"/>.
        /// </remarks>
        public void Show(bool shouldClear = true, string menuColourHex = "#FFFFFF", string idColourHex = "#FFFFFF", string optionColourHex = "#CCCCCC") {
            if (MenuConfig.shouldHideAndDisplayCursorAutomatically)
                Ansi.Cursor.SetCursorVisibility(false).Write();

            if (shouldClear && MenuConfig.clearConsoleAfterVisit)
                Console.Clear();

            Console.WriteLine($"[COLOUR {menuColourHex}]Menu: {this.name}".Format());
            foreach (MenuOption option in this.GetMenuOptions()) {
                string optionText = $"[COLOUR {idColourHex}]{option.id}) ".Format();
                if (option.isDebug && MenuConfig.shouldMarkDebugOptions)
                    Console.Write($"[COLOUR 137, 98, 176]*DEBUG [RESET]{optionText}".Format());
                else
                    Console.Write($"[COLOUR {idColourHex}]{option.id}) ".Format());
                Console.WriteLine($"[STYLE Italic][COLOUR {optionColourHex}]{option.text}".Format());
            }

            MenuService.SetCurrentMenu(this);
        }

        #endregion Public Methods
    }
}