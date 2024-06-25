using consoletestproject.Extensions;

namespace consoletestproject.Menus
{
    /// <summary>
    /// Represents a menu option with an ID, text, and a callback action.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MenuOption"/> class with the specified ID, text, and callback action.
    /// </remarks>
    /// <param name="id">The unique identifier of the menu option.</param>
    /// <param name="text">The text displayed for the menu option. Defaults to "Option {id}" if not provided.</param>
    /// <param name="callback">The callback action associated with the menu option.</param>
    /// <param name="submenuId">The identifier of a submenu associated with this option. If provided, this indicates that selecting this option should also show the menu associated with the submenuId. Defaults to <c>null</c>.</param>
    /// <param name="isDebug">Indicates whether this is a debug option.</param>
    /// <param name="isDisabled">Indicates whether the option is disabled and it's callback can be executed</param>
    /// <param name="parent"></param>
    public class MenuOption(int id, string? text = null, Action<MenuOption>? callback = null, int? submenuId = null, bool isDebug = false, bool isDisabled = false, Menu? parent = null)
    {
        #region Public Fields

        /// <summary>
        /// The unique identifier of the menu option
        /// </summary>
        public int id = id;

        /// <summary>
        /// Indicates whether this is a debug option.
        /// </summary>
        public bool isDebug = isDebug;

        /// <summary>
        /// Indicates whether the option is disabled and it's callback can be executed
        /// </summary>
        public bool isDisabled = isDisabled;

        /// <summary>
        /// Gets or sets the parent menu to which this option belongs. <br> </br>
        /// This property is automatically updated by the <see cref="Menu"/> class <br> </br>
        /// when the menu option is added to a menu. By default, this property is set to <c>null</c>. <br> </br>
        /// </summary>
        public Menu? parent = parent;

        /// <summary>
        /// The identifier of a submenu associated with this option.
        /// </summary>
        public int? submenuId = submenuId;

        #endregion Public Fields

        #region Private Fields

        /// <summary>
        /// The callback action associated with the menu option. <br> </br>
        /// The callback is triggered when <see cref="Execute"/> is invoked., your callback will be called with an instance of the MenuOption
        /// </summary>
        private readonly Action<MenuOption>? callback = callback;

        /// <summary>
        /// Backing field to avoid recursion in the text property.
        /// </summary>
        private string? _text = text;

        /// <summary>
        /// The decoration prefix text that is prepended to the menu option's displayed text.
        /// </summary>
        /// <remarks>
        /// This decoration prefix is added directly to the beginning of the menu option's text when it is displayed.
        /// It can be set using <see cref="SetTextDecoration(string)"/> to customize the appearance of the menu option dynamically.
        /// </remarks>
        private string textDecoration = "";

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// The text displayed for the menu option. Defaults to "Option {id}" if not provided in the constructor or SetText function
        /// </summary>
        public string text {
            get => this.GetText();
            set => this._text = value ?? $"Option {this.id}";
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Executes the callback Action associated with this menu option. <br></br>
        /// </summary>
        /// <param name="shouldShowSubMenu">Indicates whether to show the menu associated with the submenuId.</param>
        /// <returns>
        /// <c>true</c> if the callback was executed; <c>false</c> if no callback is defined.
        /// </returns>
        public bool Execute(bool shouldShowSubMenu = true) {
            Menu? submenu = null;

            if (this.isDisabled)
                return false;

            this.parent?.ResetSelectedOption();

            // Check if there is a submenu ID and if the submenu should be shown, if so we grab the submenu id so we can show it later.
            if (this.submenuId != null && shouldShowSubMenu)
                submenu = MenuService.GetMenuById(this.submenuId.Value);

            if (this.callback == null) {
                if (submenu != null)
                    submenu?.Show();
                // Indicate no callback was executed, because no callback was defined
                return false;
            }

            if (MenuConfig.clearConsoleAfterExecute) {
                Console.Clear();
                this.parent?.Show(); // Because we cleared the console, the parent menu has also been cleared, so we show this again.
            }

            this.callback(this);

            if (submenu != null)
                submenu?.Show();

            //Indicate a callback was successfully executed.
            return true;
        }

        /// <summary>
        /// Retrieves the text of the menu option with optional decoration.
        /// </summary>
        /// <param name="raw">If true, returns the raw text without decoration.</param>
        /// <returns>The formatted or raw text of the menu option.</returns>
        public string GetText(bool raw = false) {
            if (raw)
                return this._text ?? $"Option {this.id}";

            return $"{(this.isDisabled == true ? "[STYLE Faint][STYLE Strikethrough]" : "")}{this.textDecoration}{this._text}[RESET]".Format();
        }
        /// <summary>
        /// Sets the text of the menu option.
        /// </summary>
        /// <param name="text">The new text of the menu option. Defaults to "Option {id}" if not provided.</param>
        /// <param name="raw"></param>
        public void SetText(string? text = null, bool raw = false) {
            if (raw)
                this.text = text ?? $"Option {this.id}";
            else
                this.text = $"{this.textDecoration}{text}[RESET]".Format() ?? $"{this.textDecoration}Option {this.id}[RESET]".Format();
        }

        /// <summary>
        /// Sets a decoration prefix for the text displayed by this menu option.
        /// </summary>
        /// <param name="text">The prefix text to prepend to the menu option's text.</param>
        /// <remarks>
        /// This method allows customizing the appearance of the menu option's text by adding a prefix with AnsiStyling for example.
        /// The prefix is applied immediately to the menu option's text and can be reset using <see cref="SetText"/>.
        /// </remarks>
        public void SetTextDecoration(string text) => this.textDecoration = text;

        #endregion Public Methods
    }
}