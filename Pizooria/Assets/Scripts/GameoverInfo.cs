public class GameoverInfo : IGameoverInfo
{
    public string Label;
    public string Value;
    
    
    public string GetLabel()
    {
        return Label;
    }

    public string GetValue()
    {
        return Value;
    }
}