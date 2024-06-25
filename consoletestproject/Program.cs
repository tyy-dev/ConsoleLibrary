using System.Text;
using consoletestproject.Coloureds;
using consoletestproject.ConsoleHelper;
using consoletestproject.Extensions;
using consoletestproject.Menus;
namespace consoletestproject
{
    internal class Program
    {
        private static void Main() {
            // todo MenuConfig.cs: display current selected menu option

            MenuConfig.Configurate(outputEncoding: Encoding.Unicode);

            Menu mainMenu = new(0, "Main Menu", [
                new(1, "Display radio buttton exmapleq".Superscript(), (MenuOption context) => {
                    ConsoleInput.GetListBoxSelection("Select a colour", ["red", "green", "blue", "very blue"], (MenuOption optionContext, string option, int index) => {
                        ConsoleInput.GetKey($"Selected {option} [{index}]\nPress any key to continue...");
                    }, parentToShowAfterExecute: context?.parent, shouldRemoveMenuAfterExecute: true);
                }, isDebug: true),
                new(2, "Display Ansi", (MenuOption context) => {
                    "[STYLE Bold]Bold[RESET], [STYLE Italic]Italic[RESET], [STYLE Underline]Underline[RESET]".Format().WriteLine();
                    "[STYLE DoubleUnderline]DoubleUnderline[RESET], [STYLE Overline]Overline[RESET], [STYLE Strikethrough]Strikethrough[RESET]".Format().WriteLine();
                    "[STYLE Invert]Inverted[RESET], Invisible Text -> [STYLE Concealed]text[RESET]".Format().WriteLine();
                    "[STYLE Blink]Blinking[RESET], [STYLE Underline][COLOUR 255,0,0]Multiple Styles[RESET]".Format().WriteLine();
                    "[COLOUR 255,0,0]Red[RESET], [COLOUR 0,255,0]Green[RESET], [COLOUR 0,0,255]Blue[RESET]".Format().WriteLine();
                    "[STYLE 3]Style by index[RESET], [BGCOLOUR 125,255,0]Background colour[RESET]".Format().WriteLine();
                    Console.WriteLine("{0}Green {1}Red {2}using manual formatting{3}",
                        Ansi.Text.Coloured(new(0, 255, 0)),
                        Ansi.Text.Coloured(new(255, 0, 0)),
                        Ansi.Text.Coloured(new(255, 255, 0), foreground: false),
                        Ansi.Text.Reset());

                    "Calculator Hyperlink. Click me".HyperLink(link: "calculator://", coloured: true).WriteLine();
                    "".HyperLink(link: "https://google.com", coloured: true).WriteLine();

                    List<Colour> gradient = Colour.Gradient([
                        new(255, 0, 0), // Red
                        new(0, 255, 0), // Green
                        new(0, 0, 255) // Blue
                    ]);

                    Console.WriteLine("Gradient".Gradient(gradient));

                    gradient = Colour.Gradient([
                        new(128, 0, 128), // Purple
                        new(0, 128, 0), // Green
                        new(255, 255, 0), // Yellow
                        new(255, 0, 0) // Red
                    ]);
                   Console.WriteLine("White text on an gradient coloured background".Gradient(gradient, foreground: false).Coloured(new(255, 255, 255)));
                   for (int i = 0; i < 120; i++)
                        $"[{i}]{Ansi.Text.SelectGraphicRendition((byte)i)}AA[RESET] ".Format().Write();

                }, isDebug: true),
                new(3, "Go to sub menu by name",  (MenuOption context) => {
                    MenuService.GetMenuByName("Sub Menu")?.Show();
                }, isDisabled: true),
                new(4, "Set option enabled/disabled", (MenuOption context) => {
                    bool? value = ConsoleInput.GetAsBool("Do you want to disable the option above?? [Y/N]");
                    if (value is bool val) {
                        int? indexOfDisabledOption = context.parent?.MenuOptionIdToIndex(3);
                        if (indexOfDisabledOption != null)
                            context.parent?.SetOptionDisabled(indexOfDisabledOption.Value, val);
                        Console.Clear();
                        context.parent?.Show();
                    }
                })
            ]);

            Menu subMenu = new(1, "Sub Menu", [
                new(1, "Counter: 1", (MenuOption context) => {
                    int counterNum = int.Parse(context.GetText(raw: true).Split("Counter: ")[1]);
                    context.SetText($"Counter: {++counterNum}", raw: true);

                    MenuService.currentMenu?.Show();
                }),
                new(2, "Increment counter by x", (MenuOption context) => {
                    // Get the "Counter X" MenuOption by it's id (1)
                    MenuOption counterOption = MenuService.currentMenu?.GetMenuOptionById(1)!;

                    int counterNum = int.Parse(counterOption.GetText(raw: true)!.Split("Counter: ")[1]);
                    int? input = ConsoleInput.GetAsInt("Input Increment");
                    if (input != null)
                        counterNum += input.Value;
                    counterOption.SetText($"Counter: {counterNum}", raw: true);

                    MenuService.currentMenu?.Show();
                }),
            ]);
            Console.SetWindowSize(90, 20);

            subMenu.AddBackOption();
            subMenu.AddExitOption();
            mainMenu.Show();

            while (true) MenuService.HandleMenuKeyboardInput();
        }
    }
}