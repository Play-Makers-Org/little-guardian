using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadAudio();//Ses ayarını oyun açıldığında yükleyecek
    }

    public Slider slider;
    
    //Bu kısım ses ayarıyla ilgili
    public void SetAudio(float VolumeValue)
    {
        AudioListener.volume = VolumeValue;
    }
    //Bu kısım oyun açılıp kapandığında ses ayarını korusun diye var.
    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("AudioVolume",AudioListener.volume);
    }

    //Kaydedilen ses ayarını yükleyecek kod
    private void LoadAudio()
    {
        if (PlayerPrefs.HasKey("AudioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
            slider.value = PlayerPrefs.GetFloat("AudioVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("AudioVolume",0.5f);
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
            slider.value = PlayerPrefs.GetFloat("AudioVolume");
        }
    }
}
