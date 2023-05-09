using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countdown;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countdown ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;
        float seconds = Mathf.FloorToInt(currentTime);
        float minutes = Mathf.FloorToInt (currentTime / 60);
        float hund = (currentTime - seconds)*100;
        seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, hund);

    }
}
