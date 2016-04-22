using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	public float speed = 1.0f;
	public float brakingFactor = 0.5f;

	// Use this for initialization
	void Start () {
		Vector3 test = new Vector3 (1.124124f, 121.421f, 124.124315135f);
		print (test);
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Rigidbody body = gameObject.GetComponent<Rigidbody> ();
		Transform trans = gameObject.GetComponent<Transform> ();
		if (Input.GetAxis ("Horizontal") != 0) {
			print ("Horizontal: " + Input.GetAxis ("Horizontal").ToString ());
			trans.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * 20 * Time.fixedDeltaTime * Mathf.Max (1.0f, Mathf.Log (body.velocity.magnitude + 5)), 0));

		}
		if (Input.GetAxis ("Vertical") != 0) {
			print ("Vertical: " + Input.GetAxis ("Vertical").ToString ());
			body.velocity += 10 * (1 + Input.GetAxis ("Vertical")) * trans.forward * Time.fixedDeltaTime;
		}


		if (Input.GetAxis ("Fire1") != 0) {
			print ("Yes");
			print ("Fire1: " + Input.GetAxis ("Fire1").ToString ());
		}
		if (Input.GetAxis ("Fire2") != 0) {
			print ("Yes");
			print ("Fire2: " + Input.GetAxis ("Fire2").ToString ());
		}
		if (Input.GetAxis ("Fire3") != 0) {
			print ("Yes");
			print ("Fire3: " + Input.GetAxis ("Fire3").ToString ());
		}
		if (Input.GetAxis ("Jump") != 0) {
			print ("Yes");
			print ("Jump: " + Input.GetAxis ("Jump").ToString ());
		}
		if (Input.GetAxis ("Submit") != 0) {
			print ("Yes");
			print ("Submit: " + Input.GetAxis ("Submit").ToString ());
		}

		if (Input.GetAxis ("Cancel") != 0) {
			print ("Yes");
			print ("Cancel: " + Input.GetAxis ("Cancel").ToString ());
		}
		if (Input.GetKey (KeyCode.W)) {
			body.velocity += speed * trans.forward * Time.fixedDeltaTime;
		} else {
			if (!Input.GetKey (KeyCode.S) && Mathf.Abs( Input.GetAxis("Vertical")) < .05 && body.velocity.magnitude < 1) {
				body.velocity = trans.forward.normalized;
			}
		}
		if (Input.GetKey (KeyCode.S))
			body.velocity -= speed * trans.forward * Time.fixedDeltaTime;
		if (Input.GetKey (KeyCode.A))
			trans.Rotate(new Vector3(0, -speed * Time.fixedDeltaTime * Mathf.Max (1.0f, Mathf.Log(body.velocity.magnitude + 5)), 0));
		if (Input.GetKey (KeyCode.D))
			trans.Rotate(new Vector3(0, speed * Time.fixedDeltaTime * Mathf.Max (1.0f, Mathf.Log(body.velocity.magnitude + 5)),0));
		if (Input.GetKey (KeyCode.Space))
			body.velocity *= 1 - brakingFactor * Time.fixedDeltaTime;
		if (Input.GetKeyUp (KeyCode.F))
			trans.Rotate (trans.forward * 90);
	}
}
