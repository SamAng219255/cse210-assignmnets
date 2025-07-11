class Entry {
    private string _date;
    private string _prompt;
    private string _entryText;

    public void Populate(string date, string prompt, string entryText) {
        _date = date;
        _prompt = prompt;
        _entryText = entryText;
    }

    public void Display() {
        Console.WriteLine($"Date: {_date} — Prompt: {_prompt}");
        Console.WriteLine(_entryText);
        Console.WriteLine("");
    }

    public string GetPrompt() {
        return _prompt;
    }

    public string GetDate() {
        return _date;
    }

    public string GetEntryText() {
        return _entryText;
    }
}