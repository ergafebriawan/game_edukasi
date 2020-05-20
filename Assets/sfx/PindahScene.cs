using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public AudioSource ButtonSource;
    public string namaScene;

    public void PindahkeScene()
    {
        AudioSource buttonSource = ButtonSource.GetComponent<AudioSource>();
        buttonSource.PlayOneShot(buttonSource.clip);

        Scene sceneIni = SceneManager.GetActiveScene();

        if(sceneIni.name != namaScene)
        {
            SceneManager.LoadScene(namaScene);
        }
    }
}
