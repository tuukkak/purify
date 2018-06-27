using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    Player player;

	void Start () {
       player = State.players.Find(p => p.currentPlayer);
	}
	
	void Update () {
        player.inputX = Input.GetAxisRaw("Horizontal");
        player.inputZ = Input.GetAxisRaw("Vertical");
	}
}
