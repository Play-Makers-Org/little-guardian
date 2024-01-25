using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanBarları : MonoBehaviour
{   //Oyuncu ve Makinenin canlarını tanımladım
    public Slider CanBarıPlayer;
    public Slider CanBarıMakine;
    //Değer girdim, bu değerleri değiştirebilirsin, sıkıntı çıkarsa bakarız.
    public int canPlayer = 100;
    public int canMakine = 100;

    public void Awake()
    {   
        CanBarıPlayer = GameObject.Find("PlayerSlider").GetComponent<Slider>();
        CanBarıMakine = GameObject.Find("MachineSlider").GetComponent<Slider>();
    }

    void Start()
    {   //Sayısal ayarlamalar gerekiyorsa bunları değiştir.
        CanBarıMakine.maxValue = 100;
        CanBarıMakine.minValue = 0;
        CanBarıMakine.value = canMakine;
        CanBarıMakine.wholeNumbers = true; //ondalıklı değerler almasını engelliyor.
        
        CanBarıPlayer.maxValue = 100;
        CanBarıPlayer.minValue = 0;
        CanBarıPlayer.value = canPlayer;
        CanBarıPlayer.wholeNumbers = true; //ondalıklı değerler almasını engelliyor.
    }
    
    void Update()
    {   //Bu kontrol amaçlı, sen oyun içerisinde hangi koşulda can değişmesini
        //istiyorsan o şekilde ayarla. Bu kodun if kısmı değişecek.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canPlayer -= 20;
            canMakine -= 20;
            CanBarıMakine.value = canMakine;
            CanBarıPlayer.value = canPlayer;
        }
    }
}
