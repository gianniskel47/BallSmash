using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private const string MUSIC_VOLUME = "MusicVolume";
    private const string SFX_VOLUME = "SfxVolume";

    [Header("References")]
    [SerializeField] AudioMixer sfxMixer;
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioSource music;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            ChangeMusicVolume(PlayerPrefs.GetFloat(MUSIC_VOLUME));
        }

        if (PlayerPrefs.HasKey(SFX_VOLUME))
        {
            ChangeSfxVolume(PlayerPrefs.GetFloat(SFX_VOLUME));
        }
    }

    public void ChangeSfxVolume(float value)
    {
        float db;
        if (value <= 0.001f)
        {
            db = -80;
        }
        else
        {
            db = Mathf.Log10(value) * 20f;
        }

        sfxMixer.SetFloat(SFX_VOLUME, db);
    }

    public void ChangeMusicVolume(float value)
    {
        float db;
        if (value <= 0.001f)
        {
            db = -80;
        }
        else
        {
            db = Mathf.Log10(value) * 20f;
        }

        musicMixer.SetFloat(MUSIC_VOLUME, db);
    }

    public void StopMusic()
    {
        music.Pause();
    }

    public void ResumeMusic()
    {
        music.UnPause();
    }
}
