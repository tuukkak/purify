using UnityEngine;

public class TargetFrameHandler : MonoBehaviour {

    public GameObject HealthBarPrefab;

    GameObject TargetHealthBar;

    void Start() {
        TargetHealthBar = Instantiate(HealthBarPrefab, transform);
    }

    void Update() {
        if (State.currentPlayer.Target == null) {
            TargetHealthBar.SetActive(false);
        } else {
            TargetHealthBar.transform.GetChild(0).GetComponent<HealthBarHandler>().Player = State.currentPlayer.Target;
            TargetHealthBar.SetActive(true);
        }
    }
}
