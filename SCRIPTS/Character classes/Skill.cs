public class Skill : ModifiedStat
{
    private bool _known;

    public Skill()
    {
        _known = false;
        ExpToLevel = 25;
        LevelModifier = 1.1f;
    }
    public bool Known
    {
        get { return _known; }
        set { _known = value; }
    }
}
public enum SkillName
{ 
    Basic,      // LMB 
    Enhanced,   // RMB
    Greater,    // Q
    Buff,       // W
    Mobility,   // E 
    Aura        // R
    /*
    Melee_Offence,
    Melee_Defence,
    Ranged_Offence,
    Ranged_Defence,
    Magic_Offence,
    Magic_Defence,
    */
}
