using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb; // Reference Rigidbody component as rb

    public float forwardForce = 8000f; //rate of moving forward
    public float handling = 120f; //rate of moving side to side

    public bool moveRight;
    public bool moveLeft;

    void Start() {

        moveRight = false;
        moveLeft = false;

    }

    void Update()
    {
        DetermineStrafeInput();
    }

    void FixedUpdate()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Add a constant forward force on the z-axis
        Strafe();
        CheckFall();
        
    }

    public void DetermineStrafeInput() //determine if there is a strafe input
    {
        if( Input.GetKey("a") ) { moveLeft = true; }
        if( Input.GetKey("d") ) { moveRight = true; }
    }

    public void Strafe() //makes the player strafe if there is a strafe input
    {
        if( moveLeft == true) {

            rb.AddForce(-handling * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }

        if( moveRight == true) {

            rb.AddForce(handling* Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }

        moveRight = false;
        moveLeft = false;
    }

    public void CheckFall()
    {
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}