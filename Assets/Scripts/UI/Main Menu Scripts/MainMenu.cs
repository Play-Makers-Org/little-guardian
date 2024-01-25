using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{   //Açılır pencereleri önceki projemde GameObject olarak tanımlamışım. Onu kopyaladım, mantığını hatırlamıyorum. Gereksiz görürsen sil ama test et.
    public GameObject QuitPanel;
    public GameObject SettingPanel;
    public GameObject MainMenuSurePanel;
    public GameObject StoruPanel;
    public GameObject CreditsPanel;
    public GameObject Filtre;

    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);
        Filtre.SetActive(true);
    }

    public void CreditsCloseButton()
    {
        CreditsPanel.SetActive(false);
        Filtre.SetActive(false);
    }

    public void StoryButton()
    {
        StoruPanel.SetActive(true);
        Filtre.SetActive(true);
    }

    public void StoryCloseButton()
    {
        StoruPanel.SetActive(false);
        Filtre.SetActive(false);
    }
    public void StartButton()
    {   //Start tuşuna basıldığında oyun alanı olan sahneyi açan kod
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {   //Oyun içerisindeyken main menuye geri gönderecek kod
        SceneManager.LoadScene(0);
    }

    public void SettingsButton()
    {   //Settings tuşuna basıldığında açılan pencere
        SettingPanel.SetActive(true);
        Filtre.SetActive(true);
    }

    public void QuitButton()
    {   //Quit tuşuna basıldığında açılan pencere
        QuitPanel.SetActive(true);
        Filtre.SetActive(true);
        SettingPanel.SetActive(false);
    }

    public void NotSureButton()
    {   // Bu kısım açılır pencereleri kapatan kodları barındırıyor. Sorun çıkarsa ikisini ayrı ayrı yazarız.
        QuitPanel.SetActive(false);
        Filtre.SetActive(false);
    }

    public void QuitNotSureButton()
    {
        QuitPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void SettingCloseButton()
    {   //İkisini ayırdım.
        SettingPanel.SetActive(false);
        Filtre.SetActive(false);
    }

    public void MainMenuSureButton()
    {
        MainMenuSurePanel.SetActive(true);
        Filtre.SetActive(true);
        SettingPanel.SetActive(false);
    }
    public void MainMenuNotSureButton()
    {
        MainMenuSurePanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void ExitButton()
    {   //Oyunu kapatan kod. Unity içerisinde çalışmaz, build ettiğimizde çalıştığını test ederiz.
        Application.Quit();
    }

    public void Start()
    {   //Oyun açıldığında açılır pencereleri kapatan kod. Unity içerisinde pencereleri açık unutursak sıkıntı oluşturmasını engelleyen kod.
        QuitPanel.SetActive(false);
        SettingPanel.SetActive(false);
        MainMenuSurePanel.SetActive(false);
        Filtre.SetActive(false);
    }
    
}
