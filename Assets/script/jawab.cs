﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jawab : MonoBehaviour
{
    public GameObject feed_benar, feed_salah;
	public int val;

    void Start()
    {
		
    }

    public void jawaban(bool jawab)
    {
        if (jawab)
        {
            feed_benar.SetActive(false);
            feed_benar.SetActive(true);
			int skor = PlayerPrefs.GetInt("skor") + val;
            PlayerPrefs.SetInt("skor", skor);
        }
        else
        {
            feed_salah.SetActive(false);
            feed_salah.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }

	public void lanjut(bool jawab)
	{
		gameObject.SetActive(false);
		transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
