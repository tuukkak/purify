using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Player player;

	void Update () {
		var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5f;
        var z = Input.GetAxisRaw("Vertical") * Time.deltaTime * 5f;

        // transform.Rotate(0, player.rotation, 0);
        transform.Translate(Vector3.ClampMagnitude(new Vector3(x, 0, z), Time.deltaTime * 5f));
	}
}
