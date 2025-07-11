using System.IO;
using System.Text.RegularExpressions;

class SaveLoad {
    private Regex _csvColPattern = new Regex("(?:(?<!\")\"([^\"]*(?:\"\"[^\"]*)*)\"(?!\")|([^,]+)|(?<=,|^))(?=,|$)");

    public void Save(string filename, Journal journal) {
        using (StreamWriter saveFile = new StreamWriter(filename)) {
            saveFile.WriteLine("Date,Prompt,Entry");

            List<Entry> entries = journal.GetEntries();
            foreach(Entry entry in entries) {
                string sanitizedDate = entry.GetDate().Replace("\"","\"\"");
                string sanitizedPrompt = entry.GetPrompt().Replace("\"","\"\"");
                string sanitizedEntryText = entry.GetEntryText().Replace("\"","\"\"");
                saveFile.WriteLine($"\"{sanitizedDate}\",\"{sanitizedPrompt}\",\"{sanitizedEntryText}\"");
            }
        }
    }

    public bool Load(string filename, Journal journal) {
        string[] lines = System.IO.File.ReadAllLines(filename);
        bool first = true;
        Match match;
        GroupCollection groups;
        foreach (string line in lines) {
            if(first) {// Verify valid headers on first row and skip the remainder.
                first = false;

                bool headerError = true;
                match = _csvColPattern.Match(line);
                groups = match.Groups;
                if((groups[1].Success && groups[1].Value == "Date") || groups[2].Value == "Date") {
                    match = match.NextMatch();
                    groups = match.Groups;
                    if((groups[1].Success && groups[1].Value == "Prompt") || groups[2].Value == "Prompt") {
                        match = match.NextMatch();
                        groups = match.Groups;
                        if((groups[1].Success && groups[1].Value == "Entry") || groups[2].Value == "Entry") {
                            headerError = false;
                        }
                    }
                }
                if(headerError) {
                    Console.WriteLine("Invalid File. Column headers do not match. Aborting load.");
                    return false;
                }
                continue;
            }
            List<string> columns = new List<string>();
            match = _csvColPattern.Match(line);
            while(match.Success) {
                groups = match.Groups;
                if(groups[1].Success) {
                    columns.Add(groups[1].Value.Replace("\"\"","\""));
                }
                else {
                    columns.Add(groups[2].Value);
                }
                match = match.NextMatch();
            }
            if(columns.Count < 3) {
                Console.WriteLine("Invalid Entry Row. Too few columns. Skipping Row.");
                continue;
            }
            else {
                Entry newEntry = new Entry();
                newEntry.Populate(columns[0], columns[1], columns[2]);
                journal.AddEntry(newEntry);
            }
        }
        return true;
    }
}