using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

    public GameObject clouds;
    public float speed;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = clouds.transform.position;
        pos.x -= speed;
        clouds.transform.position = pos;

	}
}
