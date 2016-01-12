using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private BoxCollider2D boxCollider;
    public static int state;
    public static SpriteRenderer sprite;

    //buttons
    private KeyCode rock = KeyCode.A;
    private KeyCode paper = KeyCode.W;
    private KeyCode scissors = KeyCode.D;
    public Animator animator;

    private float playerTimer = 1;
    public static bool playerActive = true;

    void Start () {
        state = -1; //neutral
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (countdownTimer.myCoolTimer <= 0 && (float)timer.myCoolTimer > 0){
            if (Input.GetKeyDown(rock) && playerActive)
            {
                state = 1; //rock state
                animator.SetTrigger("hand_rock");
            }
            if (Input.GetKeyDown(paper) && playerActive)
            {
                state = 2; //paper state
                animator.SetTrigger("hand_paper");
            }
            if (Input.GetKeyDown(scissors) && playerActive)
            {
                state = 3; //scissors state
                animator.SetTrigger("hand_scissors");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Title");
                timer.myCoolTimer = 60;
                timer.timerActivated = false;
                countdownTimer.myCoolTimer = 3;
                countdownTimer.timerActivated = true;
            }
        }

        if (playerTimer > 0 && !playerActive)   //if player is disabled, reenable within 1 second
        {
            playerTimer -= Time.deltaTime;
        }
        if (playerTimer <= 0 && !playerActive)  //reenables player once timer hits 0
        {
            sprite.color = Color.white;
            playerActive = true;
            playerTimer = 1;
        }
    }
}
