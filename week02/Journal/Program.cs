/*
    My addition to the code, beyond the core requirements, was to add proper .csv formatting and parsing.
    The parsing isn't perfect though. Several, more difficult, potential patterns are not accounted for though these states are unreachable
    when only saving the files though this program. All files created by this program can be parsed by both this program and other programs that
    can read .csv files. Some externally created or modified will be impossible for this program to parse, however.
    I also added a few confirmation screens before the user takes destructive actions and I added an option, when loading a file with other entries
    already in the journal, to either replace the current entries or append the loaded files to the end since I didn't know what the correct action
    should be.
*/

using System;

class Program
{
    private static PromptGenerator _promptGenerator = new PromptGenerator();
    private static Journal _journal = new Journal();
    private static SaveLoad _saveLoad = new SaveLoad();

    static void Main(string[] args) {
        Console.WriteLine("Welcome to my Journal program!");

        bool shouldSave = false;
        bool inMenu = true;
        while(inMenu) {
            Console.WriteLine("Please select one of the following options by entering its number:");
            Console.WriteLine("1. Write an entry.");
            Console.WriteLine("2. Display all entries.");
            Console.WriteLine("3. Load journal from file.");
            Console.WriteLine("4. Save journal to file.");
            Console.WriteLine("5. Exit");
            Console.Write("> ");
            switch(Console.ReadLine()) {
                case "1":
                    WriteEntry();
                    shouldSave = true;
                    break;
                case "2":
                    _journal.Display();
                    break;
                case "3":
                    LoadJournal();
                    break;
                case "4":
                    SaveJournal();
                    shouldSave = false;
                    break;
                case "5":
                    if(shouldSave) {
                        bool decidingSave = true;
                        while(decidingSave) {
                            Console.WriteLine("You have unsaved journal entries. Did you want to save those before you left? (y/n)");
                            Console.Write("> ");
                            switch(Console.ReadLine()) {
                                case "y":
                                    SaveJournal();
                                    decidingSave = false;
                                    break;
                                case "n":
                                    decidingSave = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input!");
                                    break;
                            }
                        }
                    }
                    Console.WriteLine("Goodbye!");
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public static void WriteEntry() {
        Entry newEntry = new Entry();
        string prompt = _promptGenerator.GetPrompt();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        Console.WriteLine($"Date: {dateText}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("> ");

        newEntry.Populate(dateText, prompt, Console.ReadLine());

        _journal.AddEntry(newEntry);
    }

    public static void LoadJournal() {
        Console.Write("Please enter a file name to load from: ");
        string filename = Console.ReadLine();

        if(_journal.EntryCount() > 0) {
            bool deciding = true;
            while(deciding) {
                Console.WriteLine("You already have entries in your journal, do you want to replace them or just addend the file's contents to your existing entries?");
                Console.WriteLine("(Type \"replace\" or \"append\" to make a decision. You can also \"cancel\" loading the file.)");
                Console.Write("> ");
                switch(Console.ReadLine()) {
                    case "replace":
                        _journal = new Journal();
                        if(_saveLoad.Load(filename, _journal)) {
                            Console.WriteLine("Load Successful!");
                        }
                        deciding = false;
                        break;
                    case "append":
                        if(_saveLoad.Load(filename, _journal)) {
                            Console.WriteLine("Load Successful!");
                        }
                        deciding = false;
                        break;
                    case "cancel":
                        Console.WriteLine("Cancelling load. Returning to menu.");
                        deciding = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
        }
        else {
            if(_saveLoad.Load(filename, _journal)) {
                Console.WriteLine("Load Successful!");
            }
        }
    }

    public static void SaveJournal() {
        Console.Write("Please enter a file name to save your journal to: ");
        _saveLoad.Save(Console.ReadLine(), _journal);
        Console.WriteLine("Save Successful!");
    }
}