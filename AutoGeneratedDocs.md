<a name='assembly'></a>
# consoletestproject
---
<a name='T:consoletestproject.Coloureds.Colour'></a>
### consoletestproject.Coloureds.Colour `Type`
#### Summary
Represents a color with RGB components.

---
<a name='F:consoletestproject.Coloureds.Colour.b'></a>
### consoletestproject.Coloureds.Colour.b `Field` `public byte`
#### Summary
The blue component of the color (0-255).

---
<a name='F:consoletestproject.Coloureds.Colour.g'></a>
### consoletestproject.Coloureds.Colour.g `Field` `public byte`
#### Summary
The green component of the color (0-255).

---
<a name='F:consoletestproject.Coloureds.Colour.r'></a>
### consoletestproject.Coloureds.Colour.r `Field` `public byte`
#### Summary
The red component of the color (0-255).

---
<a name='M:consoletestproject.Coloureds.Colour.#ctor(System.String)'></a>
### consoletestproject.Coloureds.Colour.#ctor(System.String) `ConstructorMethod` `public`
#### Summary
Initializes a new instance of the  class
            with the specified hexadecimal color string.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| hexColour | System.String | The hexadecimal color string (e.g., "#RRGGBB").

---
<a name='M:consoletestproject.Coloureds.Colour.#ctor(System.Byte,System.Byte,System.Byte)'></a>
### consoletestproject.Coloureds.Colour.#ctor(System.Byte,System.Byte,System.Byte) `ConstructorMethod` `public`
#### Summary
Initializes a new instance of the  class
            with the specified RGB components.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| r | System.Byte | The red component of the color (0-255).
| g | System.Byte | The green component of the color (0-255).
| b | System.Byte | The blue component of the color (0-255).

---
<a name='M:consoletestproject.Coloureds.Colour.#ctor'></a>
### consoletestproject.Coloureds.Colour.#ctor `ConstructorMethod` `public`
#### Summary
Initializes a new instance of the  class.

---
<a name='M:consoletestproject.Coloureds.Colour.Gradient(System.Collections.Generic.List{consoletestproject.Coloureds.Colour},System.Int32)'></a>
### consoletestproject.Coloureds.Colour.Gradient(System.Collections.Generic.List{consoletestproject.Coloureds.Colour},System.Int32) `Method` `public static List<Colour>`
#### Summary
Generates a gradient between given colours.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| colours | System.Collections.Generic.List{consoletestproject.Coloureds.Colour} | The list of colours to interpolate between.
| granularity | System.Int32 | The number of steps in the gradient. Default is 12.
#### Returns
The list of colours representing the gradient.

---
<a name='M:consoletestproject.Coloureds.Colour.HexToRgb(System.String,System.Byte@,System.Byte@,System.Byte@)'></a>
### consoletestproject.Coloureds.Colour.HexToRgb(System.String,System.Byte@,System.Byte@,System.Byte@) `Method` `public static void`
#### Summary
Converts a hexadecimal Colour code to its corresponding RGB representation.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| hexColour | System.String | The hexadecimal Colour code to convert.
| r | System.Byte@ | When this method returns, contains the red component of the RGB representation of the Colour, as a byte.
| g | System.Byte@ | When this method returns, contains the green component of the RGB representation of the Colour, as a byte.
| b | System.Byte@ | When this method returns, contains the blue component of the RGB representation of the Colour, as a byte.

---
<a name='M:consoletestproject.Coloureds.Colour.ParseColour(System.String)'></a>
### consoletestproject.Coloureds.Colour.ParseColour(System.String) `Method` `public static Colour?`
#### Summary
Parses a color string to create a  object.
            Supports RGB R, G, B and hexadecimal #AABBCC format.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| args | System.String | The color argument string to parse.
#### Returns
A  object if parsing is successful; otherwise, null.

---
<a name='M:consoletestproject.Coloureds.Colour.RgbToHex(System.Byte,System.Byte,System.Byte)'></a>
### consoletestproject.Coloureds.Colour.RgbToHex(System.Byte,System.Byte,System.Byte) `Method` `public static string`
#### Summary
Converts RGB values to a hexadecimal Colour code.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| r | System.Byte | The red component of the Colour, as a byte.
| g | System.Byte | The green component of the Colour, as a byte.
| b | System.Byte | The blue component of the Colour, as a byte.
#### Returns
The hexadecimal Colour code as a string.

---
<a name='M:consoletestproject.Coloureds.Colour.GetComplementary'></a>
### consoletestproject.Coloureds.Colour.GetComplementary `Method` `public Colour`
#### Summary
Calculates and returns the complementary color of the current color.
#### Returns
The complementary  object.

---
<a name='M:consoletestproject.Coloureds.Colour.InterpolateColour(consoletestproject.Coloureds.Colour,System.Double)'></a>
### consoletestproject.Coloureds.Colour.InterpolateColour(consoletestproject.Coloureds.Colour,System.Double) `Method` `public Colour`
#### Summary
Interpolates between the instance colour and the provided colour.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| colour | consoletestproject.Coloureds.Colour | The colour to interpolate with.
| ratio | System.Double | The interpolation ratio (0.0 to 1.0).
#### Returns
The interpolated colour.

---
<a name='M:consoletestproject.Coloureds.Colour.ToHex'></a>
### consoletestproject.Coloureds.Colour.ToHex `Method` `public string`
#### Summary
Converts the current RGB Colour values to a hexadecimal Colour code.
#### Returns
A string representing the hexadecimal Colour code.

---
<a name='M:consoletestproject.Coloureds.Colour.IsHexFormat(System.String)'></a>
### consoletestproject.Coloureds.Colour.IsHexFormat(System.String) `Method` `private static bool`
#### Summary
Checks if the given string represents a hexadecimal color code.
            Hexadecimal color codes can be in the format #AABBCC or AABBCC.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| str | System.String | The string to check.
#### Returns
True if the string is a hexadecimal color code, false otherwise.

---
<a name='M:consoletestproject.Coloureds.Colour.Interpolate(System.Byte,System.Byte,System.Double)'></a>
### consoletestproject.Coloureds.Colour.Interpolate(System.Byte,System.Byte,System.Double) `Method` `private static byte`
#### Summary
Interpolates between two values.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| start | System.Byte | The starting value.
| end | System.Byte | The ending value.
| ratio | System.Double | The interpolation ratio.
#### Returns
The interpolated value.

---
<a name='M:consoletestproject.Coloureds.Colour.InterpolateColours(consoletestproject.Coloureds.Colour,consoletestproject.Coloureds.Colour,System.Int32,System.Collections.Generic.List{consoletestproject.Coloureds.Colour})'></a>
### consoletestproject.Coloureds.Colour.InterpolateColours(consoletestproject.Coloureds.Colour,consoletestproject.Coloureds.Colour,System.Int32,System.Collections.Generic.List{consoletestproject.Coloureds.Colour}) `Method` `private static void`
#### Summary
Interpolates between two colours.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| start | consoletestproject.Coloureds.Colour | The starting colour.
| end | consoletestproject.Coloureds.Colour | The ending colour.
| granularity | System.Int32 | The number of steps in the interpolation.
| results | System.Collections.Generic.List{consoletestproject.Coloureds.Colour} | The list to store the interpolated colours.

---
<a name='M:consoletestproject.Coloureds.Colour.op_Inequality(consoletestproject.Coloureds.Colour,consoletestproject.Coloureds.Colour)'></a>
### consoletestproject.Coloureds.Colour.op_Inequality(consoletestproject.Coloureds.Colour,consoletestproject.Coloureds.Colour) `Method` `public static bool operator !=`
#### Summary
Checks if two Colour objects are not equal.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| colour1 | consoletestproject.Coloureds.Colour | The first Colour object.
| colour2 | consoletestproject.Coloureds.Colour | The second Colour object.
#### Returns
true if the Colour objects are not equal; otherwise, false.

---
<a name='M:consoletestproject.Coloureds.Colour.op_Equality(consoletestproject.Coloureds.Colour,consoletestproject.Coloureds.Colour)'></a>
### consoletestproject.Coloureds.Colour.op_Equality(consoletestproject.Coloureds.Colour,consoletestproject.Coloureds.Colour) `Method` `public static bool operator ==`
#### Summary
Checks if two Colour objects are equal.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| colour1 | consoletestproject.Coloureds.Colour | The first Colour object.
| colour2 | consoletestproject.Coloureds.Colour | The second Colour object.
#### Returns
true if the Colour objects are equal; otherwise, false.

---
<a name='M:consoletestproject.Coloureds.Colour.Equals(System.Object)'></a>
### consoletestproject.Coloureds.Colour.Equals(System.Object) `Method` `public override bool`
#### Summary
Checks if the current color is equal to another color.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| colour | System.Object | The other color to check for equality
#### Returns
true if the colors are equal; otherwise, false.

---
<a name='M:consoletestproject.Coloureds.Colour.GetHashCode'></a>
### consoletestproject.Coloureds.Colour.GetHashCode `Method` `public override int`
#### Summary
Returns a hash code for the current  object.
            This method is used to provide a unique identifier for the object,
            and ensures that two  objects with the same RGB values
            have the same hash code. This is important for collections that use hashing,
            such as dictionaries or hash sets.
#### Returns
A hash code for the current  object, which is a 32-bit signed integer.

---
<a name='T:consoletestproject.ConsoleHelper.Ansi'></a>
### consoletestproject.ConsoleHelper.Ansi `Type`
#### Summary
Provides constants and utilities for ANSI escape codes and text formatting.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.BELL'></a>
### consoletestproject.ConsoleHelper.Ansi.BELL `Field` `public const string`
#### Summary
Terminal bell

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.CR'></a>
### consoletestproject.ConsoleHelper.Ansi.CR `Field` `public const string`
#### Summary
Carriage Return, used for resetting the cursor/device position back to the beginning of a line.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.CSI'></a>
### consoletestproject.ConsoleHelper.Ansi.CSI `Field` `public const string`
#### Summary
Control Sequence Introducer, used to start ANSI escape sequences.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.DEL'></a>
### consoletestproject.ConsoleHelper.Ansi.DEL `Field` `public const string`
#### Summary
The ASCII delete character (DEL), used to delete characters.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.ESC'></a>
### consoletestproject.ConsoleHelper.Ansi.ESC `Field` `public const string`
#### Summary
The ASCII escape character (ESC), used to introduce control sequences.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.OSC'></a>
### consoletestproject.ConsoleHelper.Ansi.OSC `Field` `public const string`
#### Summary
Operating System Command, used to send commands to the terminal.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.SOS'></a>
### consoletestproject.ConsoleHelper.Ansi.SOS `Field` `public const string`
#### Summary
Start of String, used to mark the beginning of device control strings.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.ST'></a>
### consoletestproject.ConsoleHelper.Ansi.ST `Field` `public const string`
#### Summary
String Terminator, used to mark the end of device control strings.

---
<a name='T:consoletestproject.ConsoleHelper.Ansi.AnsiStyle'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle `Type` `public enum byte`
#### Summary
Also know as graphic options / graphic renditions, these are used within 
            These are widely supported graphic options

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Reset'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Reset `Field`
#### Summary
Used for resetting all text attributes/styles regarding ansi escape codes.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Bold'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Bold `Field`
#### Summary
Used for increased intensity (opposite of Faint where it is used for decreased intensity)

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Faint'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Faint `Field`
#### Summary
Used for decreased intensity (opposite of bold where it is used for increased intensity)

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Italic'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Italic `Field`
#### Summary
Used for italicizing text

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Underline'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Underline `Field`
#### Summary
Used for underlinning text.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Blink'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Blink `Field`
#### Summary
Used for slow-blinking text.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Invert'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Invert `Field`
#### Summary
Used for inverting the foreground and background colors.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Concealed'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Concealed `Field`
#### Summary
Used for "concealing" the text / making the text invisible

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Strikethrough'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Strikethrough `Field`
#### Summary
Used for strikethrough text

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.DoubleUnderline'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.DoubleUnderline `Field`
#### Summary
Used for double underlining text

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Overline'></a>
### consoletestproject.ConsoleHelper.Ansi.AnsiStyle.Overline `Field`
#### Summary
Used for overlining text

---
<a name='T:consoletestproject.ConsoleHelper.Ansi.Cursor'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor `Type` `public static class`
#### Summary
Provides utility methods for the cursor using ANSI escape sequences.

---
<a name='T:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle `Type` `public enum byte`
#### Summary
Represents different styles of the cursor.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.BlinkingBlock'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.BlinkingBlock `Field`
#### Summary
Default cursor style: blinking block.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.SteadyBlock'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.SteadyBlock `Field`
#### Summary
Steady block cursor style.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.BlinkingUnderline'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.BlinkingUnderline `Field`
#### Summary
Blinking underline cursor style.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.SteadyUnderline'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.SteadyUnderline `Field`
#### Summary
Steady underline cursor style.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.BlinkingBar'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.BlinkingBar `Field`
#### Summary
Blinking bar cursor style.

---
<a name='F:consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.SteadyBar'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle.SteadyBar `Field`
#### Summary
Steady bar cursor style.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveDown(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveDown(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor down by the specified number of lines using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| lines | System.Int32 | The number of lines to move down.
#### Returns
The ANSI escape sequence to move the cursor down.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveLeft(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveLeft(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor left by the specified number of columns using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| columns | System.Int32 | The number of columns to move left.
#### Returns
The ANSI escape sequence to move the cursor left.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveRight(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveRight(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor right by the specified number of columns using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| columns | System.Int32 | The number of columns to move right.
#### Returns
The ANSI escape sequence to move the cursor right.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToColumn(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToColumn(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor to the specified column using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| column | System.Int32 | The column number (1-based) to move to.
#### Returns
The ANSI escape sequence to move the cursor to the specified column.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToHome'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToHome `Method` `public static string`
#### Summary
Moves the cursor to the home position (top-left corner of the screen) using ANSI escape sequences.
#### Returns
The ANSI escape sequence to move the cursor to the home position.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToNextLine(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToNextLine(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor to the next line, down by the specified number of lines, using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| lines | System.Int32 | The number of lines to move down.
#### Returns
The ANSI escape sequence to move the cursor to the next line.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToPosition(System.Int32,System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToPosition(System.Int32,System.Int32) `Method` `public static string`
#### Summary
Moves the cursor to the specified position using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| line | System.Int32 | The line number (1-based) to move to.
| column | System.Int32 | The column number (1-based) to move to.
#### Returns
The ANSI escape sequence to move the cursor to the specified position.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToPreviousLine(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveToPreviousLine(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor to the previous line, up by the specified number of lines, using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| lines | System.Int32 | The number of lines to move up.
#### Returns
The ANSI escape sequence to move the cursor to the previous line.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.MoveUp(System.Int32)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.MoveUp(System.Int32) `Method` `public static string`
#### Summary
Moves the cursor up by the specified number of lines using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| lines | System.Int32 | The number of lines to move up.
#### Returns
The ANSI escape sequence to move the cursor up.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.RequestCursorPosition'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.RequestCursorPosition `Method` `public static string`
#### Summary
Requests the current cursor position using ANSI escape sequences.
#### Returns
The ANSI escape sequence to request the current cursor position.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.ResetCursorStyle'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.ResetCursorStyle `Method` `public static string`
#### Summary
Resets the cursor style to the default blinking block.
#### Returns
The ANSI escape sequence to reset the cursor style.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.RestoreCursorPosition'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.RestoreCursorPosition `Method` `public static string`
#### Summary
Restores the previously saved cursor position and attributes using ANSI escape sequences.
#### Returns
The ANSI escape sequence to restore the saved cursor position.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.RestoreCursorPositionSCO'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.RestoreCursorPositionSCO `Method` `public static string`
#### Summary
Restores the previously saved cursor position and attributes using ANSI escape sequences (SCO-style).
#### Returns
The ANSI escape sequence to restore the saved cursor position (SCO-style).

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.SaveCursorPosition'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.SaveCursorPosition `Method` `public static string`
#### Summary
Saves the current cursor position and attributes using ANSI escape sequences.
#### Returns
The ANSI escape sequence to save the current cursor position.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.SaveCursorPositionSCO'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.SaveCursorPositionSCO `Method` `public static string`
#### Summary
Saves the current cursor position and attributes using ANSI escape sequences (SCO-style).
#### Returns
The ANSI escape sequence to save the current cursor position (SCO-style).

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.ScrollUp'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.ScrollUp `Method` `public static string`
#### Summary
Scrolls the screen up by one line using ANSI escape sequences.
#### Returns
The ANSI escape sequence to scroll the screen up.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.SetCursorBlinking(System.Boolean)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.SetCursorBlinking(System.Boolean) `Method` `public static string`
#### Summary
Sets the cursor blinking state using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| blinking | System.Boolean | Specifies whether to enable blinking (true) or disable it (false).
#### Returns
The ANSI escape sequence to set the cursor blinking state.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.SetCursorStyle(consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.SetCursorStyle(consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle) `Method` `public static string`
#### Summary
Sets the cursor style using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| style | consoletestproject.ConsoleHelper.Ansi.Cursor.CursorStyle | The style of the cursor to set.
#### Returns
The ANSI escape sequence to set the specified cursor style.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Cursor.SetCursorVisibility(System.Boolean)'></a>
### consoletestproject.ConsoleHelper.Ansi.Cursor.SetCursorVisibility(System.Boolean) `Method` `public static string`
#### Summary
Sets the cursor visibility using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| visible | System.Boolean | Specifies whether to make the cursor visible (true) or invisible (false).
#### Returns
The ANSI escape sequence to set the cursor visibility.

---
<a name='T:consoletestproject.ConsoleHelper.Ansi.Text'></a>
### consoletestproject.ConsoleHelper.Ansi.Text `Type` `public static class`
#### Summary
Provides utility methods for generating ANSI escape sequences for text formatting and styling.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.Coloured(consoletestproject.Coloureds.Colour,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.Coloured(consoletestproject.Coloureds.Colour,System.Boolean) `Method` `public static string`
#### Summary
Generates an ANSI escape sequence for setting the text colour.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| colour | consoletestproject.Coloureds.Colour | The colour to set.
| foreground | System.Boolean | Specifies whether to set the foreground colour (true) or background colour (false).
#### Returns
The ANSI escape sequence for setting the specified colour.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.DECPMSet(System.Byte,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.DECPMSet(System.Byte,System.Boolean) `Method` `public static string`
#### Summary
Generates an ANSI escape sequence for activating or deactivating a DEC private mode.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| code | System.Byte | The DEC private mode code.
| set | System.Boolean | Specifies whether to activate (true) or deactivate (false) the mode.
#### Returns
The ANSI escape sequence for activating or deactivating the specified DEC private mode.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.Gradient(System.Collections.Generic.List{consoletestproject.Coloureds.Colour},System.String,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.Gradient(System.Collections.Generic.List{consoletestproject.Coloureds.Colour},System.String,System.Boolean) `Method` `public static string`
#### Summary
Generates a gradient-coloured text using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| gradient | System.Collections.Generic.List{consoletestproject.Coloureds.Colour} | A list of colours representing the gradient.
| text | System.String | The text to colourize with the gradient.
| foreground | System.Boolean | Specifies whether to set the foreground colour (true) or background colour (false).
#### Returns
The colourized text with gradient effect.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.Hyperlink(System.String,System.String,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.Hyperlink(System.String,System.String,System.Boolean) `Method` `public static string`
#### Summary
Generates an ANSI escape sequence for creating a hyperlink.
#### Remarks
For coloured hyperlinks, the default colour is blue. new Colour(51, 102, 187)
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| link | System.String | The URL to link to.
| text | System.String | The text to display as the hyperlink, if no label is provided the link is used as the label
| coloured | System.Boolean | Specifies whether to colourize the hyperlink text.
#### Returns
The ANSI escape sequence for creating the hyperlink.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.Reset'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.Reset `Method` `public static string`
#### Summary
Generates an ANSI escape sequence for resetting text formatting and styling to default.
#### Returns
The ANSI escape sequence for resetting text formatting and styling.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.SelectGraphicRendition(System.Byte[])'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.SelectGraphicRendition(System.Byte[]) `Method` `public static string`
#### Summary
Generates an ANSI escape sequence for selecting graphic rendition parameters.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| codes | System.Byte[] | An array of byte values representing the graphic rendition parameters.
#### Returns
The ANSI escape sequence for selecting the specified graphic rendition.

---
<a name='M:consoletestproject.ConsoleHelper.Ansi.Text.Style(consoletestproject.ConsoleHelper.Ansi.AnsiStyle)'></a>
### consoletestproject.ConsoleHelper.Ansi.Text.Style(consoletestproject.ConsoleHelper.Ansi.AnsiStyle) `Method` `public static string`
#### Summary
Generates an ANSI escape sequence for applying a text style.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| style | consoletestproject.ConsoleHelper.Ansi.AnsiStyle | The ANSI text style to apply.
#### Returns
The ANSI escape sequence for applying the specified text style.

---
<a name='T:consoletestproject.ConsoleHelper.ConsoleInput'></a>
### consoletestproject.ConsoleHelper.ConsoleInput `Type`
#### Summary
Provides methods for retrieving console input.

---
<a name='M:consoletestproject.ConsoleHelper.ConsoleInput.Get(System.String,System.String,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.ConsoleInput.Get(System.String,System.String,System.Boolean) `Method` `public static string?`
#### Summary
Prompts the user for input and returns the entered string.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| prompt | System.String | Optional. The prompt to display to the user before input.
| inputDelimiter | System.String | Optional. The delimiter to display before the input prompt. Defaults to MenuConfig.standardInputDelimiter, if not provided.
| trimOutput | System.Boolean | Optional. Indicates whether to trim leading and trailing whitespace from the input. Defaults to false.
#### Returns
The string entered by the user, or null if no input is provided.

---
<a name='M:consoletestproject.ConsoleHelper.ConsoleInput.GetAsBool(System.String,System.String)'></a>
### consoletestproject.ConsoleHelper.ConsoleInput.GetAsBool(System.String,System.String) `Method` `public static bool?`
#### Summary
Prompts the user for input and returns the entered boolean value.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| prompt | System.String | Optional. The prompt to display to the user before input.
| inputDelimiter | System.String | Optional. The delimiter to display before the input prompt. Defaults to MenuConfig.standardInputDelimiter, if not provided.
#### Returns
The boolean value entered by the user (case-insensitive): 
            - true if the user entered "yes", "y", "enable", "confirm", "ok" or a valid boolean string. 
            - false if the user entered "no", "n", "disable", "cancel" or a valid boolean string. 
            - null if no input is provided or if the input cannot be parsed as a boolean value.

---
<a name='M:consoletestproject.ConsoleHelper.ConsoleInput.GetAsInt(System.String,System.String)'></a>
### consoletestproject.ConsoleHelper.ConsoleInput.GetAsInt(System.String,System.String) `Method` `public static int?`
#### Summary
Prompts the user for input and returns the entered integer value.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| prompt | System.String | 
| inputDelimiter | System.String | The delimiter to display before the input prompt. Defaults to ">". If not provided, uses MenuConfig.standardInputDelimiter.
#### Returns
The integer value entered by the user, or null if the input cannot be parsed as an integer or no input is provided.

---
<a name='M:consoletestproject.ConsoleHelper.ConsoleInput.GetKey(System.String,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.ConsoleInput.GetKey(System.String,System.Boolean) `Method` `public static ConsoleKey`
#### Summary
Waits for a key press from the console input and returns the ConsoleKey of the pressed key.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| prompt | System.String | The prompt to display before waiting for key input.
| displayPressedkey | System.Boolean | displayPressedkey if false, makes sure the entered character is never displayed if pressed
#### Returns
The ConsoleKey of the pressed key.

---
<a name='M:consoletestproject.ConsoleHelper.ConsoleInput.GetListBoxSelection(System.String,System.Collections.Generic.List{System.String},System.Action{consoletestproject.Menus.MenuOption,System.String,System.Int32},consoletestproject.Menus.Menu,System.Boolean)'></a>
### consoletestproject.ConsoleHelper.ConsoleInput.GetListBoxSelection(System.String,System.Collections.Generic.List{System.String},System.Action{consoletestproject.Menus.MenuOption,System.String,System.Int32},consoletestproject.Menus.Menu,System.Boolean) `Method` `public static void`
#### Summary
Displays a menu with a list of items for selection and invokes a callback with the selected item's details.
#### Remarks
Example usage:
            
            ConsoleInput.GetListBoxSelection("Select a colour", ["red", "green", "blue", "very blue"], (MenuOption optionContext, string option, int index) => {
                        ConsoleInput.GetKey($"Selected {option} [{index}]\nPress any key to continue...");
            }, parentToShowAfterExecute: context?.parent, shouldRemoveMenuAfterExecute: true);
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| prompt | System.String | The prompt message to display at the top of the menu.
| items | System.Collections.Generic.List{System.String} | The list of strings representing the items to display in the menu.
| callback | System.Action{consoletestproject.Menus.MenuOption | The callback function that will be invoked when an item is selected. 
            Takes three parameters: the selected , the selected item string, and its index in the original list.
| parentToShowAfterExecute | System.String | The parent menu to show after executing the callback. It can be null.
| shouldRemoveMenuAfterExecute | System.Int32} | Specifies whether the menu should be removed after executing the callback.
            This should always be true if you have a parentToShowAfterExecute set to a menu, as it will prevent wasting memory.

---
<a name='T:consoletestproject.Extensions.EnumerableExtensions'></a>
### consoletestproject.Extensions.EnumerableExtensions `Type`
#### Summary
Provides extension methods for working with IEnumerable collections.

---
<a name='M:consoletestproject.Extensions.EnumerableExtensions.IsEmptyOrNull``1(System.Collections.Generic.IEnumerable{``0})'></a>
### consoletestproject.Extensions.EnumerableExtensions.IsEmptyOrNull``1(System.Collections.Generic.IEnumerable{``0}) `Method` `public static bool`
#### Summary
Checks if the specified enumerable collection is either null, empty, or consists of only null or whitespace elements (if the enumerable is of type string).
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| enumerable | System.Collections.Generic.IEnumerable{``0} | The enumerable collection to check.
#### Returns
True if the enumerable is null, empty, or contains only null or whitespace elements (for strings); otherwise, false.

---
<a name='M:consoletestproject.Extensions.EnumerableExtensions.IsValidIndex``1(System.Collections.Generic.IEnumerable{``0},System.Int32)'></a>
### consoletestproject.Extensions.EnumerableExtensions.IsValidIndex``1(System.Collections.Generic.IEnumerable{``0},System.Int32) `Method` `public static bool`
#### Summary
Checks if the specified index is a valid index within the enumerable collection.
#### Remarks
The enumerable collection must not be null or empty for the index to be considered valid.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| enumerable | System.Collections.Generic.IEnumerable{``0} | The enumerable collection.
| index | System.Int32 | The index to check.
#### Returns
True if the index is valid within the bounds of the enumerable; otherwise, false.

---
<a name='T:consoletestproject.Extensions.StringExtensions'></a>
### consoletestproject.Extensions.StringExtensions `Type`
#### Summary
Provides extension methods for string manipulation with ANSI escape sequences for text formatting and styling.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Coloured(System.String,consoletestproject.Coloureds.Colour,System.Boolean)'></a>
### consoletestproject.Extensions.StringExtensions.Coloured(System.String,consoletestproject.Coloureds.Colour,System.Boolean) `Method` `public static string`
#### Summary
Applies a foreground or background colour to the specified text using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to colourize.
| colour | consoletestproject.Coloureds.Colour | The colour to apply.
| foreground | System.Boolean | Specifies whether to apply the colour as foreground (true) or background (false).
#### Returns
The colourized text.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Format(System.String)'></a>
### consoletestproject.Extensions.StringExtensions.Format(System.String) `Method` `public static string`
#### Summary
WARNING: MIGHT BE GUGGY IN CONJUCTION WITH OTHER FUNCTIONS LIKE GRADIENT, use Ansi.Text directly instead if this is the case
            Formats a string with ANSI escape sequences based on specified tags. For example: [STYLE Bold][COLOUR 255,0,0]Formatted Text[RESET].
#### Remarks
This method applies formatting to the input text based on tags enclosed in square brackets. Supported tags are: 
            - [COLOUR <colour>]/[COLOR <colour>]/ for specifying foreground text colour, where <colour> can be either RGB values (eg, 255,0,0) or a hexadecimal color code (eg, #FF0000).  
            - [BGCOLOUR <colour>]/[BGCOLOR <colour>]/ for specifying background colour, where <colour> can be either RGB values (eg, 255,0,0) or a hexadecimal color code (eg, #FF0000).  
            - [STYLE <style>] for specifying text style, where <style> can be any valid value from AnsiStyle (eg, Bold), or any valid index from AnsiStyle, (eg 1 for bold) 
            - [RESET] for resetting text formatting.  
            Note: The tags are case-sensitive; if a tag's arguments or name are invalid, they will simply not be matched and left as is.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to format.
#### Returns
The formatted text with ANSI escape sequences.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Gradient(System.String,System.Collections.Generic.List{consoletestproject.Coloureds.Colour},System.Boolean)'></a>
### consoletestproject.Extensions.StringExtensions.Gradient(System.String,System.Collections.Generic.List{consoletestproject.Coloureds.Colour},System.Boolean) `Method` `public static string`
#### Summary
Applies a gradient effect to the specified text using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to colourize with the gradient.
| gradient | System.Collections.Generic.List{consoletestproject.Coloureds.Colour} | A list of colours representing the gradient.
| foreground | System.Boolean | Specifies whether to set the foreground colour (true) or background colour (false).
#### Returns
The text with gradient effect applied.

---
<a name='M:consoletestproject.Extensions.StringExtensions.HyperLink(System.String,System.String,System.Boolean)'></a>
### consoletestproject.Extensions.StringExtensions.HyperLink(System.String,System.String,System.Boolean) `Method` `public static string`
#### Summary
Converts the specified text into a hyperlink with the given URL using ANSI escape sequences.
#### Remarks
For colour hyperlinks, the default colour is blue.
            
            Example usage:
            
            "Calculator Hyperlink. Click me".HyperLink(link: "calculator://", coloured: true).WriteLine();
            "Google.com Hyperlink. Click me".HyperLink(link: "https://google.com", coloured: false).WriteLine();
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to convert into a hyperlink.
| link | System.String | The URL to link to.
| coloured | System.Boolean | Specifies whether to colourize the hyperlink text.
#### Returns
The text formatted as a hyperlink.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Reset(System.String,System.Boolean)'></a>
### consoletestproject.Extensions.StringExtensions.Reset(System.String,System.Boolean) `Method` `public static string`
#### Summary
Resets the text formatting and styling to default for the specified text using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to reset.
| reverse | System.Boolean | Specifies whether to reset text formatting and styling in reverse order.
#### Returns
The text with formatting and styling reset.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Style(System.String,consoletestproject.ConsoleHelper.Ansi.AnsiStyle)'></a>
### consoletestproject.Extensions.StringExtensions.Style(System.String,consoletestproject.ConsoleHelper.Ansi.AnsiStyle) `Method` `public static string`
#### Summary
Applies a text style to the specified text using ANSI escape sequences.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to style.
| style | consoletestproject.ConsoleHelper.Ansi.AnsiStyle | The ANSI text style to apply.
#### Returns
The styled text.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Superscript(System.String)'></a>
### consoletestproject.Extensions.StringExtensions.Superscript(System.String) `Method` `public static string`
#### Summary
Converts the input text to superscript. ˢᵐᵃˡˡ ᵗᵉˣᵗ
#### Remarks
This method converts alphanumeric characters in the input text to their corresponding Unicode superscript characters
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to convert to superscript.
#### Returns
The input text converted to superscript.

---
<a name='M:consoletestproject.Extensions.StringExtensions.Write(System.String,System.Boolean)'></a>
### consoletestproject.Extensions.StringExtensions.Write(System.String,System.Boolean) `Method` `public static void`
#### Summary
Writes the specified text to the console without a newline character.
#### Remarks
Example usage:
            
            "[STYLE Bold]Hello, World![RESET]".Write(shouldFormat: true); // Equivalent to Console.Write("[STYLE Bold]Hello, World![RESET]".Format());
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to write to the console.
| shouldFormat | System.Boolean | A boolean indicating whether the text should be formatted before writing to the console.

---
<a name='M:consoletestproject.Extensions.StringExtensions.WriteLine(System.String,System.Boolean)'></a>
### consoletestproject.Extensions.StringExtensions.WriteLine(System.String,System.Boolean) `Method` `public static void`
#### Summary
Writes the specified text to the console, followed by the current line terminator.
#### Remarks
Example usage:
            
            "[STYLE Italic]Hello, World![RESET]".WriteLine(shouldFormat: true); // Equivalent to Console.Write("[STYLE Italic]Hello, World![RESET]".Format());
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to write to the console.
| shouldFormat | System.Boolean | A boolean indicating whether the text should be formatted before writing to the console.

---
<a name='M:consoletestproject.Extensions.StringExtensions.CharacterMap(System.String,System.Collections.Generic.Dictionary{System.Char,System.String})'></a>
### consoletestproject.Extensions.StringExtensions.CharacterMap(System.String,System.Collections.Generic.Dictionary{System.Char,System.String}) `Method` `private static string`
#### Summary
Converts the text to unicode using a provided mapping dictionary.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The text to convert to superscript.
| Fontmap | System.Collections.Generic.Dictionary{System.Char | A dictionary that maps characters to their unicode equivalents.
#### Returns
The text in unicode form.

---
<a name='T:consoletestproject.Menus.Menu'></a>
### consoletestproject.Menus.Menu `Type`
#### Summary
Represents a menu with an ID, name, and menu options

---
<a name='F:consoletestproject.Menus.Menu.id'></a>
### consoletestproject.Menus.Menu.id `Field`
#### Summary
The unique identifier of the menu.

---
<a name='F:consoletestproject.Menus.Menu.menuOptions'></a>
### consoletestproject.Menus.Menu.menuOptions `Field`
#### Summary
The list of menu options available in the menu.

---
<a name='F:consoletestproject.Menus.Menu.name'></a>
### consoletestproject.Menus.Menu.name `Field`
#### Summary
The name of the menu.

---
<a name='M:consoletestproject.Menus.Menu.#ctor(System.Int32,System.String,System.Collections.Generic.List{consoletestproject.Menus.MenuOption})'></a>
### consoletestproject.Menus.Menu.#ctor(System.Int32,System.String,System.Collections.Generic.List{consoletestproject.Menus.MenuOption}) `ConstructorMethod`
#### Summary
Initializes a new instance of the  class.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier of the menu.
| name | System.String | The name of the menu.
| menuOptions | System.Collections.Generic.List{consoletestproject.Menus.MenuOption} | The options available in the menu.

---
<a name='M:consoletestproject.Menus.Menu.AddBackOption'></a>
### consoletestproject.Menus.Menu.AddBackOption `Method`
#### Summary
Adds a "Back" option to the menu with a callback to return to the previous menu that is different to the current one. 
            The ID of the newly added "Back" menu option will be determined based on the existing menu options. 
            If this is the first option being added, the ID will be set to 1. Otherwise, it will be set to the ID of the last menu option in the list plus 1.
#### Returns
The newly added "Back" menu option.

---
<a name='M:consoletestproject.Menus.Menu.AddExitOption'></a>
### consoletestproject.Menus.Menu.AddExitOption `Method`
#### Summary
Adds an "Exit" option to the menu with a callback to terminate the application.
            The ID of the newly added "Exit" menu option will be determined based on the existing menu options. 
            If this is the first option being added, the ID will be set to 1. Otherwise, it will be set to the ID of the last menu option in the list plus 1.
#### Remarks
This method creates a menu option titled "Exit" that, when selected, terminates the application.
#### Returns
The newly added "Exit" menu option.

---
<a name='M:consoletestproject.Menus.Menu.AddMenuOptions(System.Collections.Generic.List{consoletestproject.Menus.MenuOption})'></a>
### consoletestproject.Menus.Menu.AddMenuOptions(System.Collections.Generic.List{consoletestproject.Menus.MenuOption}) `Method`
#### Summary
Adds menu options to the menu.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| options | System.Collections.Generic.List{consoletestproject.Menus.MenuOption} | The options to be added.

---
<a name='M:consoletestproject.Menus.Menu.AddMenuOptions(consoletestproject.Menus.MenuOption)'></a>
### consoletestproject.Menus.Menu.AddMenuOptions(consoletestproject.Menus.MenuOption) `Method`
#### Summary
Adds a menu option to the menu.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| option | consoletestproject.Menus.MenuOption | The option to be added.

---
<a name='M:consoletestproject.Menus.Menu.AddMenuOptionWrapper(System.String,System.Action{consoletestproject.Menus.MenuOption})'></a>
### consoletestproject.Menus.Menu.AddMenuOptionWrapper(System.String,System.Action{consoletestproject.Menus.MenuOption}) `Method`
#### Summary
Wraps the addition of AddMenuOptions.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.String | The name of the menu option.
| callback | System.Action{consoletestproject.Menus.MenuOption} | The callback action to be executed when the menu option is selected.
#### Returns
The newly added menu option.

---
<a name='M:consoletestproject.Menus.Menu.GetMenuOptionById(System.Int32)'></a>
### consoletestproject.Menus.Menu.GetMenuOptionById(System.Int32) `Method`
#### Summary
Retrieves a menu option by its unique identifier.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier of the menu.
#### Returns
The menu with the specified ID, or null if not found.

---
<a name='M:consoletestproject.Menus.Menu.GetMenuOptions'></a>
### consoletestproject.Menus.Menu.GetMenuOptions `Method`
#### Summary
Gets the menu options available in the menu.
            If  is set to false,
            this will not return menu options where isDebug is set to true
#### Returns
The list of available menu options.

---
<a name='M:consoletestproject.Menus.Menu.MenuOptionIdToIndex(System.Int32)'></a>
### consoletestproject.Menus.Menu.MenuOptionIdToIndex(System.Int32) `Method`
#### Summary
Retrieves the index of the menu option with the specified ID.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier (ID) of the menu option to find.
#### Returns
The zero-based index of the menu option if found; otherwise, null.

---
<a name='M:consoletestproject.Menus.Menu.MenuOptionIndexToId(System.Int32)'></a>
### consoletestproject.Menus.Menu.MenuOptionIndexToId(System.Int32) `Method`
#### Summary
Retrieves the unique identifier (ID) of the menu option at the specified index.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| index | System.Int32 | The zero-based index of the menu option to retrieve the ID for.
#### Returns
The ID of the menu option if the index is valid; otherwise, null.

---
<a name='M:consoletestproject.Menus.Menu.Remove'></a>
### consoletestproject.Menus.Menu.Remove `Method`
#### Summary
Removes this menu from the service.
#### Remarks
This method removes the menu instance from the  by its unique identifier.
#### Returns
true if the menu was removed; false if no menu was found by the specified id.

---
<a name='M:consoletestproject.Menus.Menu.ResetSelectedOption'></a>
### consoletestproject.Menus.Menu.ResetSelectedOption `Method`
#### Summary
Resets the selected menu option, clearing any selection and resetting the display.
#### Remarks
This method resets the selected menu option within the current menu instance.
            It sets the internal index of the selected menu option to -1, indicating no option is selected.
            Additionally, it clears any visual indication of selection (such as underlining) from all menu options.

---
<a name='M:consoletestproject.Menus.Menu.SetOptionDisabled(System.Int32,System.Boolean)'></a>
### consoletestproject.Menus.Menu.SetOptionDisabled(System.Int32,System.Boolean) `Method`
#### Summary
Disables the specified menu option, when an MenuOption is disabled it cannot be selected / executed. 
            It also get's this text decoration: [STYLE Faint][STYLE Strikethrough]
#### Remarks
This method sets the isDisabled property of the menu option specified by  to true, making it disabled.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| index | System.Int32 | The zero-based index of the menu option to disable. This is not the option ID but the position in the menu options list aka the index.
| value | System.Boolean | 

---
<a name='M:consoletestproject.Menus.Menu.SetOptionSelectedDecoration(System.Int32)'></a>
### consoletestproject.Menus.Menu.SetOptionSelectedDecoration(System.Int32) `Method`
#### Summary
Sets the specified menu option to appear with selected decoration
#### Remarks
This method modifies the appearance of the menu option specified by  to include a selected styled effect.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| index | System.Int32 | The zero-based index of the menu option to set blinking. This is not the option ID but the position in the menu options list.

---
<a name='M:consoletestproject.Menus.Menu.Show(System.Boolean,System.String,System.String,System.String)'></a>
### consoletestproject.Menus.Menu.Show(System.Boolean,System.String,System.String,System.String) `Method`
#### Summary
Displays the menu on the console with specified text Colour.
#### Remarks
If  is true and  is also true, the console will be cleared before displaying the menu.
            The menu is displayed with the specified text Colours for the title, option IDs, and option text.
            After displaying the menu, the current menu is set using .
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| shouldClear | System.Boolean | Specifies whether the console should be cleared before displaying the menu. Default is true.
| menuColourHex | System.String | The hexadecimal Colour code for the menu title.
| idColourHex | System.String | The hexadecimal Colour code for the menu option IDs.
| optionColourHex | System.String | The hexadecimal Colour code for the menu option text.

---
<a name='T:consoletestproject.Menus.MenuConfig'></a>
### consoletestproject.Menus.MenuConfig `Type`
#### Summary
Configuration settings for menus.

---
<a name='F:consoletestproject.Menus.MenuConfig._outputEncoding'></a>
### consoletestproject.Menus.MenuConfig._outputEncoding `Field`
#### Summary
Backing field to avoid recursion in the outputEncoding proprety.

---
<a name='P:consoletestproject.Menus.MenuConfig.clearConsoleAfterExecute'></a>
### consoletestproject.Menus.MenuConfig.clearConsoleAfterExecute `Property`
#### Summary
This indicates whether the console should be cleared after executing a "MenuOption" / command

---
<a name='P:consoletestproject.Menus.MenuConfig.clearConsoleAfterVisit'></a>
### consoletestproject.Menus.MenuConfig.clearConsoleAfterVisit `Property`
#### Summary
This indicates whether the console should be cleared before displaying / visiting a menu.

---
<a name='P:consoletestproject.Menus.MenuConfig.displayCurrentMenuAsConsoleTitle'></a>
### consoletestproject.Menus.MenuConfig.displayCurrentMenuAsConsoleTitle `Property`
#### Summary
This indicates whether the current menu's name should be displayed as the console title. 
            The format for this is: $"{this.name} [{this.id}]".

---
<a name='P:consoletestproject.Menus.MenuConfig.outputEncoding'></a>
### consoletestproject.Menus.MenuConfig.outputEncoding `Property`
#### Summary
Gets or sets the output encoding for the console.
#### Remarks
Setting this property will change the output encoding of the console to the specified encoding.

---
<a name='P:consoletestproject.Menus.MenuConfig.shouldHideAndDisplayCursorAutomatically'></a>
### consoletestproject.Menus.MenuConfig.shouldHideAndDisplayCursorAutomatically `Property`
#### Summary
Indicates whether the cursor should be automatically hidden and displayed during menu interactions. 
            If true, the cursor will be hidden when displaying the menu and shown when prompting for input. 
            If false, the cursor will always be shown.

---
<a name='P:consoletestproject.Menus.MenuConfig.shouldMarkDebugOptions'></a>
### consoletestproject.Menus.MenuConfig.shouldMarkDebugOptions `Property`
#### Summary
MenuOption's marked as "isDebug" will be marked with a purple suffix saying "DEBUG"

---
<a name='P:consoletestproject.Menus.MenuConfig.shouldShowDebugOptions'></a>
### consoletestproject.Menus.MenuConfig.shouldShowDebugOptions `Property`
#### Summary
MenuOption's marked as "isDebug" will not be shown if set to false

---
<a name='P:consoletestproject.Menus.MenuConfig.standardInputDelimiter'></a>
### consoletestproject.Menus.MenuConfig.standardInputDelimiter `Property`
#### Summary
The standard input delimiter used in ConsoleInput.sc

---
<a name='M:consoletestproject.Menus.MenuConfig.Configurate(System.Boolean,System.Boolean,System.String,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Text.Encoding)'></a>
### consoletestproject.Menus.MenuConfig.Configurate(System.Boolean,System.Boolean,System.String,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Text.Encoding) `Method`
#### Summary
Configures various settings related to menu behavior and console output. 
            For more info regarding parameters, instead of hovering over the parameters see the original property in MenuConfig
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| clearConsoleAfterVisit | System.Boolean | Indicates whether the console should be cleared after visiting a menu. By default; true
| clearConsoleAfterExecute | System.Boolean | Indicates whether the console should be cleared after executing a menu option or command. By default; false
| standardInputDelimiter | System.String | The standard input delimiter used in menu interactions. By default; ">>"
| shouldShowDebugOptions | System.Boolean | Specifies whether debug menu options should be shown. By default; true
| shouldMarkDebugOptions | System.Boolean | Specifies whether debug menu options should be marked with a "DEBUG" suffix. By default; false
| displayCurrentMenuAsConsoleTitle | System.Boolean | Specifies whether the current menu's name should be displayed as the console title. By default; true
| shouldHideAndDisplayCursorAutomatically | System.Boolean | Indicates whether the cursor should be automatically hidden and displayed during menu interactions. By default; true
| outputEncoding | System.Text.Encoding | The encoding to be used for console output. If null, the current encoding remains unchanged. By default; null, which if null means it resorts to Encoding.UTF8

---
<a name='T:consoletestproject.Menus.MenuIdAlreadyExistsException'></a>
### consoletestproject.Menus.MenuIdAlreadyExistsException `Type`
#### Summary
Thrown when an menu id for an Menu already exists or when a MenuOption's id already exists in the same menu

---
<a name='M:consoletestproject.Menus.MenuIdAlreadyExistsException.#ctor(System.String)'></a>
### consoletestproject.Menus.MenuIdAlreadyExistsException.#ctor(System.String) `ConstructorMethod`
#### Summary
Thrown when an menu id for an Menu already exists or when a MenuOption's id already exists in the same menu
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| message | System.String | Extra information regarding the exception

---
<a name='T:consoletestproject.Menus.MenuOption'></a>
### consoletestproject.Menus.MenuOption `Type`
#### Summary
Represents a menu option with an ID, text, and a callback action.
#### Remarks
Initializes a new instance of the  class with the specified ID, text, and callback action.

---
<a name='M:consoletestproject.Menus.MenuOption.#ctor(System.Int32,System.String,System.Action{consoletestproject.Menus.MenuOption},System.Nullable{System.Int32},System.Boolean,System.Boolean,consoletestproject.Menus.Menu)'></a>
### consoletestproject.Menus.MenuOption.#ctor(System.Int32,System.String,System.Action{consoletestproject.Menus.MenuOption},System.Nullable{System.Int32},System.Boolean,System.Boolean,consoletestproject.Menus.Menu) `ConstructorMethod`
#### Summary
Represents a menu option with an ID, text, and a callback action.
#### Remarks
Initializes a new instance of the  class with the specified ID, text, and callback action.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier of the menu option.
| text | System.String | The text displayed for the menu option. Defaults to "Option {id}" if not provided.
| callback | System.Action{consoletestproject.Menus.MenuOption} | The callback action associated with the menu option.
| submenuId | System.Nullable{System.Int32} | The identifier of a submenu associated with this option. If provided, this indicates that selecting this option should also show the menu associated with the submenuId. Defaults to null.
| isDebug | System.Boolean | Indicates whether this is a debug option.
| isDisabled | System.Boolean | Indicates whether the option is disabled and it's callback can be executed
| parent | consoletestproject.Menus.Menu | 

---
<a name='F:consoletestproject.Menus.MenuOption.id'></a>
### consoletestproject.Menus.MenuOption.id `Field`
#### Summary
The unique identifier of the menu option

---
<a name='F:consoletestproject.Menus.MenuOption.isDebug'></a>
### consoletestproject.Menus.MenuOption.isDebug `Field`
#### Summary
Indicates whether this is a debug option.

---
<a name='F:consoletestproject.Menus.MenuOption.isDisabled'></a>
### consoletestproject.Menus.MenuOption.isDisabled `Field`
#### Summary
Indicates whether the option is disabled and it's callback can be executed

---
<a name='F:consoletestproject.Menus.MenuOption.parent'></a>
### consoletestproject.Menus.MenuOption.parent `Field`
#### Summary
Gets or sets the parent menu to which this option belongs. 
            This property is automatically updated by the  class 
            when the menu option is added to a menu. By default, this property is set to null.

---
<a name='F:consoletestproject.Menus.MenuOption.submenuId'></a>
### consoletestproject.Menus.MenuOption.submenuId `Field`
#### Summary
The identifier of a submenu associated with this option.

---
<a name='F:consoletestproject.Menus.MenuOption.callback'></a>
### consoletestproject.Menus.MenuOption.callback `Field`
#### Summary
The callback action associated with the menu option. 
            The callback is triggered when  is invoked., your callback will be called with an instance of the MenuOption

---
<a name='F:consoletestproject.Menus.MenuOption._text'></a>
### consoletestproject.Menus.MenuOption._text `Field`
#### Summary
Backing field to avoid recursion in the text property.

---
<a name='F:consoletestproject.Menus.MenuOption.textDecoration'></a>
### consoletestproject.Menus.MenuOption.textDecoration `Field`
#### Summary
The decoration prefix text that is prepended to the menu option's displayed text.
#### Remarks
This decoration prefix is added directly to the beginning of the menu option's text when it is displayed.
            It can be set using  to customize the appearance of the menu option dynamically.

---
<a name='P:consoletestproject.Menus.MenuOption.text'></a>
### consoletestproject.Menus.MenuOption.text `Property`
#### Summary
The text displayed for the menu option. Defaults to "Option {id}" if not provided in the constructor or SetText function

---
<a name='M:consoletestproject.Menus.MenuOption.Execute(System.Boolean)'></a>
### consoletestproject.Menus.MenuOption.Execute(System.Boolean) `Method`
#### Summary
Executes the callback Action associated with this menu option.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| shouldShowSubMenu | System.Boolean | Indicates whether to show the menu associated with the submenuId.
#### Returns
true if the callback was executed; false if no callback is defined.

---
<a name='M:consoletestproject.Menus.MenuOption.GetText(System.Boolean)'></a>
### consoletestproject.Menus.MenuOption.GetText(System.Boolean) `Method`
#### Summary
Retrieves the text of the menu option with optional decoration.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| raw | System.Boolean | If true, returns the raw text without decoration
#### Returns
The formatted or raw text of the menu option.

---
<a name='M:consoletestproject.Menus.MenuOption.SetText(System.String,System.Boolean)'></a>
### consoletestproject.Menus.MenuOption.SetText(System.String,System.Boolean) `Method`
#### Summary
Sets the text of the menu option.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The new text of the menu option. Defaults to "Option {id}" if not provided.
| raw | System.Boolean | If true, sets the text without decoration / or ansi styling.

---
<a name='M:consoletestproject.Menus.MenuOption.SetTextDecoration(System.String)'></a>
### consoletestproject.Menus.MenuOption.SetTextDecoration(System.String) `Method`
#### Summary
Sets a decoration prefix for the text displayed by this menu option.
#### Remarks
This method allows customizing the appearance of the menu option's text by adding a prefix with AnsiStyling for example.
            The prefix is applied immediately to the menu option's text and can be reset using .
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| text | System.String | The prefix text to prepend to the menu option's text.

---
<a name='T:consoletestproject.Menus.MenuService'></a>
### consoletestproject.Menus.MenuService `Type`
#### Summary
Represents a service for managing menu and menu interaction.

---
<a name='F:consoletestproject.Menus.MenuService.currentMenu'></a>
### consoletestproject.Menus.MenuService.currentMenu `Field` `public static Menu?`
#### Summary
Represents the current menu being displayed / visited.

---
<a name='F:consoletestproject.Menus.MenuService.menuHistory'></a>
### consoletestproject.Menus.MenuService.menuHistory `Field` `public static List<Menu>`
#### Summary
Keeps track of the history of menus that have been displayed / visited.

---
<a name='F:consoletestproject.Menus.MenuService.menus'></a>
### consoletestproject.Menus.MenuService.menus `Field` `public static List<Menu>`
#### Summary
The list of menus managed by the service, this variable is automatically updated everytime a new menu is created

---
<a name='F:consoletestproject.Menus.MenuService._selectedMenuOptionIndex'></a>
### consoletestproject.Menus.MenuService._selectedMenuOptionIndex `Field` `public static int`
#### Summary
Backing field to avoid recursion in the selectedMenuOptionIndex property. 
            See

---
<a name='P:consoletestproject.Menus.MenuService.selectedMenuOptionIndex'></a>
### consoletestproject.Menus.MenuService.selectedMenuOptionIndex `Property` `public static int`
#### Summary
Gets or sets the index of the currently selected menu option.
#### Remarks
This property manages the index of the currently selected menu option within the .
            When the index is set, it updates the internal state and triggers actions associated  with the selected menu option index.

---
<a name='M:consoletestproject.Menus.MenuService.AddMenus(consoletestproject.Menus.Menu[])'></a>
### consoletestproject.Menus.MenuService.AddMenus(consoletestproject.Menus.Menu[]) `Method` `static public void`
#### Summary
Adds one or more menus to the service. However, there is no need to use this method directly as the list is automatically managed every time you create a new menu.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| menuOptions | consoletestproject.Menus.Menu[] | The menus to be added.

---
<a name='M:consoletestproject.Menus.MenuService.Clear'></a>
### consoletestproject.Menus.MenuService.Clear `Method` `static public void`
#### Summary
Clears all menus from the service, resetting the list to an empty state.

---
<a name='M:consoletestproject.Menus.MenuService.GetMenuById(System.Int32)'></a>
### consoletestproject.Menus.MenuService.GetMenuById(System.Int32) `Method` `static public Menu?`
#### Summary
Retrieves a menu by its unique identifier.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier of the menu.
#### Returns
The menu with the specified ID, or null if not found.

---
<a name='M:consoletestproject.Menus.MenuService.GetMenuByName(System.String)'></a>
### consoletestproject.Menus.MenuService.GetMenuByName(System.String) `Method` `static public Menu?`
#### Summary
Retrieves the first menu found with a specific name.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.String | The name of the menu to retrieve.
#### Returns
The first menu with the specified name, or null if none is found.

---
<a name='M:consoletestproject.Menus.MenuService.GetMenuHistory'></a>
### consoletestproject.Menus.MenuService.GetMenuHistory `Method` `static public List<Menu>`
#### Summary
Retrieves the entire menu history.
#### Returns
The list of menus displayed / visited.

---
<a name='M:consoletestproject.Menus.MenuService.GetMenus'></a>
### consoletestproject.Menus.MenuService.GetMenus `Method` `static public List<Menu>`
#### Summary
Retrieves all menus managed by the service.
#### Returns
The list of menus.

---
<a name='M:consoletestproject.Menus.MenuService.GetMenusByName(System.String)'></a>
### consoletestproject.Menus.MenuService.GetMenusByName(System.String) `Method` `static public List<Menu>?`
#### Summary
Retrieves all menus with a specific name.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.String | The name of the menus to retrieve.
#### Returns
The list of menus with the specified name, or null if none are found.

---
<a name='M:consoletestproject.Menus.MenuService.GetPreviousMenuFromHistory'></a>
### consoletestproject.Menus.MenuService.GetPreviousMenuFromHistory `Method` `public static Menu?`
#### Summary
Retrieves the previous menu from the history of menus displayed / visited, it will keep going back in history till it finds the previous menu
#### Returns
The previous menu from the history, or null if there's no previous menu.

---
<a name='M:consoletestproject.Menus.MenuService.GetUniqueMenuId'></a>
### consoletestproject.Menus.MenuService.GetUniqueMenuId `Method` `public static int`
#### Summary
Generates a unique menu ID that is not already in use by any existing menu. 
            The unique id is also offsetted by 1337 to avoid future id conflicts.
#### Returns
A unique menu ID.

---
<a name='M:consoletestproject.Menus.MenuService.HandleMenuKeyboardInput(System.Nullable{System.ConsoleKey})'></a>
### consoletestproject.Menus.MenuService.HandleMenuKeyboardInput(System.Nullable{System.ConsoleKey}) `Method` `public static void`
#### Summary
Handles user input for menu navigation and option selection based on keyboard arrow keys (Up, Down) and Enter key.
#### Remarks
This method listens for specific keystrokes from the user and adjusts the selected menu option index accordingly: 
            - UpArrow/NumpadUp: Moves selection upwards in the menu options list. If already at the top, wraps around to the bottom. 
            - DownArrow/NumpadDown: Moves selection downwards in the menu options list. If already at the bottom, wraps around to the top. 
            - Enter/RightArrow/NumpadRight: Executes the action associated with the currently selected menu option.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| keyPressed | System.Nullable{System.ConsoleKey} | If null the function calls ConsoleInput.GetKey() themselves, if not null the function will use this parameter

---
<a name='M:consoletestproject.Menus.MenuService.RemoveById(System.Int32)'></a>
### consoletestproject.Menus.MenuService.RemoveById(System.Int32) `Method` `static public bool`
#### Summary
Removes a menu from the service based on its unique identifier.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier of the menu to remove.

---
<a name='M:consoletestproject.Menus.MenuService.SetCurrentMenu(consoletestproject.Menus.Menu)'></a>
### consoletestproject.Menus.MenuService.SetCurrentMenu(consoletestproject.Menus.Menu) `Method` `public static void`
#### Summary
Sets the current menu to the specified menu and adds it to the menu history.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| menu | consoletestproject.Menus.Menu | The menu to set as the current menu.

---
<a name='M:consoletestproject.Menus.MenuService.SetMenuOptionSelected(System.Int32)'></a>
### consoletestproject.Menus.MenuService.SetMenuOptionSelected(System.Int32) `Method` `static public void`
#### Summary
Sets the specified menu option as selected and updates the display accordingly.
#### Remarks
This method checks if there is a current menu set in .
            If the current menu exists and contains valid menu options at the specified index,
            it sets the specified menu option to appear as selected (typically underlined) and refreshes the console display
            to reflect the updated selection.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| index | System.Int32 | The zero-based index of the menu option to select.

---
<a name='M:consoletestproject.Menus.MenuService.ShowById(System.Int32)'></a>
### consoletestproject.Menus.MenuService.ShowById(System.Int32) `Method` `static public void`
#### Summary
Displays the menu with the specified unique identifier on the console
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| id | System.Int32 | The unique identifier of the menu to be displayed.

---
<a name='M:consoletestproject.Menus.MenuService.ExecuteSelectedMenuOption'></a>
### consoletestproject.Menus.MenuService.ExecuteSelectedMenuOption `Method` `private static void`
#### Summary
Executes the action associated with the currently selected menu option.

---
<a name='M:consoletestproject.Menus.MenuService.IsMenuOptionSelectable(System.Int32)'></a>
### consoletestproject.Menus.MenuService.IsMenuOptionSelectable(System.Int32) `Method` `public static bool`
#### Summary
Checks if the specified menu option index is valid and not disabled.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| index | System.Int32 | The index of the menu option to check.
#### Returns
true if the menu option index is valid and not disabled; otherwise, false.

---
<a name='M:consoletestproject.Menus.MenuService.MoveMenuSelectionDown'></a>
### consoletestproject.Menus.MenuService.MoveMenuSelectionDown `Method` `private static void`
#### Summary
Moves the menu selection downwards in the menu options list.
            If already at the bottom, wraps around to the top.
            Skips disabled menu options.

---
<a name='M:consoletestproject.Menus.MenuService.MoveMenuSelectionUp'></a>
### consoletestproject.Menus.MenuService.MoveMenuSelectionUp `Method` `private static void`
#### Summary
Moves the menu selection upwards in the menu options list.
            If already at the top, wraps around to the bottom.
            Skips disabled menu options.

---
