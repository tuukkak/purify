using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
	void Start () {
        initializePlayers();
        spawnPlayers();
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
        foreach(Player p in State.players) {
            Debug.Log(p.name);
        }
    }
}
