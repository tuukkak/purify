using UnityEngine;

public class SpellBehaviour : MonoBehaviour {

    public GameObject Target;
    public Spell Spell;
	
	void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Spell.Speed * Time.fixedDeltaTime);
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject == Target) {
            Destroy(gameObject);
        }
    }
}
