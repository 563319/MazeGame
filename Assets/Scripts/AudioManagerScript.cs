using Unity.Audio;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource loopSFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip lifeLost;
    public AudioClip flashLight;
    public AudioClip win;
    public AudioClip lost;
    public AudioClip enemyAttacking;
    public AudioClip collect;
    public AudioClip click;
    //etc
    private void Start()
    {
        //musicSource.clip = backgroundMusic
        //musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayLoopSFX(AudioClip clip)
    {
        if (loopSFXSource.clip == clip && loopSFXSource.isPlaying)
        {
            return;
        }
        loopSFXSource.clip = clip;
        loopSFXSource.loop = true;
        loopSFXSource.Play();
    }
    public void StopLoopSFX(AudioClip clip)
    {
        loopSFXSource.Stop();
    }
}
