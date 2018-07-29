using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    float MouseSensitivity = 10f;
    sbyte LastInputX;
    sbyte LastInputZ;
    Movement Movement = State.CurrentPlayer.Movement;
    Hero Hero = State.CurrentPlayer.Hero;
    List<KeyCode> ActionKeys = new List<KeyCode>() { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Q, KeyCode.E };

    void Update() {
        UpdateMovement();
        UpdateTarget();
        UpdateCasts();
	}

    void UpdateMovement() {
        Movement.InputX = (sbyte)Input.GetAxisRaw("Horizontal");
        Movement.InputZ = (sbyte)Input.GetAxisRaw("Vertical");

        if (Movement.InputX != LastInputX || Movement.InputZ != LastInputZ) {
            Network.UpdateMovement();
        }

        LastInputX = Movement.InputX;
        LastInputZ = Movement.InputZ;

        if (Input.GetMouseButton(1)) {
            Movement.Rotation = CalculateRotation();
        }
    }

    float CalculateRotation() {
        float Rotation = Movement.Rotation + (Input.GetAxis("Mouse X") * MouseSensitivity);
        Rotation = (float)Math.Round(Rotation, 3);
        while (Rotation < 0) Rotation += 360f;
        while (Rotation > 360) Rotation -= 360f;
        return Rotation;
    }

    void UpdateTarget() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Player") {
                State.CurrentPlayer.Target = hit.transform.gameObject.GetComponent<PlayerController>().Player;
                return;
            }

            State.CurrentPlayer.Target = null;
        }
    }

    void UpdateCasts() {
        foreach(KeyCode key in ActionKeys) {
            if (Input.GetKeyDown(key)) {
                Spell Spell = State.spells.FindAll(s => s.HeroId == State.CurrentPlayer.Hero.Id).Find(s => s.KeyCode == key.ToString());
                if (InRange(caster: State.CurrentPlayer, target: State.CurrentPlayer.Target, spell: Spell)) {
                    State.SpellActions.Add(new SpellAction(
                        type: SpellAction.ActionType.Finish,
                        caster: State.CurrentPlayer,
                        target: State.CurrentPlayer.Target,
                        spell: Spell
                    ));
                }
            }
        }
    }

    bool InRange(Player caster, Player target, Spell spell) {
        return Vector3.Distance(caster.GameObject.transform.position, target.GameObject.transform.position) < spell.Range;
    }
}
