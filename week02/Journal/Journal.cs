class Journal {
    private List<Entry> _entries = new List<Entry>();

    public void Display() {
        foreach(Entry entry in _entries) {
            entry.Display();
        }
    }

    public void AddEntry(Entry newEntry) {
        _entries.Add(newEntry);
    }

    public List<Entry> GetEntries() {
        return new List<Entry>(_entries);
    }

    public int EntryCount() {
        return _entries.Count;
    }
}