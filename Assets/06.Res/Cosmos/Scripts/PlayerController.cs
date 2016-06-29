using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movSpeed = 2;
	public float runSpeed = 4;
	public float rotSpeed = 10;
	public float animSpeed = 1.5f;
	bool running = false;

	private Vector3 movDir;
	public Animator anim;

	void start()
	{
		anim = GetComponentInChildren<Animator>();
	}
	void Update () 
	{
		float speed = Input.GetAxis("Vertical");
		Debug.Log (speed);
		float turn = Input.GetAxis("Horizontal");

		running = Input.GetKey (KeyCode.LeftShift);
		anim.SetBool ("running", running);

		movDir = new Vector3 (0, 0, Input.GetAxisRaw ("Vertical")).normalized;
		transform.Rotate (new Vector3(0, turn*rotSpeed, 0));
//		transform.rotation = new Quaternion (turn, transform.rotation.y, transform.rotation.z, transform.rotation.w);
//		float speed = Input.GetAxis("Vertical");
		anim.SetFloat ("speed", speed);
	}

	void FixedUpdate()
	{
		if(!running)
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + transform.TransformDirection(movDir * movSpeed * Time.deltaTime));
		else 
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + transform.TransformDirection(movDir * runSpeed * Time.deltaTime));
//		float speed = Input.GetAxisRaw("Vertical");
//		Debug.Log (speed);
//		anim.SetFloat ("speed", speed);
//		anim.speed = animSpeed;


	}
}
