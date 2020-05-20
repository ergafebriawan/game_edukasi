using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour
{
    // Start is called before the first frame update
	Text infonyawa, infocp;

    public int kecepatan, kekuatanLompat;
    public bool balik;
    public int pindah;

    Rigidbody2D lompat;

    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

	Animator Anim;

	public int nyawa;
	public int cp;

	Vector2 mulai;

	public bool ulang;

	public bool tombolKiri,tombolKanan;
	public GameObject menang, kalah;
    
    void Start()
    {
		infonyawa = GameObject.Find("UInyawa").GetComponent<Text>();
		infocp = GameObject.Find("UIcp").GetComponent<Text>();
        lompat = GetComponent<Rigidbody2D> ();
		Anim = GetComponent<Animator> ();
		mulai = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		infonyawa.text = "Nyawa : "+ nyawa.ToString ();
		infocp.text = "Capaian Pembelajaran : "+ cp.ToString ();

		if(ulang == true){
			transform.position = mulai;
			ulang = false;
		}

		if (nyawa <= 0) {
			Destroy(gameObject);
			kalah.SetActive (true);
			Application.LoadLevel (2);
		}else if(cp>=4){
			menang.SetActive (true);
		}

		if (nyawa <= 0) {
			Destroy (gameObject);
		}

		if (tanah == true) {
			Anim.SetBool ("lompat", false);
		} else {
			Anim.SetBool ("lompat", true);
		}
			
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);
		if (Input.GetKey (KeyCode.RightArrow) ||(tombolKanan==true)) {
			transform.Translate (Vector2.right * kecepatan * Time.deltaTime);
			Anim.SetBool ("lari", true);
			pindah = 1;
		} else if (Input.GetKey (KeyCode.LeftArrow) ||(tombolKiri==true)) {
			Anim.SetBool ("lari", true);
			transform.Translate (Vector2.right * -kecepatan * Time.deltaTime);
			pindah = -1;
		} else {
			Anim.SetBool ("lari", false);
		}

		if (tanah == true && (Input.GetKey(KeyCode.Space)))
        {
            lompat.AddForce(new Vector2(0,kekuatanLompat));
        }

        if (pindah>0 && !balik)
        {
            balik_badan();
        }else if(pindah<0 && balik)
        {
            balik_badan();
        }

    }

    void balik_badan()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;

    }

	public void tekankiri(){
		tombolKiri = true;
	}
	public void lepaskiri(){
		tombolKiri = false;
	}

	public void tekankanan(){
		tombolKanan = true;
	}
	public void lepaskanan(){
		tombolKanan = false;
	}
	public void loncat(){
		if (tanah == true) {
			lompat.AddForce (new Vector2 (0, kekuatanLompat));
		}
	}
}
