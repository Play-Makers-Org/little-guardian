using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private TextMeshProUGUI _timerUI;
    private GameObject _gm;

    private void Start()
    {
        _timerUI = GetComponent<TextMeshProUGUI>();
        _gm = GameObject.Find("_GM");
    }

    // Update is called once per frame
    void Update()
    {
        var elapsedTime = _gm.GetComponent<WaveManager>().gameTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        _timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
