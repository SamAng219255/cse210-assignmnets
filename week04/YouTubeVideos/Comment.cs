class Comment {
    private string _commenterName;
    private string _commentText;

    public Comment(string name, string text) {
        _commenterName = name;
        _commentText = text;
    }

    public string GetDisplay() {
        return $"{_commenterName}: {_commentText}";
    }
}