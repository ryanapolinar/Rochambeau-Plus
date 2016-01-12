using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public static ArrayList enemies;
    public GameObject rock, paper, scissors;

	void Start () {
        enemies = new ArrayList();
	}
	
	void Update () {

        if (enemies.Count < 5) //if enemies are less than 5, generate enemies
            {
                int newEnemy = Random.Range(1, 4); //creates a new enemy
                enemies.Add(newEnemy); //adds it to the ArrayList
            }
        displayEnemy();
	}

    void displayEnemy(){ //show the enemy that corresponds to the enemy in the ArrayList
        
        if ((int)enemies[0] == 1){ //display rock
            rock.SetActive(true);
        }
        if ((int)enemies[0] == 2){ //display paper
            paper.SetActive(true);
        }
        if ((int)enemies[0] == 3){ //display scissors
            scissors.SetActive(true);
        }
        
    }
}
