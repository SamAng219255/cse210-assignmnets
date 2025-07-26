class Video {
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length) {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment) {
        _comments.Add(comment);
    }

    public int GetCommentsCount() {
        return _comments.Count();
    }

    public List<Comment> GetComments() {
        return _comments;
    }

    public string GetDisplay() {
        int commentsCount = GetCommentsCount();
        string displayString = $"Title: {_title}\nAuthor: {_author}\nLength: {_length}\n{commentsCount} Comments:";
        foreach(Comment comment in _comments) {
            displayString += "\n\t" + comment.GetDisplay();
        }
        return displayString;
    }

}