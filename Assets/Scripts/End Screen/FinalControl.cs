using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalControl : MonoBehaviour
{

    private KeyCode space = KeyCode.Space;
    private KeyCode esc = KeyCode.Escape;
    private float timeout = 1.0f;
    private int finalSelection = -1;
    private AudioSource sound;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(esc))
        {
            finalSelection = 0;
        }
        if (Input.GetKeyDown(space) || Input.GetKeyDown(esc))
        {
            sound.Play();
        }
        if (Input.GetKeyUp(space))
        {
            finalSelection = 1;
        }
        if (finalSelection != -1 && timeout > 0)
        {
            timeout -= Time.deltaTime;
        }
        if (finalSelection != -1 && timeout <= 0)
        {
            timeout = -1;
            timer.myCoolTimer = 60;
            countdownTimer.myCoolTimer = 3;
            countdownTimer.timerActivated = true;
            if (finalSelection == 0)
            {
                SceneManager.LoadScene("Title");
            }
            else if (finalSelection == 1)
            {
                SceneManager.LoadScene("Main");
            }
        }


    }

}
