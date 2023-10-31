using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveButton : MonoBehaviour
{
    public WaveManager WaveManager;
    private Button button;

    private void Update()
    {
        button = GetComponent<Button>();
        //Button button = GetComponent<Button>();

        button.onClick.AddListener(StartWave);
    }
    private void StartWave()
    {
        WaveManager.TempStart = true;
        
    }
}
