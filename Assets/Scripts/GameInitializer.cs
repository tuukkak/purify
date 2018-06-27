using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

    public GameObject magePrefab;
    public GameObject cameraPrefab;

	void Start () {
        initializePlayers();
        spawnPlayers();
        gameObject.AddComponent<InputHandler>();
	}
	
	void Update () {
		
	}

    void initializePlayers() {
        newPlayer(1, "player 1", true);
        newPlayer(2, "player 2", false);
        newPlayer(3, "player 3", false);
        newPlayer(4, "player 4", false);
    }

    void newPlayer(int id, string name, bool currentPlayer) {
        Player player = new Player();
        player.id = id;
        player.name = name;
        player.currentPlayer = currentPlayer;
        State.players.Add(player);
    }

    void spawnPlayers() {
        foreach(var player in State.players) {
            GameObject playerObject = Instantiate(magePrefab);
            playerObject.GetComponent<PlayerController>().player = player;

            if (player.currentPlayer) {
                GameObject cameraObject = Instantiate(cameraPrefab, playerObject.transform);
            }
        }
    }
}
