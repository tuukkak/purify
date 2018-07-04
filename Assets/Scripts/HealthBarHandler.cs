using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour {

    public Player Player;
	
	void Update() {
        gameObject.GetComponent<Image>().fillAmount = Player.Health / (float)Player.Hero.BaseHealth;
	}
}
