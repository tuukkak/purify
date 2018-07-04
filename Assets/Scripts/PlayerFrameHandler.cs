using UnityEngine;

public class PlayerFrameHandler : MonoBehaviour {

    public GameObject HealthBarPrefab;

	void Start() {
        GameObject PlayerHealthBar = Instantiate(HealthBarPrefab, transform);
        PlayerHealthBar.transform.GetChild(0).GetComponent<HealthBarHandler>().Player = State.currentPlayer;
	}
}
