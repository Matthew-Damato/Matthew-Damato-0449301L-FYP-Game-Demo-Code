using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement1 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed;
    public int PointTotal = 0;

    // public float mouseSensitivity = 10f;
    // public float speed = 100f;


    public Text pointDisplay;


    
    // Start is called before the first frame update
    void Start()
    {

    }


    public bool Varientrule = false;

    // Update is called once per frame
    void Update()
    {


        // float mouseX = Input.GetAxisRaw("Mouse X");
        // if (mouseX < 0f)
        // {
        //     Debug.Log("Mouse moved to the left!");
        //     transform.Rotate(Vector3.up, -speed * Time.deltaTime *2);
        // }
        // if (mouseX > 1f)
        // {
        //     Debug.Log("Mouse moved to the right!");
        //     transform.Rotate(Vector3.up, speed * Time.deltaTime);
        // }

        if (PointTotal > 30)
        {
            Varientrule = true;
        }


        pointDisplay.text = PointTotal.ToString();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input axis
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Apply the movement direction to the player's position
        transform.position += movementDirection * playerSpeed * Time.deltaTime/10;
    }

    void OnCollisionEnter(Collision collision) 
    {
        //As player gains points, they move faster, and as they lose points, they move slower.
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Answer" ) 
        {
            Debug.Log("Collided 2");
            playerSpeed = playerSpeed+5.5f;
            PointTotal = PointTotal+1;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collided 5");
            playerSpeed = playerSpeed-5.5f;
            PointTotal = PointTotal-1;
            Destroy(collision.gameObject);
        }
 
    }
 
}

