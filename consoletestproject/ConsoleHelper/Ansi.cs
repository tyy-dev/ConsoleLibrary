using consoletestproject.Coloureds;

namespace consoletestproject.ConsoleHelper
{
    /// <summary>
    /// Provides constants and utilities for ANSI escape codes and text formatting.
    /// </summary>
    public static class Ansi
    {
        #region Public Fields

        /// <summary>
        /// Terminal bell
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string BELL = "\a";

        /// <summary>
        /// Carriage Return, used for resetting the cursor/device position back to the beginning of a line.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string CR = $"{ESC}\\";

        /// <summary>
        /// Control Sequence Introducer, used to start ANSI escape sequences.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string CSI = $"{ESC}[";

        /// <summary>
        /// The ASCII delete character (DEL), used to delete characters.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string DEL = "\x7f";

        /// <summary>
        /// The ASCII escape character (ESC), used to introduce control sequences.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string ESC = "\x1b";

        /// <summary>
        /// Operating System Command, used to send commands to the terminal.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string OSC = $"{ESC}]";

        /// <summary>
        /// Start of String, used to mark the beginning of device control strings.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string SOS = $"{ESC}X";

        /// <summary>
        /// String Terminator, used to mark the end of device control strings.
        /// </summary>
        /// <typeinfo>public const string</typeinfo>
        public const string ST = $"{ESC}\\";

        #endregion Public Fields

        #region Public Enums

        /// <summary>
        /// Also know as graphic options / graphic renditions, these are used within <seealso cref="Text.Style"/> <br> </br>
        /// These are widely supported graphic options
        /// </summary>
        /// <typeinfo>public enum byte</typeinfo>
        public enum AnsiStyle : byte
        {
            /// <summary>
            /// Used for resetting all text attributes/styles regarding ansi escape codes.
            /// </summary>
            Reset = 0,
            /// <summary>
            /// Used for increased intensity (opposite of Faint where it is used for decreased intensity)
            /// </summary>
            Bold = 1,
            /// <summary>
            /// Used for decreased intensity (opposite of bold where it is used for increased intensity)
            /// </summary>
            Faint = 2,
            /// <summary>
            /// Used for italicizing text
            /// </summary>
            Italic = 3,
            /// <summary>
            /// Used for underlinning text.
            /// </summary>
            Underline = 4,
            /// <summary>
            /// Used for slow-blinking text.
            /// </summary>
            Blink = 5,
            /// <summary>
            /// Used for inverting the foreground and background colors.
            /// </summary>
            Invert = 7,
            /// <summary>
            /// Used for "concealing" the text / making the text invisible
            /// </summary>
            Concealed = 8,
            /// <summary>
            /// Used for strikethrough text
            /// </summary>
            Strikethrough = 9,
            /// <summary>
            /// Used for double underlining text
            /// </summary>
            DoubleUnderline = 21,
            /// <summary>
            /// Used for overlining text
            /// </summary>
            Overline = 53,
        }

        #endregion Public Enums

        #region Public Classes

        /// <summary>
        /// Provides utility methods for the cursor using ANSI escape sequences.
        /// </summary>
        /// <typeinfo>public static class</typeinfo>
        public static class Cursor
        {
            #region Public Enums

            /// <summary>
            /// Represents different styles of the cursor.
            /// </summary>
            /// <typeinfo>public enum byte</typeinfo>
            public enum CursorStyle : byte
            {
                /// <summary>
                /// Default cursor style: blinking block.
                /// </summary>
                BlinkingBlock = 1,

                /// <summary>
                /// Steady block cursor style.
                /// </summary>
                SteadyBlock = 2,

                /// <summary>
                /// Blinking underline cursor style.
                /// </summary>
                BlinkingUnderline = 3,

                /// <summary>
                /// Steady underline cursor style.
                /// </summary>
                SteadyUnderline = 4,

                /// <summary>
                /// Blinking bar cursor style.
                /// </summary>
                BlinkingBar = 5,

                /// <summary>
                /// Steady bar cursor style.
                /// </summary>
                SteadyBar = 6
            }

            #endregion Public Enums

            #region Public Methods

            /// <summary>
            /// Moves the cursor down by the specified number of lines using ANSI escape sequences.
            /// </summary>
            /// <param name="lines">The number of lines to move down.</param>
            /// <returns>The ANSI escape sequence to move the cursor down.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveDown(int lines) => $"{CSI}{lines}B";

            /// <summary>
            /// Moves the cursor left by the specified number of columns using ANSI escape sequences.
            /// </summary>
            /// <param name="columns">The number of columns to move left.</param>
            /// <returns>The ANSI escape sequence to move the cursor left.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveLeft(int columns) => $"{CSI}{columns}D";

            /// <summary>
            /// Moves the cursor right by the specified number of columns using ANSI escape sequences.
            /// </summary>
            /// <param name="columns">The number of columns to move right.</param>
            /// <returns>The ANSI escape sequence to move the cursor right.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveRight(int columns) => $"{CSI}{columns}C";

            /// <summary>
            /// Moves the cursor to the specified column using ANSI escape sequences.
            /// </summary>
            /// <param name="column">The column number (1-based) to move to.</param>
            /// <returns>The ANSI escape sequence to move the cursor to the specified column.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveToColumn(int column) => $"{CSI}{column}G";

            /// <summary>
            /// Moves the cursor to the home position (top-left corner of the screen) using ANSI escape sequences.
            /// </summary>
            /// <returns>The ANSI escape sequence to move the cursor to the home position.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveToHome() => $"{CSI}H";

            /// <summary>
            /// Moves the cursor to the next line, down by the specified number of lines, using ANSI escape sequences.
            /// </summary>
            /// <param name="lines">The number of lines to move down.</param>
            /// <returns>The ANSI escape sequence to move the cursor to the next line.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveToNextLine(int lines) => $"{CSI}{lines}E";

            /// <summary>
            /// Moves the cursor to the specified position using ANSI escape sequences.
            /// </summary>
            /// <param name="line">The line number (1-based) to move to.</param>
            /// <param name="column">The column number (1-based) to move to.</param>
            /// <returns>The ANSI escape sequence to move the cursor to the specified position.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveToPosition(int line, int column) => $"{CSI}{line};{column}f";

            /// <summary>
            /// Moves the cursor to the previous line, up by the specified number of lines, using ANSI escape sequences.
            /// </summary>
            /// <param name="lines">The number of lines to move up.</param>
            /// <returns>The ANSI escape sequence to move the cursor to the previous line.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveToPreviousLine(int lines) => $"{CSI}{lines}F";

            /// <summary>
            /// Moves the cursor up by the specified number of lines using ANSI escape sequences.
            /// </summary>
            /// <param name="lines">The number of lines to move up.</param>
            /// <returns>The ANSI escape sequence to move the cursor up.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string MoveUp(int lines) => $"{CSI}{lines}A";

            /// <summary>
            /// Requests the current cursor position using ANSI escape sequences.
            /// </summary>
            /// <returns>The ANSI escape sequence to request the current cursor position.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string RequestCursorPosition() => $"{CSI}6n";

            /// <summary>
            /// Resets the cursor style to the default blinking block.
            /// </summary>
            /// <returns>The ANSI escape sequence to reset the cursor style.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string ResetCursorStyle() => Ansi.Cursor.SetCursorStyle(CursorStyle.BlinkingBlock);

            /// <summary>
            /// Restores the previously saved cursor position and attributes using ANSI escape sequences.
            /// </summary>
            /// <returns>The ANSI escape sequence to restore the saved cursor position.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string RestoreCursorPosition() => $"{ESC}8";

            /// <summary>
            /// Restores the previously saved cursor position and attributes using ANSI escape sequences (SCO-style).
            /// </summary>
            /// <returns>The ANSI escape sequence to restore the saved cursor position (SCO-style).</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string RestoreCursorPositionSCO() => $"{ESC}u";

            /// <summary>
            /// Saves the current cursor position and attributes using ANSI escape sequences.
            /// </summary>
            /// <returns>The ANSI escape sequence to save the current cursor position.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string SaveCursorPosition() => $"{ESC}7";

            /// <summary>
            /// Saves the current cursor position and attributes using ANSI escape sequences (SCO-style).
            /// </summary>
            /// <returns>The ANSI escape sequence to save the current cursor position (SCO-style).</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string SaveCursorPositionSCO() => $"{ESC}s";

            /// <summary>
            /// Scrolls the screen up by one line using ANSI escape sequences.
            /// </summary>
            /// <returns>The ANSI escape sequence to scroll the screen up.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string ScrollUp() => $"{ESC}M";

            /// <summary>
            /// Sets the cursor blinking state using ANSI escape sequences.
            /// </summary>
            /// <param name="blinking">Specifies whether to enable blinking (<c>true</c>) or disable it (<c>false</c>).</param>
            /// <returns>The ANSI escape sequence to set the cursor blinking state.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string SetCursorBlinking(bool blinking = true) => Ansi.Text.DECPMSet(12, blinking);

            /// <summary>
            /// Sets the cursor style using ANSI escape sequences.
            /// </summary>
            /// <param name="style">The style of the cursor to set.</param>
            /// <returns>The ANSI escape sequence to set the specified cursor style.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string SetCursorStyle(CursorStyle style) => $"{CSI}{(byte)style} q";
            /// <summary>
            /// Sets the cursor visibility using ANSI escape sequences.
            /// </summary>
            /// <param name="visible">Specifies whether to make the cursor visible (<c>true</c>) or invisible (<c>false</c>).</param>
            /// <returns>The ANSI escape sequence to set the cursor visibility.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string SetCursorVisibility(bool visible = true) => Ansi.Text.DECPMSet(25, visible);

            #endregion Public Methods
        }

        /// <summary>
        /// Provides utility methods for generating ANSI escape sequences for text formatting and styling.
        /// </summary>
        /// <typeinfo>public static class</typeinfo>
        public static class Text
        {
            #region Public Methods

            /// <summary>
            /// Generates an ANSI escape sequence for setting the text colour.
            /// </summary>
            /// <param name="colour">The colour to set.</param>
            /// <param name="foreground">Specifies whether to set the foreground colour (<c>true</c>) or background colour (<c>false</c>).</param>
            /// <returns>The ANSI escape sequence for setting the specified colour.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string Coloured(Colour colour, bool foreground = true) =>
                Ansi.Text.SelectGraphicRendition(foreground ? (byte)38 : (byte)48, 2, colour.r, colour.g, colour.b);

            /// <summary>
            /// Generates an ANSI escape sequence for activating or deactivating a DEC private mode.
            /// </summary>
            /// <param name="code">The DEC private mode code.</param>
            /// <param name="set">Specifies whether to activate (<c>true</c>) or deactivate (<c>false</c>) the mode.</param>
            /// <returns>The ANSI escape sequence for activating or deactivating the specified DEC private mode.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string DECPMSet(byte code, bool set = true) => $"{CSI}?{code}{(set == true ? "h" : "l")}";

            /// <summary>
            /// Generates a gradient-coloured text using ANSI escape sequences.
            /// </summary>
            /// <param name="gradient">A list of colours representing the gradient.</param>
            /// <param name="text">The text to colourize with the gradient.</param>
            /// <param name="foreground">Specifies whether to set the foreground colour (<c>true</c>) or background colour (<c>false</c>).</param>
            /// <returns>The colourized text with gradient effect.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string Gradient(List<Colour> gradient, string text, bool foreground = true) => string.Concat(text.Select((c, i) => {
                int adjustedIndex = i * gradient.Count / text.Length; // Adjust index dynamically
                Colour currentColour = gradient[adjustedIndex % gradient.Count];
                return $"{Ansi.Text.Coloured(currentColour, foreground)}{c}";
            }));

            /// <summary>
            /// Generates an ANSI escape sequence for creating a hyperlink.
            /// </summary>
            /// <param name="link">The URL to link to.</param>
            /// <param name="text">The text to display as the hyperlink, if no label is provided the link is used as the label</param>
            /// <param name="coloured">Specifies whether to colourize the hyperlink text.</param>
            /// <returns>The ANSI escape sequence for creating the hyperlink.</returns>
            /// <remarks>
            /// For coloured hyperlinks, the default colour is blue. new Colour(51, 102, 187)
            /// </remarks>
            /// <typeinfo>public static string</typeinfo>
            public static string Hyperlink(string link, string? text = null, bool coloured = true) {
                if (string.IsNullOrEmpty(text)) text = link;

                return coloured ?
                        $"{Ansi.Text.Coloured(new(51, 102, 187))}{OSC}8;;{link}{BELL}{text}{OSC}8;;{BELL}" :
                        $"{OSC}8;;{link}{BELL}{text}{OSC}8;;{BELL}";
            }

            /// <summary>
            /// Generates an ANSI escape sequence for resetting text formatting and styling to default.
            /// </summary>
            /// <returns>The ANSI escape sequence for resetting text formatting and styling.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string Reset() => Ansi.Text.Style(AnsiStyle.Reset);

            /// <summary>
            /// Generates an ANSI escape sequence for selecting graphic rendition parameters.
            /// </summary>
            /// <param name="codes">An array of byte values representing the graphic rendition parameters.</param>
            /// <returns>The ANSI escape sequence for selecting the specified graphic rendition.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string SelectGraphicRendition(params byte[] codes) => $"{CSI}{string.Join(";", codes)}m";
            /// <summary>
            /// Generates an ANSI escape sequence for applying a text style.
            /// </summary>
            /// <param name="style">The ANSI text style to apply.</param>
            /// <returns>The ANSI escape sequence for applying the specified text style.</returns>
            /// <typeinfo>public static string</typeinfo>
            public static string Style(AnsiStyle style) => Ansi.Text.SelectGraphicRendition((byte)style);

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}
