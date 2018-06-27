using UnityEngine;

public class InputHandler : MonoBehaviour {

    Player player;
    float mouseSensitivity = 10f;

	void Start () {
       player = State.players.Find(p => p.currentPlayer);
	}
	
	void Update () {
        player.inputX = Input.GetAxisRaw("Horizontal");
        player.inputZ = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(1)) {
            player.rotation = player.rotation + (Input.GetAxis("Mouse X") * mouseSensitivity);
        }
	}
}
