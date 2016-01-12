using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClashHandler : MonoBehaviour {

    float approveFailTimer = 0f;
    float explosionTimer = 0f;
    public int scoreCount;
    public static int finalScore;
    public Text scoreText;
    public GameObject rock, paper, scissors, approve, fail, tie, redExp, blueExp, yellowExp;
    AudioSource[] sounds;
    AudioSource playerWin, playerLose, playerTie;

    // Use this for initialization
    void Start () {

        scoreCount = 0;
        DisplayScore();
        sounds = GetComponents<AudioSource>();
        playerWin = sounds[0];
        playerLose = sounds[1];
        playerTie = sounds[2];

    }
	
	void Update () {
        //print score
        DisplayScore();
        if (countdownTimer.myCoolTimer <= 0) //makes sure the game has started
        {
            Clash();
        }
        if (approveFailTimer <= 0f) //stops showing approve/fail when timer runs out
        {
            approve.SetActive(false);
            fail.SetActive(false);
            tie.SetActive(false);
            approveFailTimer = 0;
        }
        else if (approveFailTimer > 0f)  //counts down how long approve/fail is shown
        {
            approveFailTimer -= (Time.deltaTime * 2);
        }
        if (explosionTimer <= 0f)
        {
            yellowExp.SetActive(false);
            blueExp.SetActive(false);
            redExp.SetActive(false);
            explosionTimer = 0;
        }
        else if (explosionTimer > 0f)
        {
            explosionTimer -= (Time.deltaTime * 2);
        }

        if (timer.myCoolTimer <= 0)
        {
            finalScore = scoreCount;
        }

    }

    void DisplayScore () {
        scoreText.text = scoreCount.ToString();
    }

    void ResetPlayerEnemy()
    {
        PlayerController.state = -1;
        if ((int)Spawner.enemies[0] == 1)     //deactivates rock
        {
            rock.SetActive(false);
        }
        if ((int)Spawner.enemies[0] == 2)    //deactivates paper
        {
            paper.SetActive(false);
        }
        if ((int)Spawner.enemies[0] == 3)    //deactivates scissors
        {
            scissors.SetActive(false);
        }
        Spawner.enemies.RemoveAt(0);    // removes enemy from the ArrayList
        
    }

    void IncreaseScore() {
        scoreCount = scoreCount + 1;
    }

    void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    void ApproveFailHandler(GameObject g)
    {
        approve.SetActive(false);
        fail.SetActive(false);
        tie.SetActive(false);
        g.SetActive(true);
        if (fail.activeSelf)
        {
            approveFailTimer = 1.5f;
        }
        else
        {
            approveFailTimer = 0.5f;
        }
    }

    void ExplosionDisplay(GameObject g)
    {
        yellowExp.SetActive(false);
        redExp.SetActive(false);
        blueExp.SetActive(false);
        g.SetActive(true);
        explosionTimer = 0.5f;
    }

    void Clash()
    {
        //player wins
        if (PlayerController.state == 1 && (int)(Spawner.enemies[0]) == 3)
        { //rock beats scissors
            PlayAudio(playerWin);
            ApproveFailHandler(approve);
            ExplosionDisplay(redExp);
            IncreaseScore();
            print("You won! Rock beats Scissors");
            ResetPlayerEnemy();
        }
        if (PlayerController.state == 3 && (int)(Spawner.enemies[0]) == 2)
        { //scissors beats paper
            PlayAudio(playerWin);
            ApproveFailHandler(approve);
            ExplosionDisplay(yellowExp);
            IncreaseScore();
            print("You won! Scissors beats Paper");
            ResetPlayerEnemy();
        }
        if (PlayerController.state == 2 && (int)(Spawner.enemies[0]) == 1)
        { //paper beats rock
            PlayAudio(playerWin);
            ApproveFailHandler(approve);
            ExplosionDisplay(blueExp);
            IncreaseScore();
            print("You won! Paper beats Rock");
            ResetPlayerEnemy();
        }

        //enemy wins
        if (PlayerController.state == 3 && (int)(Spawner.enemies[0]) == 1)
        { //rock beats scissors
            PlayAudio(playerLose);
            DisablePlayer();
            ApproveFailHandler(fail);
            print("You lost! Scissors loses to Rock");
            ResetPlayerEnemy();
        }
        if (PlayerController.state == 2 && (int)(Spawner.enemies[0]) == 3)
        { //scissors beats paper
            PlayAudio(playerLose);
            DisablePlayer();
            ApproveFailHandler(fail);
            print("You lost! Paper loses to Scissors");
            ResetPlayerEnemy();
        }
        if (PlayerController.state == 1 && (int)(Spawner.enemies[0]) == 2)
        { //paper beats rock
            PlayAudio(playerLose);
            DisablePlayer();
            ApproveFailHandler(fail);
            print("You lost! Rock loses to Paper");
            ResetPlayerEnemy();
        }

        //tie, nothing happens
        if (PlayerController.state == (int)Spawner.enemies[0])
        {
            PlayAudio(playerTie);
            ApproveFailHandler(tie);
            print("It was a tie.");
            ResetPlayerEnemy();
        }
    }

    void DisablePlayer() //disable player for one second if they lose a match
    {
        //playerActive becomes false for one second, then goes back to true
        PlayerController.playerActive = false;
        PlayerController.sprite.color = Color.gray;
    }
}
