using UnityEngine;

public class InputHandler : MonoBehaviour {

    float MouseSensitivity = 10f;
    Movement Movement;

    void Start() {
        Movement = State.currentPlayer.Movement;
    }

    void Update() {
        UpdateMovement();
        UpdateTarget();
	}

    void UpdateMovement() {
        Movement.InputX = Input.GetAxisRaw("Horizontal");
        Movement.InputZ = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(1)) {
            Movement.Rotation = Movement.Rotation + (Input.GetAxis("Mouse X") * MouseSensitivity);
        }
    }

    void UpdateTarget() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform && hit.transform.gameObject.tag == "Player") {
                    State.currentPlayer.Target = hit.transform.gameObject.GetComponent<PlayerController>().Player;
                    return;
                }
            }

            State.currentPlayer.Target = null;
        }
    }
}
