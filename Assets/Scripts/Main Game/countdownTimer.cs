using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdownTimer : MonoBehaviour
{

    public Text TimerText;
    public static float myCoolTimer = 3;
    public int soundCountdown = 3;
    public static bool timerActivated;
    public GameObject actualTimer;
    public GameObject go;
    AudioSource[] sounds;
    AudioSource down, begin;

    // Use this for initialization
    void Start()
    {

        TimerText = GetComponent<Text>();
        sounds = GetComponents<AudioSource>();
        down = sounds[0];
        timerActivated = true;

    }

    void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActivated)
        {
            if (myCoolTimer <= soundCountdown)
            {
                PlayAudio(down);
                soundCountdown--;
            }
            myCoolTimer -= Time.deltaTime;         //all this junk displays the time and counts down
            TimerText.text = ("Get Ready...");
            if (myCoolTimer <= 0)
            {
                //End the countdown timer
                go.SetActive(true);
                timerActivated = false;
                myCoolTimer = 0;
                //Activate actual timer
                timer.timerActivated = true;
                gameObject.SetActive(false);
                
            }
        }
    }


}
