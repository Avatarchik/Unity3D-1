using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance = null;
    public static SoundManager Instance()
    {
        return _instance;
    }

    public AudioClip mainBGM = null;
    public AudioClip exploreBGM = null;
    public AudioClip uiTouch = null;
    public AudioClip SceneTran = null;
    public AudioClip planetTouch = null;
    public AudioClip dragPlanet = null;
    public AudioClip getFood = null;
    public AudioClip buyTi = null;
    public AudioClip buyFood = null;
    public AudioClip changePlanet = null;
    public AudioClip usePe = null;
    public AudioClip activeStar = null;
    public AudioClip activeSign = null;
    public AudioClip startExplore = null;
    public AudioClip endExplore = null;
    public AudioClip shipHumming = null;
    public AudioClip destroyPlanet = null;


    void Start()
    {
        if (_instance == null)
            _instance = this;
    }

    public void PlaySfx(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}