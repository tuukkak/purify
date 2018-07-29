using UnityEngine;

public class UnitFramesHandler : MonoBehaviour {

    GameObject TargetHealthBar;

	void Start() {
        InitializePlayerFrame();
        InitializeTargetFrame();
	}

    void InitializePlayerFrame() {
        transform.Find("PlayerFrame").GetChild(0).GetChild(0).GetComponent<HealthBarHandler>().Player = State.CurrentPlayer;
    }

    void InitializeTargetFrame() {
        TargetHealthBar = transform.Find("TargetFrame").GetChild(0).gameObject;
    }
	
	void Update() {
        UpdateTargetFrame();
	}

    void UpdateTargetFrame() {
        if (State.CurrentPlayer.Target == null) {
            TargetHealthBar.SetActive(false);
        } else {
            TargetHealthBar.transform.GetChild(0).GetComponent<HealthBarHandler>().Player = State.CurrentPlayer.Target;
            TargetHealthBar.SetActive(true);
        }
    }
}
