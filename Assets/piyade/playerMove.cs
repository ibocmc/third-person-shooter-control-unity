using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public Animator anim;

	public float yRot = 0;

	private float vertical;
	private float horizontal;

	public bool walk;
	public bool walk_h;
	public bool walkaim;
	public bool jogaim;
	public bool run_h;
	public bool standfire;
	public bool c_walkaim;
	public bool crouchfire;
	public bool prone;
	public bool turnL;
	public bool turnR;

	public bool turnL_h;
	public bool turnR_h;

	public bool reload;
	public bool switchW_e;
	public bool switchW_h;

	public bool state_1;

	public GameObject hand_rocket;
	public GameObject back_rocket;
	public GameObject hand_rifle;
	public GameObject back_rifle;


	public AudioSource rifle_sound;
	public AudioSource rpg_sound;

	public float nextFire;
	public float fireRate;
	public float fireRate2;

	public GameObject fire_rpg;
	public Transform rpgFire_spawn;

	public GameObject fireEffect;
	public GameObject bullet;
	//public GameObject eject;

	public Transform f_effectSpawn;
	public Transform bullet_spawn;
	//public Transform eject_spawn;



	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();

		walk = false;
		walk_h = false;
		walkaim = false;
		standfire = false;
		jogaim = false;
		run_h = false;
		c_walkaim = false;
		crouchfire = false;
		prone = false;
		turnL = false;
		turnR = false;
		turnL_h = false;
		turnR_h = false;
		reload = false;
		switchW_e = false;
		switchW_h = false;

		state_1 = false;

		hand_rocket.SetActive (false);
		back_rocket.SetActive (true);
		hand_rifle.SetActive (false);
		back_rifle.SetActive (true);



	
	}



	
	// Update is called once per frame
	void Update () {
	
		anim.SetBool ("walk", walk);
		anim.SetBool ("walk_h", walk_h);
		anim.SetBool ("walkaim", walkaim);
		anim.SetBool ("standfire", standfire);
		anim.SetBool ("jogaim", jogaim);
		anim.SetBool ("run_h", run_h);
		anim.SetBool ("c_walkaim", c_walkaim);
		anim.SetBool ("crouchfire", crouchfire);
		anim.SetBool ("prone", prone);
		anim.SetBool ("turnL", turnL);
		anim.SetBool ("turnR", turnR);
		anim.SetBool ("turnL_h", turnL_h);
		anim.SetBool ("turnR_h", turnR_h);
		anim.SetBool ("reload", reload);
		anim.SetBool ("switchW_e", switchW_e);
		anim.SetBool ("switchW_h", switchW_h);
		//anim.SetBool ("state_1", state_1);

		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		anim.SetFloat ("horizontal", horizontal);
		anim.SetFloat ("vertical", vertical);





		if (hand_rifle.activeSelf || hand_rocket.activeSelf) {

			state_1 = true;

		} else
			state_1 = false;


		if (Input.GetKey (KeyCode.W)) {

			walk = true;

		} else
			walk = false;

		if ((Input.GetKey (KeyCode.W)) && !state_1 ) {

			walk_h = true;


		} else
			walk_h = false;
			//walk = false;

		if (Input.GetMouseButton(1)) {

			walkaim = true;


		} else
			walkaim = false;


		if ((Input.GetMouseButton (0)) && state_1) {

			//walkaim = false;
			//walk = false;
			standfire = true;
			crouchfire = true;

			if (Input.GetMouseButton(0) && Time.time > nextFire && !hand_rocket.activeSelf) {

				rifle_sound.Play ();
				nextFire = Time.time + fireRate;
				Instantiate (fireEffect, f_effectSpawn.position, f_effectSpawn.rotation);
				Instantiate (bullet, bullet_spawn.position, bullet_spawn.rotation);
				//Instantiate (eject, eject_spawn.position, eject_spawn.rotation);
				//rb.velocity = transform.forward * roc_speed;
			} 


			if (Input.GetMouseButton(0) && Time.time > nextFire && !hand_rifle.activeSelf) {

				rpg_sound.Play ();
				nextFire = Time.time + fireRate2;
				Instantiate (fire_rpg, rpgFire_spawn.position, rpgFire_spawn.rotation);
				//Instantiate (rocket, rocket_spawn.position, rocket_spawn.rotation);
				//Instantiate (eject, eject_spawn.position, eject_spawn.rotation);
				//rb.velocity = transform.forward * roc_speed;
			} 





		} else {
			standfire = false;
			crouchfire = false;
			//walk = true;
			//walkaim = true;








		
		}

		if (Input.GetKey (KeyCode.LeftShift)) {

			jogaim = true;

		} else
			jogaim = false;

		if ((Input.GetKey (KeyCode.LeftShift)) && !state_1) {

			run_h = true;
			//jogaim = true;
		} else
			run_h = false;
			//jogaim = false;

		if (Input.GetKey (KeyCode.C)) {

			if (state_1) {
				c_walkaim = true;


			}
		} else
			c_walkaim = false;


		if(Input.GetKeyDown(KeyCode.C) && state_1  ){

			yRot += 20;

			if (yRot > 20)
				yRot = 20;
			transform.Rotate (0, -yRot, 0);


		}

		if (Input.GetKey (KeyCode.Z)) {

			if(state_1){

			prone = true;
			}
		} else
			prone = false;

		if ((Input.GetKey (KeyCode.A)) && !state_1) {

			turnL_h = true;
		
		} else
			turnL_h = false;

		if (Input.GetKey (KeyCode.A)) {

			turnL = true;

		} else
			turnL = false;

		if (Input.GetKey (KeyCode.D)) {

			turnR = true;
		} else
			turnR = false;

		
		if ((Input.GetKey (KeyCode.D)) && !state_1) {

			turnR_h = true;
		} else
			turnR_h = false;

		if (Input.GetKey (KeyCode.R)) {


			reload = true;


		} else
			reload = false;

//		if (Input.GetKey(KeyCode.Alpha1)) {
//
//
//			if(hand_rifle.activeSelf){
//
//				switchW_h = true;
//				back_rifle.SetActive (true);
//				hand_rifle.SetActive (false);
//
//			}
//
//			if(hand_rocket.activeSelf){
//
//				switchW_h = true;
//
//				back_rocket.SetActive (true);
//				hand_rocket.SetActive (false);
//			}
////			hand_rocket.SetActive (true);
////			back_rocket.SetActive (false);
////			hand_rifle.SetActive (false);
////			back_rifle.SetActive (true);
//
//		} else
//			switchW_h = false;
//
//		if (Input.GetKey (KeyCode.Alpha2)) {
//
//			switchW_e = true;
//			hand_rifle.SetActive (true);
////			back_rocket.SetActive (true);
////			hand_rocket.SetActive (false);
//			back_rifle.SetActive (false);
//
//		} else
//			switchW_e = false;
//
//		if(Input.GetKey(KeyCode.Alpha3)){
//
//			switchW_e = true;
//			hand_rocket.SetActive (true);
//			back_rocket.SetActive (false);
//		}

//		if(Input.GetKeyDown(KeyCode.Q)){
//
//			switchWeapon ();
//		}

		StartCoroutine (doWait ());
	}

	public IEnumerator doWait(){
		
		if (Input.GetKey(KeyCode.Alpha1)) {
			
			//if(!walk && !walk_h){

			if(hand_rifle.activeSelf){

				switchW_h = true;

				yield return new WaitForSeconds (1.2f);
				back_rifle.SetActive (true);

				hand_rifle.SetActive (false);

			}

			if(hand_rocket.activeSelf){

				switchW_h = true;

				yield return new WaitForSeconds (1.2f);

				back_rocket.SetActive (true);
				hand_rocket.SetActive (false);
			}
			//			hand_rocket.SetActive (true);
			//			back_rocket.SetActive (false);
			//			hand_rifle.SetActive (false);
			//			back_rifle.SetActive (true);
			//}
		} else
			switchW_h = false;

		if (Input.GetKey (KeyCode.Alpha2)) {

			//if(!walk && !walk_h){

			if(back_rifle.activeSelf && back_rocket.activeSelf ){

			switchW_e = true;

			yield return new WaitForSeconds (0.5f);

			hand_rifle.SetActive (true);
			//			back_rocket.SetActive (true);
			//			hand_rocket.SetActive (false);
			back_rifle.SetActive (false);
			}
		//	}
		} else
			switchW_e = false;

		if (Input.GetKey (KeyCode.Alpha3)) {

			if (back_rocket.activeSelf && back_rifle.activeSelf) {

				switchW_e = true;

				yield return new WaitForSeconds (0.5f);


				hand_rocket.SetActive (true);
				back_rocket.SetActive (false);
			}
		} else
			switchW_e = false;


	}


//	public void switchWeapon(){
//
//		if (weapon1.activeSelf) {
//
//
//			weapon1.SetActive (false);
//			//weapon2.SetActive (true);
//
//		} else {
//
//			weapon1.SetActive (true);
//			//weapon2.SetActive (false);
//	}
//
//	}



}
