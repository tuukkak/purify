public class Spell {
    public int Id { get; private set; }
    public int HeroId { get; private set; }
    public string Name { get; private set; }
    public float Range { get; private set; }
    public float CastTime { get; private set; }

    public Spell(int id, int heroId, string name, float range, float castTime = 0f) {
        Id = id;
        HeroId = heroId;
        Name = name;
        Range = range;
        CastTime = castTime;
    }
}
