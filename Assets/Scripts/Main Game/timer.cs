using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    public Text TimerText;
    public GameObject goText;
    public static float myCoolTimer = 60;
    public static bool timerActivated = false;
    bool beginPlayed = false;
    AudioSource[] sounds;
    AudioSource begin, end, down;
    public AudioSource bgm;
    public int soundCountdown = 5;
    private float timeout = 1.0f;

    // Use this for initialization
    void Start () {

        TimerText = GetComponent<Text>();
        sounds = GetComponents<AudioSource>();
        begin = sounds[0];
        end = sounds[1];
        down = sounds[2];
	}
	
	// Update is called once per frame
	void Update () {
        if (timerActivated){
            if (!beginPlayed)
            {
                begin.Play();
                beginPlayed = true;
                bgm.Play();
            }
            myCoolTimer -= Time.deltaTime;
            TimerText.text = myCoolTimer.ToString("f0");
            if (myCoolTimer <= (float)soundCountdown)   //play countdown noises as timer approaches 0
            {
                TimerText.fontSize = 135;
                down.Play();
                soundCountdown--;
            }
            if (myCoolTimer <= 59) // remove the go text
            {
                goText.SetActive(false);
            }
            if (myCoolTimer <= 0)
            {
                //End the game
                timerActivated = false;
                myCoolTimer = 0;
                bgm.Stop();
                end.Play();
            } 
        }
        if (myCoolTimer <= 0 && timerActivated == false && timeout > 0)
        {
            timeout -= Time.deltaTime;
        }

        if (myCoolTimer <= 0 && timerActivated == false && timeout <= 0)
        {
            timeout = -1;
            SceneManager.LoadScene("End");
        }
    }
}
