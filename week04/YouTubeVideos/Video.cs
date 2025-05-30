using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumComments()
    {
        return _comments.Count;
    }

    public string GetDisplayText()
    {
        return $"Title: {_title}\nAuthor: {_author}\nLength: {_length} seconds\nComments ({GetNumComments()}):";
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}
