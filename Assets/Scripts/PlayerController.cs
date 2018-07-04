using UnityEngine;

public class PlayerController : MonoBehaviour {
    
	public Player Player;

	void Update() {
        float x = Player.Movement.InputX * Time.deltaTime * Player.Hero.Speed;
        float z = Player.Movement.InputZ * Time.deltaTime * Player.Hero.Speed;
        transform.Translate(Vector3.ClampMagnitude(new Vector3(x, 0, z), Time.deltaTime * Player.Hero.Speed));

        transform.rotation = Quaternion.Euler(0, Player.Movement.Rotation, 0);
	}
}
