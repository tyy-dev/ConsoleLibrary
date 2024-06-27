using System.Text.RegularExpressions;
using consoletestproject.Coloureds;
using consoletestproject.ConsoleHelper;

namespace consoletestproject.Extensions
{
    /// <summary>
    /// Provides extension methods for string manipulation with ANSI escape sequences for text formatting and styling.
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods

        /// <summary>
        /// Applies a foreground or background colour to the specified text using ANSI escape sequences.
        /// </summary>
        /// <param name="text">The text to colourize.</param>
        /// <param name="colour">The colour to apply.</param>
        /// <param name="foreground">Specifies whether to apply the colour as foreground (true) or background (false).</param>
        /// <returns>The colourized text.</returns>
        /// <typeinfo>public static string</typeinfo>
        public static string Coloured(this string text, Colour colour, bool foreground = true) =>
            $"{Ansi.Text.Coloured(colour, foreground)}{text}{Ansi.Text.Reset()}";

        /// <summary>
        /// WARNING: MIGHT BE GUGGY IN CONJUCTION WITH OTHER FUNCTIONS LIKE GRADIENT, use Ansi.Text directly instead if this is the case<br> </br>
        /// Formats a string with ANSI escape sequences based on specified tags. For example: [STYLE Bold][COLOUR 255,0,0]Formatted Text[RESET].
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <remarks>
        /// This method applies formatting to the input text based on tags enclosed in square brackets. Supported tags are: <br> </br>
        /// - [COLOUR &lt;colour>]/[COLOR &lt;colour>]/ for specifying foreground text colour, where &lt;colour> can be either RGB values (eg, 255,0,0) or a hexadecimal color code (eg, #FF0000).  <br> </br>
        /// - [BGCOLOUR &lt;colour>]/[BGCOLOR &lt;colour>]/ for specifying background colour, where &lt;colour> can be either RGB values (eg, 255,0,0) or a hexadecimal color code (eg, #FF0000).  <br> </br>
        /// - [STYLE &lt;style>] for specifying text style, where &lt;style> can be any valid value from AnsiStyle (eg, Bold), or any valid index from AnsiStyle, (eg 1 for bold) <br> </br>
        /// - [RESET] for resetting text formatting.  <br> </br>
        /// Note: The tags are case-sensitive; if a tag's arguments or name are invalid, they will simply not be matched and left as is.<br> </br>
        /// </remarks>
        /// <returns>The formatted text with ANSI escape sequences.</returns>
        /// <typeinfo>public static string</typeinfo>
        public static string Format(this string text) {
            // Match [TYPE, ARGS] and [RESET], only matches the first if it has args and RESET if it has no args / is equal to [RESET]
            string pattern = @"\[(COLOUR|COLOR|BGCOLOUR|BGCOLOR|STYLE) ([^\]]+)\]|\[(RESET)\]";

            return Regex.Replace(text, pattern, match => {
                // Determine the tag type by prioritizing the first capturing group if successful; otherwise, fallback to the third capturing group.
                // This ternary operation ensures accurate identification of valid tag types.
                // For instance, [RESET] uses group 3 due to its structure not requiring arguments (lacking a second or fourth group).
                string type = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[3].Value;
                // Extract arguments from the second capturing group if it exists, removing spaces for consistency
                // or set to null if no arguments are present.
                string? args = match.Groups[2].Success ? match.Groups[2].Value.Replace(" ", "") : null;

                switch (type) {
                    case "COLOR": // [COLOUR 255,2,2] or [COLOUR #RRGGBB] or [COLOUR RRGGBB]
                    case "COLOUR":
                    case "BGCOLOR":
                    case "BGCOLOUR":
                        if (args == null)
                            return match.Value;

                        Colour? colour = Colour.ParseColour(args);

                        if (colour == null)
                            return match.Value; // Sanity check, but also added to prevent warnings.

                        return type.StartsWith("BG") ? Ansi.Text.Coloured(colour, false) : Ansi.Text.Coloured(colour);

                    case "STYLE": // [STYLE Bold]
                        if (Enum.TryParse(args, true, out Ansi.AnsiStyle style))
                            return Ansi.Text.Style(style);
                        break;

                    case "RESET": // [RESET]
                        return Ansi.Text.Reset();

                    default:
                        return match.Value;
                }

                return match.Value;  // If the tag is unsupported, none are matched / or is invalid, keep it as is
            });
        }

        /// <summary>
        /// Applies a gradient effect to the specified text using ANSI escape sequences.
        /// </summary>
        /// <param name="text">The text to colourize with the gradient.</param>
        /// <param name="gradient">A list of colours representing the gradient.</param>
        /// <param name="foreground">Specifies whether to set the foreground colour (<c>true</c>) or background colour (<c>false</c>).</param>
        /// <returns>The text with gradient effect applied.</returns>
        /// <typeinfo>public static string</typeinfo>
        public static string Gradient(this string text, List<Colour> gradient, bool foreground = true) =>
            Ansi.Text.Gradient(gradient, text, foreground).Reset(true);

        /// <summary>
        /// Converts the specified text into a hyperlink with the given URL using ANSI escape sequences.
        /// </summary>
        /// <param name="text">The text to convert into a hyperlink.</param>
        /// <param name="link">The URL to link to.</param>
        /// <param name="coloured">Specifies whether to colourize the hyperlink text.</param>
        /// <returns>The text formatted as a hyperlink.</returns>
        /// <remarks>
        /// For colour hyperlinks, the default colour is blue.
        /// <example>
        /// Example usage:
        /// <code>
        /// "Calculator Hyperlink. Click me".HyperLink(link: "calculator://", coloured: true).WriteLine();
        /// "Google.com Hyperlink. Click me".HyperLink(link: "https://google.com", coloured: false).WriteLine();
        /// </code>
        /// </example>
        /// </remarks>
        /// <typeinfo>public static string</typeinfo>
        public static string HyperLink(this string text, string link, bool coloured = true) =>
            Ansi.Text.Hyperlink(link, text, coloured).Reset(true);

        /// <summary>
        /// Resets the text formatting and styling to default for the specified text using ANSI escape sequences.
        /// </summary>
        /// <param name="text">The text to reset.</param>
        /// <param name="reverse">Specifies whether to reset text formatting and styling in reverse order.</param>
        /// <returns>The text with formatting and styling reset.</returns>
        /// <typeinfo>public static string</typeinfo>
        public static string Reset(this string text, bool reverse = false) => reverse ?
            $"{text}{Ansi.Text.Reset()}" :
            $"{Ansi.Text.Reset()}{text}";

        /// <summary>
        /// Applies a text style to the specified text using ANSI escape sequences.
        /// </summary>
        /// <param name="text">The text to style.</param>
        /// <param name="style">The ANSI text style to apply.</param>
        /// <returns>The styled text.</returns>
        /// <typeinfo>public static string</typeinfo>
        public static string Style(this string text, Ansi.AnsiStyle style) =>
            $"{Ansi.Text.Style(style)}{text}{Ansi.Text.Reset()}";

        /// <summary>
        /// Converts the input text to superscript. ˢᵐᵃˡˡ ᵗᵉˣᵗ
        /// </summary>
        /// <param name="text">The text to convert to superscript.</param>
        /// <returns>The input text converted to superscript.</returns>
        /// <remarks>
        /// This method converts alphanumeric characters in the input text to their corresponding Unicode superscript characters
        /// </remarks>
        /// <typeinfo>public static string</typeinfo>
        public static string Superscript(this string text) => CharacterMap(text.ToLower(), new() {
            {'0', "\u2070"}, // U+2070: ⁰
            {'1', "\u00B9"}, // U+00B9: ¹
            {'2', "\u00B2"}, // U+00B2: ²
            {'3', "\u00B3"}, // U+00B3: ³
            {'4', "\u2074"}, // U+2074: ⁴
            {'5', "\u2075"}, // U+2075: ⁵
            {'6', "\u2076"}, // U+2076: ⁶
            {'7', "\u2077"}, // U+2077: ⁷
            {'8', "\u2078"}, // U+2078: ⁸
            {'9', "\u2079"}, // U+2079: ⁹
            {'a', "\u1D43"}, // U+1D43: ᵃ
            {'b', "\u1D47"}, // U+1D47: ᵇ
            {'c', "\u1D9C"}, // U+1D9C: ᶜ
            {'d', "\u1D48"}, // U+1D48: ᵈ
            {'e', "\u1D49"}, // U+1D49: ᵉ
            {'f', "\u1DA0"}, // U+1DA0: ᶠ
            {'g', "\u1D4D"}, // U+1D4D: ᵍ
            {'h', "\u02B0"}, // U+02B0: ʰ
            {'i', "\u2071"}, // U+2071: ⁱ
            {'j', "\u02B2"}, // U+02B2: ʲ
            {'k', "\u1D4F"}, // U+1D4F: ᵏ
            {'l', "\u02E1"}, // U+02E1: ˡ
            {'m', "\u1D50"}, // U+1D50: ᵐ
            {'n', "\u207F"}, // U+207F: ⁿ
            {'o', "\u1D52"}, // U+1D52: ᵒ
            {'p', "\u1D56"}, // U+1D56: ᵖ
            {'q',  "\uD801\uDFA5"}, // U+107A5: 𐞥
            {'r', "\u02B3"}, // U+02B3: ʳ
            {'s', "\u02E2"}, // U+02E2: ˢ
            {'t', "\u1D57"}, // U+1D57: ᵗ
            {'u', "\u1D58"}, // U+1D58: ᵘ
            {'v', "\u1D5B"}, // U+1D5B: ᵛ
            {'w', "\u02B7"}, // U+02B7: ʷ
            {'x', "\u02E3"}, // U+02E3: ˣ
            {'y', "\u02B8"}, // U+02B8: ʸ
            {'z', "\u1DBB"}, // U+1D76: ᶻ
            {')', "\u207E"}, // U+207E:  ⁾
            {'⁽', "\u207D" }, // U+207D: ⁽
            {'=', "\u207C" }, // U+207C: ⁼
            {'+', "\u207B" }, // U+207B: ⁻
            {'-', "\u207A" }, // U+207A: ⁺
        });

        /// <summary>
        /// Writes the specified text to the console without a newline character.
        /// </summary>
        /// <param name="text">The text to write to the console.</param>
        /// <param name="shouldFormat">A boolean indicating whether the text should be formatted before writing to the console.</param>
        /// <remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// "[STYLE Bold]Hello, World![RESET]".Write(shouldFormat: true); // Equivalent to Console.Write("[STYLE Bold]Hello, World![RESET]".Format());
        /// </code>
        /// </example>
        /// </remarks>
        /// <typeinfo>public static void</typeinfo>
        public static void Write(this string text, bool shouldFormat = false) => Console.Write(shouldFormat ? text.Format() : text);

        /// <summary>
        /// Writes the specified text to the console, followed by the current line terminator.
        /// </summary>
        /// <param name="text">The text to write to the console.</param>
        /// <param name="shouldFormat">A boolean indicating whether the text should be formatted before writing to the console.</param>
        /// <remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// "[STYLE Italic]Hello, World![RESET]".WriteLine(shouldFormat: true); // Equivalent to Console.Write("[STYLE Italic]Hello, World![RESET]".Format());
        /// </code>
        /// </example>
        /// </remarks>
        /// <typeinfo>public static void</typeinfo>
        public static void WriteLine(this string text, bool shouldFormat = false) => Console.WriteLine(shouldFormat ? text.Format() : text);

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Converts the text to unicode using a provided mapping dictionary.
        /// </summary>
        /// <param name="text">The text to convert to superscript.</param>
        /// <param name="Fontmap">A dictionary that maps characters to their unicode equivalents.</param>
        /// <returns>The text in unicode form.</returns>
        /// <typeinfo>private static string</typeinfo>
        private static string CharacterMap(string text, Dictionary<char, string> Fontmap) {
            string superscriptedText = "";

            foreach (char c in text) {
                if (Fontmap.TryGetValue(c, out string? value))
                    superscriptedText += value;
                else
                    superscriptedText += c;
            }

            return superscriptedText;
        }

        #endregion Private Methods
    }
}
