using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	
	public float Speed;
	public float JumpVelocity;
	
	private CharacterController characterController;
	
	void Start() {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		float xSpeed = Input.GetAxis("Horizontal");
		Vector3 velocity = characterController.velocity;
		velocity.x = xSpeed * Speed;
		velocity.z = 0;
		
		velocity += Physics.gravity * Time.deltaTime;
		
		if (Input.GetButtonDown("Jump") && characterController.isGrounded) {
			velocity.y = JumpVelocity;
		}
		
		characterController.Move(velocity * Time.deltaTime);
		
	}
}
