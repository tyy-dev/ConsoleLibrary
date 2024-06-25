using System.Text;
namespace consoletestproject.Menus
{
    /// <summary>
    /// Configuration settings for menus.
    /// </summary>
    public static class MenuConfig
    {
        /// <summary>
        /// This indicates whether the console should be cleared before displaying / visiting a menu.
        /// </summary>
        public static bool clearConsoleAfterVisit { get; set; } = true;

        /// <summary>
        /// This indicates whether the console should be cleared after executing a "MenuOption" / command
        /// </summary>
        public static bool clearConsoleAfterExecute { get; set; } = false;

        /// <summary>
        /// The standard input delimiter used in ConsoleInput.sc
        /// </summary>
        public static string standardInputDelimiter { get; set; } = ">>";

        /// <summary>
        /// MenuOption's marked as "isDebug" will not be shown if set to <c>false</c>
        /// </summary>
        public static bool shouldShowDebugOptions { get; set; } = true;

        /// <summary>
        /// MenuOption's marked as "isDebug" will be marked with a purple suffix saying "DEBUG"
        /// </summary>
        public static bool shouldMarkDebugOptions { get; set; } = false;

        /// <summary>
        /// This indicates whether the current menu's name should be displayed as the console title. <br> </br>
        /// The format for this is: $"{this.name} [{this.id}]".
        /// </summary>
        public static bool displayCurrentMenuAsConsoleTitle { get; set; } = true;

        /// <summary>
        /// Indicates whether the cursor should be automatically hidden and displayed during menu interactions. <br> </br>
        /// If <c>true</c>, the cursor will be hidden when displaying the menu and shown when prompting for input. <br> </br>
        /// If <c>false</c>, the cursor will always be shown. <br> </br>
        /// </summary>
        public static bool shouldHideAndDisplayCursorAutomatically { get; set; } = true;

        /// <summary>
        /// Backing field to avoid recursion in the outputEncoding proprety.
        /// </summary>
        private static Encoding _outputEncoding = Encoding.UTF8;

        /// <summary>
        /// Gets or sets the output encoding for the console.
        /// </summary>
        /// <remarks>
        /// Setting this property will change the output encoding of the console to the specified encoding.
        /// </remarks>
        public static Encoding outputEncoding {
            get => _outputEncoding;
            set {
                _outputEncoding = value;
                Console.OutputEncoding = value;
            }
        }

        /// <summary>
        /// Configures various settings related to menu behavior and console output. <br> </br>
        /// For more info regarding parameters, instead of hovering over the parameters see the original property in MenuConfig
        /// </summary>
        /// <param name="clearConsoleAfterVisit">Indicates whether the console should be cleared after visiting a menu. By default; true</param>
        /// <param name="clearConsoleAfterExecute">Indicates whether the console should be cleared after executing a menu option or command. By default; false</param>
        /// <param name="standardInputDelimiter">The standard input delimiter used in menu interactions. By default; ">>"</param>
        /// <param name="shouldShowDebugOptions">Specifies whether debug menu options should be shown. By default; true</param>
        /// <param name="shouldMarkDebugOptions">Specifies whether debug menu options should be marked with a "DEBUG" suffix. By default; false</param>
        /// <param name="displayCurrentMenuAsConsoleTitle">Specifies whether the current menu's name should be displayed as the console title. By default; true</param>
        /// <param name="shouldHideAndDisplayCursorAutomatically">Indicates whether the cursor should be automatically hidden and displayed during menu interactions. By default; true</param>
        /// <param name="outputEncoding">The encoding to be used for console output. If <c>null</c>, the current encoding remains unchanged. By default; <c>null</c>, which if <c>null</c> means it resorts to Encoding.UTF8</param>
        public static void Configurate(bool clearConsoleAfterVisit = true, bool clearConsoleAfterExecute = false, string standardInputDelimiter = ">>", bool shouldShowDebugOptions = true, bool shouldMarkDebugOptions = false, bool displayCurrentMenuAsConsoleTitle = true, bool shouldHideAndDisplayCursorAutomatically = true, Encoding? outputEncoding = null) {
            if (outputEncoding == null)
                MenuConfig.outputEncoding = MenuConfig._outputEncoding; // true default, Encoding.UTF8,
                                                                        // parameters must have Compile Time constants,
                                                                        // which Encoding.UTF8 isn't, that's why we use null
            else
                MenuConfig.outputEncoding = outputEncoding;

            MenuConfig.clearConsoleAfterVisit = clearConsoleAfterVisit;
            MenuConfig.clearConsoleAfterExecute = clearConsoleAfterExecute;
            MenuConfig.standardInputDelimiter = standardInputDelimiter;
            MenuConfig.shouldShowDebugOptions = shouldShowDebugOptions;
            MenuConfig.shouldMarkDebugOptions = shouldMarkDebugOptions;
            MenuConfig.displayCurrentMenuAsConsoleTitle = displayCurrentMenuAsConsoleTitle;
            MenuConfig.shouldHideAndDisplayCursorAutomatically = shouldHideAndDisplayCursorAutomatically;
        }
    }
}
