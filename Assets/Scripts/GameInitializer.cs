using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

    public GameObject MagePrefab;
    public GameObject CameraPrefab;
    public GameObject UnitFramesPrefab;

	void Start() {
        InitializeHeroes();
        InitializeSpells();
        InitializePlayers();
        SpawnPlayers();
        ShowUnitFrames();
        StartInputHandler();
        Network.Connect();
	}

    void InitializeHeroes() {
        State.heroes = new List<Hero>() {
            new Hero(id: 1, name: "Mage", speed: 5f, baseHealth: 2000)
        };
    }

    void InitializeSpells() {
        State.spells = new List<Spell>() {
            new Spell(id: 1, heroId: 1, name: "Frostbolt", range: 30f, castTime: 1.7f),
            new Spell(id: 2, heroId: 1, name: "Counter Spell", range: 20f)
        };
    }

    void InitializePlayers() {
        State.players = new List<Player>() {
            new Player(id: 1, name: "Player 1", heroId: 1),
            new Player(id: 2, name: "Player 2", heroId: 1),
            new Player(id: 3, name: "Player 3", heroId: 1),
            new Player(id: 4, name: "Player 4", heroId: 1)
        };

        State.currentPlayer = State.players.Find(p => p.Id == 1);
    }

    void SpawnPlayers() {
        foreach(Player Player in State.players) {
            GameObject PlayerObject = Instantiate(MagePrefab);
            PlayerObject.GetComponent<PlayerController>().Player = Player;

            if (Player.Id == State.currentPlayer.Id) {
                Instantiate(CameraPrefab, PlayerObject.transform);
            }
        }
    }

    void ShowUnitFrames() {
        Instantiate(UnitFramesPrefab);
    }

    void StartInputHandler() {
        gameObject.AddComponent<InputHandler>();
    }
}
