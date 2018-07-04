public class Player {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Hero Hero { get; private set; }
    public Movement Movement { get; private set; }
    public Player Target { get; set; }
    public int Health { get; set; }

    public Player(int id, string name, int heroId) {
        Id = id;
        Name = name;
        Hero = State.heroes.Find(h => h.Id == heroId);
        Movement = new Movement();
        Health = Hero.BaseHealth;
    }
}
