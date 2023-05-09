using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int doughnuts = 0;
    public TextMeshProUGUI doughnutsText;
    public GameObject endMenu;
    public TextMeshProUGUI endTimer;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI endDoughnuts;
    public AudioSource donutSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Donut"))
        {
            Destroy(other.gameObject);
            donutSound.Play();
            doughnuts++;
            doughnutsText.text = doughnuts + "/10";
        }

        if (other.gameObject.CompareTag("BigDonut"))
        {
            Destroy(other.gameObject);
            endMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.0f;
            endTimer.text = timer.text;
            endDoughnuts.text = doughnutsText.text;

        }
    }



}
