using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

	public float attractionForce;

	Rigidbody rigidBody;

	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate(){
		rigidBody.AddForce (transform.localPosition * -attractionForce);
	}
}
