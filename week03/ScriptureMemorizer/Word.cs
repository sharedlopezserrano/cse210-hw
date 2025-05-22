// This class represents one word and hides it when needed
public class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
    public override string ToString()
    {
        return _isHidden ? new string('_', _word.Length) : _word;
    }
}
