using System.Collections.Generic;

public class Foe
{
    private FoeBase _foeBase;
    private int _level;

    public Foe(FoeBase fBase, int level)
    {
        _foeBase = fBase;
        _level = level;
    }

    public List<Question> Questions { get; set; }
    
}