using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiScript : MonoBehaviour
{
    public Animator anim;
    public AudioManagerScript audioManager;

    public GameManagerData gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        //SceneManager.LoadScene("SampleScene");
        //play fadeout aniamtion that will do the above anyway at the end of its anim thingy
        audioManager.PlaySFX(audioManager.click);
        anim.SetBool("FadeOut", true);

    }
    public void Quit()
    {
        Application.Quit();
        audioManager.PlaySFX(audioManager.click);
    }

    public void SetSense(float sensitivity)
    {
        gm.CameraSens = sensitivity;
        
        
    }
}
