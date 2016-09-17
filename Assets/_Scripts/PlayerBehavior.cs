using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

        //Movement modifer applied to directional movemnt.
    public float playerSpeed = 4.0f;

    //What the current speed of our player is 
    private float currentSpeed;

    //The last movemnt than we´ve made
    private Vector3 lastMovement;

	// Use this for initialization
	void Start () {
        this.currentSpeed = 0.0f;
        this.lastMovement = new Vector3();	
	}
	
	// Update is called once per frame
	void Update () {
        //Rotate player to face mouse
        Rotation();

        //Move the player´s body
        Movment();

	}

    void Rotation(){
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        float dx = this.transform.position.x - worldPos.x;
        float dy = this.transform.position.y - worldPos.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        this.transform.rotation = rot;

    }

    //Will move the player based off of keys pressed
    void Movment()
    {
        Vector3 movement = new Vector3();
        //Check for input
        movement.x += Input.GetAxis("Horizontal");
        movement.y += Input.GetAxis("Vertical");
        /*
         *If we pressed multiple buttons, make sure we´re only
         *moving the same length.
         */
        movement.Normalize();
        //Check if we pressed anything
        if (movement.magnitude > 0)
        {
            //if we did, move in that direction 
            currentSpeed = playerSpeed;
            this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
            lastMovement = movement;
        }
        else
        {
            // Otherwise, move in the direction we were going
            this.transform.Translate(lastMovement * Time.deltaTime * this.currentSpeed, Space.World);
            //Slow down over time
            currentSpeed *= .9f;
        }
    }

   

}


