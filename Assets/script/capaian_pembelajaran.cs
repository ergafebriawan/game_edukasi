using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capaian_pembelajaran : MonoBehaviour {

	gerak KomponenGerak;
	public int yangdituju;

	// Use this for initialization
	void Start () {
		KomponenGerak = GameObject.Find("player").GetComponent<gerak>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			KomponenGerak.cp++;
			Destroy (gameObject);
			Application.LoadLevel (yangdituju);
		
		}
	}
	
}
