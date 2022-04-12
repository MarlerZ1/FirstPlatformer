using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private AudioClip aClip;
    private AudioSource audio;
    

    public void PlayGame()
    {
        audio = GetComponent<AudioSource>();
        aClip = Resources.Load<AudioClip>("Audio/tap");
        audio.PlayOneShot(aClip);

        StartCoroutine(TapPlayCoroutine());
            
    }
    public void ExitGame()
    {
        audio = GetComponent<AudioSource>();
        aClip = Resources.Load<AudioClip>("Audio/tap");
        audio.PlayOneShot(aClip);
        StartCoroutine(TapExitCoroutine());
    }

    IEnumerator TapPlayCoroutine() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator TapExitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
