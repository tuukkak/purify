using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour {

    public GameObject[] SpellPrefabs;
	
	void Update() {
        foreach(SpellAction action in State.SpellActions) {
            if (action.Type == SpellAction.ActionType.Finish) {
                FinishCast(caster: action.Caster, target: action.Target, spell: action.Spell);
            }
        }

        State.SpellActions.Clear();
	}

    void FinishCast(Player caster, Player target, Spell spell) {
        SpellBehaviour Spell = Instantiate(SpellPrefabs[spell.SpellPrefabIndex], caster.GameObject.transform.position, Quaternion.Euler(0, 0, 0)).GetComponent<SpellBehaviour>();
        Spell.Target = target.GameObject;
        Spell.Spell = spell;
    }
}
