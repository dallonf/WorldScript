using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform Player;
	public int Zoom = 10;
	public float LerpSpeed = 0.1f;
	
	void LateUpdate() {
		transform.position = Vector3.Lerp(transform.position, Player.position + new Vector3(0, 0, -Zoom), LerpSpeed);
		transform.LookAt(Player);
	}
}
