using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    static SoundManager _instance = null;
    static bool bgmBegin = false;
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


    void Awake()
    {
        if (_instance == null)
            _instance = this;

        if (!bgmBegin)
        {
            gameObject.name = "SoundManager_Active";
            DontDestroyOnLoad(gameObject);
            bgmBegin = true;

            if (gameObject.scene.name != "Explore")
            {
                GetComponent<AudioSource>().clip = mainBGM;
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().clip = exploreBGM;
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().Play();
            }
        }
        if(GameObject.Find("SoundManager_Active") != null && GameObject.Find("SoundManager") != null)
        {
            Destroy(GameObject.Find("SoundManager").gameObject);
        }
    }
    public void PlaySfx(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}