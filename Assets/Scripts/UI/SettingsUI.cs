using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    private const string MUSIC_VOLUME = "MusicVolume";
    private const string SFX_VOLUME = "SfxVolume";

    [Header("References")]
    [SerializeField] Button backButton;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    private void Awake()
    {
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(ChangeSfxVolume);
        backButton.onClick.AddListener(() => SceneLoader.Instance.LoadSceneByName("StartScene"));
    }

    void Start()
    {
        if (PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME);
        }
        else
        {
            musicVolumeSlider.value = 1f;
        }

        if (PlayerPrefs.HasKey(SFX_VOLUME))
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME);
        }
        else
        {
            sfxVolumeSlider.value = 1f;
        }
    }

    private void ChangeSfxVolume(float value)
    {
        PlayerPrefs.SetFloat(SFX_VOLUME, value);
        AudioManager.Instance.ChangeSfxVolume(value);
    }

    private void ChangeMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME, value);
        AudioManager.Instance.ChangeMusicVolume(value);
    }
}
