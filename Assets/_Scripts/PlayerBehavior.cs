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
        Rotation();

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
}


