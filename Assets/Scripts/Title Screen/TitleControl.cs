using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleControl : MonoBehaviour
{

    public GameObject titleScreen, instructionScreen, transparency, hand;

    public Text start, instructions, exit;
    public int selection;
    private int finalSelection = -1;
    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private KeyCode space = KeyCode.Space;
    private bool viewingInstr;
    AudioSource[] sounds;
    AudioSource move, select;
    private float timeout = 1.0f;

    // Use this for initialization
    void Start()
    {
        selection = 0;
        sounds = GetComponents<AudioSource>();
        move = sounds[0];
        select = sounds[1];
        viewingInstr = false;
    }

    // Update is called once per frame
    void Update()
    {

        DisplayPointer();
        if (!viewingInstr) { 
            if (Input.GetKeyDown(up) || Input.GetKeyDown(KeyCode.UpArrow))  //move up the menu
            {
                PlayAudio(move);
                if (selection == 0) //if at the top, goes to the bottom
                {
                    selection = 2;
                }
                else
                {
                    selection--;
                }
            }
            if (Input.GetKeyDown(down) || Input.GetKeyDown(KeyCode.DownArrow))  //move down the menu
            {
                PlayAudio(move);
                if (selection == 2) //if at the bottom, goes to the top
                {
                    selection = 0;
                }
                else
                {
                    selection++;
                }
            }
        }

        MakeSelection();
        if (finalSelection != -1 && timeout > 0)    //starts timer to next scene
        {
            timeout -= Time.deltaTime;
        }
        if (finalSelection != -1 && timeout <= 0)
        {
            timeout = 0;
            if (finalSelection == 0)
            {
                timer.myCoolTimer = 60;
                countdownTimer.myCoolTimer = 3;
                countdownTimer.timerActivated = true;
                SceneManager.LoadScene("Main");
            }
            else if (finalSelection == 1)
            {
                viewingInstr = true;
                hand.SetActive(false);
                transparency.SetActive(true);
                titleScreen.SetActive(false);
                instructionScreen.SetActive(true);
            }
            else if (finalSelection == 2)
            {
                Application.Quit();
            }
        }

        if (instructionScreen.activeSelf)   //if instuctions are active and they press escape
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                PlayAudio(select);
                finalSelection = -1;
                hand.SetActive(true);
                transparency.SetActive(false);
                instructionScreen.SetActive(false);
                titleScreen.SetActive(true);
                viewingInstr = false;
            }
        }

    }

    void MakeSelection()
    {
        if (Input.GetKeyDown(space) || Input.GetKeyDown(KeyCode.Return)) //play selection sound
        {
            PlayAudio(select);
        }
        if (Input.GetKeyUp(space) || Input.GetKeyUp(KeyCode.Return))  //confirm selection
        {
            finalSelection = selection;
        }
    }


    void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    void DisplayPointer()
    {
        if (selection == 0) //start pointer
        {
            instructions.color = Color.black;
            exit.color = Color.black;

            start.color = Color.red;
        }
        if (selection == 1) //instructions pointer
        {
            start.color = Color.black;
            exit.color = Color.black;

            instructions.color = Color.red;
        }
        if (selection == 2) //exit pointer
        {
            start.color = Color.black;
            instructions.color = Color.black;

            exit.color = Color.red;
        }
    }
}
