using consoletestproject.Extensions;
using consoletestproject.Menus;

namespace consoletestproject.ConsoleHelper
{
    /// <summary>
    /// Provides methods for retrieving console input.
    /// </summary>
    public class ConsoleInput
    {
        #region Public Methods

        /// <summary>
        /// Prompts the user for input and returns the entered string.
        /// </summary>
        /// <param name="prompt">Optional. The prompt to display to the user before input.</param>
        /// <param name="inputDelimiter">Optional. The delimiter to display before the input prompt. Defaults to MenuConfig.standardInputDelimiter, if not provided.</param>
        /// <param name="trimOutput">Optional. Indicates whether to trim leading and trailing whitespace from the input. Defaults to false.</param>
        /// <returns>The string entered by the user, or <c>null</c> if no input is provided.</returns>
        /// <typeinfo>public static string?</typeinfo>
        public static string? Get(string prompt = "", string? inputDelimiter = null, bool trimOutput = false) {
            inputDelimiter ??= MenuConfig.standardInputDelimiter;

            if (MenuConfig.shouldHideAndDisplayCursorAutomatically)
                Ansi.Cursor.SetCursorVisibility(true).Write();

            // If prompt is not empty, and does not end with a space, add one to make sure that the delimeter isn't connected to the prompt, eg prompt> and prompt >
            if (!string.IsNullOrWhiteSpace(prompt) && !prompt.EndsWith(' '))
                prompt += " ";

            Console.Write($"[COLOUR #FFFFFF]{prompt}{inputDelimiter}[RESET]".Format());

            string? input = Console.ReadLine();

            if (MenuConfig.shouldHideAndDisplayCursorAutomatically)
                Ansi.Cursor.SetCursorVisibility(false).Write();

            if (trimOutput && !string.IsNullOrEmpty(input))
                input = input.Trim();

            return input;
        }

        /// <summary>
        /// Prompts the user for input and returns the entered boolean value.
        /// </summary>
        /// <param name="prompt">Optional. The prompt to display to the user before input.</param>
        /// <param name="inputDelimiter">Optional. The delimiter to display before the input prompt. Defaults to MenuConfig.standardInputDelimiter, if not provided.</param>
        /// <returns>
        /// The boolean value entered by the user (case-insensitive): <br> </br>
        /// - <c>true</c> if the user entered "yes", "y", "enable", "confirm", "ok" or a valid boolean string. <br> </br>
        /// - <c>false</c> if the user entered "no", "n", "disable", "cancel" or a valid boolean string. <br> </br>
        /// - <c>null</c> if no input is provided or if the input cannot be parsed as a boolean value. <br> </br>
        /// </returns>
        /// <typeinfo>public static bool?</typeinfo>
        public static bool? GetAsBool(string prompt = "", string? inputDelimiter = null) {
            inputDelimiter ??= MenuConfig.standardInputDelimiter;
            string? input = ConsoleInput.Get(prompt, inputDelimiter, trimOutput: true)?.ToLower();

            // Return null if no input is provided
            if (string.IsNullOrEmpty(input))
                return null;

            // Try parsing the input as a boolean, for true / false
            if (bool.TryParse(input, out bool value))
                return value;

            // Check for known string equivalents of true/false
            return input switch {
                "yes" or "y" or "enable" or "confirm" or "ok" => true,
                "no" or "n" or "disable" or "cancel" => false,
                _ => null, // Return null for differiating unrecognized inputs, like "bla" shouldn't be false but rather it is null
            };
        }

        /// <summary>
        /// Prompts the user for input and returns the entered integer value.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="inputDelimiter">The delimiter to display before the input prompt. Defaults to ">". If not provided, uses MenuConfig.standardInputDelimiter.</param>
        /// <returns>The integer value entered by the user, or <c>null</c> if the input cannot be parsed as an integer or no input is provided.</returns>
        /// <typeinfo>public static int?</typeinfo>
        public static int? GetAsInt(string prompt = "", string? inputDelimiter = null) {
            inputDelimiter ??= MenuConfig.standardInputDelimiter;
            string? input = ConsoleInput.Get(prompt, inputDelimiter);

            if (string.IsNullOrEmpty(input))
                return null;

            // Try parsing the input as a integer.
            if (int.TryParse(input, out int value))
                return value;

            // Return null for unrecognized inputs
            return null;
        }

        /// <summary>
        /// Waits for a key press from the console input and returns the ConsoleKey of the pressed key.
        /// </summary>
        /// <param name="prompt">The prompt to display before waiting for key input.</param>
        /// <param name="displayPressedkey">displayPressedkey if false, makes sure the entered character is never displayed if pressed</param>
        /// <returns>The ConsoleKey of the pressed key.</returns>
        /// <typeinfo>public static ConsoleKey</typeinfo>
        public static ConsoleKey GetKey(string prompt = "", bool displayPressedkey = false) {
            if (!string.IsNullOrEmpty(prompt))
                Console.Write($"[COLOUR #FFFFFF]{prompt}[RESET] ".Format());

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: !displayPressedkey); //Intercept if true, makes sure the entered character is never displayed, this also assists with disabling typing as a whole when needed.
            return keyInfo.Key;
        }

        /// <summary>
        /// Displays a menu with a list of items for selection and invokes a callback with the selected item's details.
        /// </summary>
        /// <param name="prompt">The prompt message to display at the top of the menu.</param>
        /// <param name="items">The list of strings representing the items to display in the menu.</param>
        /// <param name="callback">The callback function that will be invoked when an item is selected. <br> </br>
        /// Takes three parameters: the selected <see cref="MenuOption"/>, the selected item string, and its index in the original list. </param>
        /// <param name="parentToShowAfterExecute">The parent menu to show after executing the callback. It can be <c>null</c>.</param>
        /// <param name="shouldRemoveMenuAfterExecute">
        /// Specifies whether the menu should be removed after executing the callback.<br> </br>
        /// This should always be true if you have a parentToShowAfterExecute set to a menu, as it will prevent wasting memory.
        /// </param>
        /// <exception cref="ArgumentException">Thrown when the items list is null or empty.</exception>
        /// <remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// ConsoleInput.GetListBoxSelection("Select a colour", ["red", "green", "blue", "very blue"], (MenuOption optionContext, string option, int index) => {
        ///             ConsoleInput.GetKey($"Selected {option} [{index}]\nPress any key to continue...");
        /// }, parentToShowAfterExecute: context?.parent, shouldRemoveMenuAfterExecute: true);
        /// </code>
        /// </example>
        /// </remarks>
        /// <typeinfo>public static void</typeinfo>
        public static void GetListBoxSelection(string prompt, List<string> items, Action<MenuOption, string, int> callback, Menu? parentToShowAfterExecute = null, bool shouldRemoveMenuAfterExecute = false) {
            if (items.IsEmptyOrNull())
                throw new ArgumentException("Items list must not be null or empty.", nameof(items));

            Menu menu = new(MenuService.GetUniqueMenuId(), prompt);
            for (int id = 0; id < items.Count; id++) {
                int currentId = id; // Capture the current value of id in a local variable to ensure the correct value is used in the callback
                MenuOption option = new(currentId, items[currentId], (MenuOption context) => {
                    callback(context, items[currentId], currentId);

                    parentToShowAfterExecute?.Show();

                    if (shouldRemoveMenuAfterExecute)
                        menu.Remove();
                });

                menu.AddMenuOptions(option);
            }

            // Prompt user for selection
            menu.Show();
        }

        #endregion Public Methods
    }
}