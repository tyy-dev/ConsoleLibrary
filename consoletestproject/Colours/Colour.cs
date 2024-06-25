namespace consoletestproject.Coloureds
{
    /// <summary>
    /// Represents a color with RGB components.
    /// </summary>
    public class Colour
    {
        /// <summary>
        /// The red component of the color (0-255).
        /// </summary>
        /// <typeinfo>public byte</typeinfo>
        public byte r = 0;

        /// <summary>
        /// The green component of the color (0-255).
        /// </summary>
        /// <typeinfo>public byte</typeinfo>
        public byte g = 0;

        /// <summary>
        /// The blue component of the color (0-255).
        /// </summary>
        /// <typeinfo>public byte</typeinfo>
        public byte b = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class
        /// with the specified hexadecimal color string.
        /// </summary>
        /// <param name="hexColour">The hexadecimal color string (e.g., "#RRGGBB").</param>
        /// <typeinfo>public</typeinfo>
        public Colour(string hexColour) {
            Colour.HexToRgb(hexColour, out byte r, out byte g, out byte b);
            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class
        /// with the specified RGB components.
        /// </summary>
        /// <param name="r">The red component of the color (0-255).</param>
        /// <param name="g">The green component of the color (0-255).</param>
        /// <param name="b">The blue component of the color (0-255).</param>
        /// <typeinfo>public</typeinfo>
        public Colour(byte r, byte g, byte b) {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <typeinfo>public</typeinfo>
        public Colour() { }

        /// <summary>
        /// Converts the current RGB Colour values to a hexadecimal Colour code.
        /// </summary>
        /// <returns>A string representing the hexadecimal Colour code.</returns>
        /// <typeinfo>public string</typeinfo>
        public string ToHex() => Colour.RgbToHex(this.r, this.g, this.b);

        /// <summary>
        /// Converts a hexadecimal Colour code to its corresponding RGB representation.
        /// </summary>
        /// <param name="hexColour">The hexadecimal Colour code to convert.</param>
        /// <param name="r">When this method returns, contains the red component of the RGB representation of the Colour, as a byte.</param>
        /// <param name="g">When this method returns, contains the green component of the RGB representation of the Colour, as a byte.</param>
        /// <param name="b">When this method returns, contains the blue component of the RGB representation of the Colour, as a byte.</param>
        /// <exception cref="ArgumentException">Thrown when the input hex Colour string is not in the correct format (#RRGGBB).</exception>
        /// <typeinfo>public static void</typeinfo>
        public static void HexToRgb(string hexColour, out byte r, out byte g, out byte b) {
            if (hexColour.StartsWith('#')) // Get if the first character is, startsWith
                hexColour = hexColour[1..]; // Remove the first character, slice

            if (hexColour.Length != 6)
                throw new ArgumentException("Invalid hex Colour string. It should be in the format #RRGGBB or RRGGBB", nameof(hexColour));

            r = Convert.ToByte(hexColour[..2], 16);
            g = Convert.ToByte(hexColour[2..4], 16);
            b = Convert.ToByte(hexColour[4..6], 16);
        }

        /// <summary>
        /// Converts RGB values to a hexadecimal Colour code.
        /// </summary>
        /// <param name="r">The red component of the Colour, as a byte.</param>
        /// <param name="g">The green component of the Colour, as a byte.</param>
        /// <param name="b">The blue component of the Colour, as a byte.</param>
        /// <returns>The hexadecimal Colour code as a string.</returns>
        /// <typeinfo>public static string</typeinfo>
        public static string RgbToHex(byte r, byte g, byte b) {
            return $"#{r:X2}{g:X2}{b:X2}";
        }

        /// <summary>
        /// Generates a gradient between given colours.
        /// </summary>
        /// <param name="colours">The list of colours to interpolate between.</param>
        /// <param name="granularity">The number of steps in the gradient. Default is 12.</param>
        /// <returns>The list of colours representing the gradient.</returns>
        /// <typeinfo>public static List&lt;Colour></typeinfo>
        public static List<Colour> Gradient(List<Colour> colours, int granularity = 12) {
            if (colours.Count <= 1 || granularity <= 0) return colours;

            List<Colour> gradientColours = [];

            for (int i = 0; i < colours.Count - 1; i++) {
                Colour.InterpolateColors(colours[i], colours[i + 1], granularity, gradientColours);
            }

            gradientColours.Add(colours[^1]);

            return gradientColours;
        }

        /// <summary>
        /// Interpolates between two colours.
        /// </summary>
        /// <param name="start">The starting colour.</param>
        /// <param name="end">The ending colour.</param>
        /// <param name="granularity">The number of steps in the interpolation.</param>
        /// <param name="results">The list to store the interpolated colours.</param>
        /// <typeinfo>private static void</typeinfo>
        private static void InterpolateColors(Colour start, Colour end, int granularity, List<Colour> results) {
            for (int j = 0; j <= granularity; j++) {
                double ratio = (double)j / granularity;
                byte interpolatedR = Interpolate(start.r, end.r, ratio);
                byte interpolatedG = Interpolate(start.g, end.g, ratio);
                byte interpolatedB = Interpolate(start.b, end.b, ratio);
                results.Add(new(interpolatedR, interpolatedG, interpolatedB));
            }
        }

        /// <summary>
        /// Interpolates between two values.
        /// </summary>
        /// <param name="start">The starting value.</param>
        /// <param name="end">The ending value.</param>
        /// <param name="ratio">The interpolation ratio.</param>
        /// <returns>The interpolated value.</returns>
        /// <typeinfo>private static byte</typeinfo>
        private static byte Interpolate(byte start, byte end, double ratio) {
            return (byte)(start * (1 - ratio) + end * ratio);
        }

        /// <summary>
        /// Calculates and returns the complementary color of the current color.
        /// </summary>
        /// <returns>The complementary <see cref="Colour"/> object.</returns>
        /// <typeinfo>public Colour</typeinfo>
        public Colour GetComplementary() {
            return new((byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
        }

        /// <summary>
        /// Parses a color string to create a <see cref="Colour"/> object.
        /// Supports RGB R, G, B and hexadecimal #AABBCC format.
        /// </summary>
        /// <param name="args">The color argument string to parse.</param>
        /// <returns>
        /// A <see cref="Colour"/> object if parsing is successful; otherwise, <c>null</c>.
        /// </returns>
        /// <typeinfo>public static Colour?</typeinfo>
        public static Colour? ParseColour(string args) {
            string[] rgb = args.Split(',').Select(x => x.Trim()).ToArray();

            // Check if the input is in RGB format (three comma-separated values), and then attempt to parse R,G,B values as bytes.
            if (rgb.Length == 3 && byte.TryParse(rgb[0], out byte r) && byte.TryParse(rgb[1], out byte g) && byte.TryParse(rgb[2], out byte b)) {
                return new(r, g, b);  // Create and return a Colour object
            }

            // Check if the input is in hexadecimal format (either #AABBCC or AABBCC)
            else if (rgb.Length == 1 && (rgb[0].Length == 6 || (rgb[0].Length == 7 && rgb[0].StartsWith('#')))) {
                return new(rgb[0]);  // Create and return a Colour object from hexadecimal string
            }

            return null;  // Return null if input doesn't match expected formats
        }
    }
}
