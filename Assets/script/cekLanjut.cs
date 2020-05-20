using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cekLanjut : MonoBehaviour {
	public int avg;
	public GameObject tombol;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("skor") < avg) {
			tombol.SetActive (false);
		} else {
			tombol.SetActive (true);
		}
	}
}
