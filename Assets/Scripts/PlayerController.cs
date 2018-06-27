using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Player player;

	void Update () {
        float x = player.inputX * Time.deltaTime * 5f;
        float z = player.inputZ * Time.deltaTime * 5f;
        transform.Translate(Vector3.ClampMagnitude(new Vector3(x, 0, z), Time.deltaTime * 5f));

        transform.rotation = Quaternion.Euler(0, player.rotation, 0);
	}
}
