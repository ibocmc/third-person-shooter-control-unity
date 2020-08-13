using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	public float speed;
	//public float r_speed;
	public Rigidbody rb;

	//public AudioSource missile_sound;




	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void FixedUpdate() {
		//missile_sound.Play ();
		rb.velocity = transform.forward * speed ;
		//transform.Translate (0, speed * Time.deltaTime,0);
		//rb.AddTorque(transform.forward * r_speed,ForceMode.VelocityChange);
	}
}
