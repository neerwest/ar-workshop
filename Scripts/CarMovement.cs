using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	private Rigidbody rb;
	public float FowardForce = 40f;
	public float BackwardsForce = 20f;
	public float MaxForwardVelocity = 20f;
	public float MaxBackwardsVelocity = 10f;
	public float SteerVelocity = 60f;

	// Use this for initialization
	void Start () {
		this.rb = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.W)) {
			this.rb.AddRelativeForce (Vector3.forward * this.FowardForce);
			Debug.Log (this.rb.velocity);
			if (this.rb.velocity.z > MaxForwardVelocity) {
				this.rb.velocity = new Vector3 (0f, 0f, MaxForwardVelocity); 
			}
		}

		if(Input.GetKey(KeyCode.S)) {
			this.rb.AddRelativeForce (-Vector3.forward * this.BackwardsForce);
			if (this.rb.velocity.z < -this.MaxBackwardsVelocity) {
				this.rb.velocity = new Vector3 (0f, 0f, -this.MaxBackwardsVelocity); 
			}
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(Vector3.up, -this.SteerVelocity * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(Vector3.up, +this.SteerVelocity * Time.deltaTime);
		}

	}
}
