using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CharacterController : MonoBehaviour
{
    #region "Global Variables"
    [Header("Control Values")]
    public float moveSpeed = 5f;
    public float turretRotationSpeed = 1f;

    private Rigidbody2D rigidBody;
    private Camera cam;
    private Vector2 movement;
    private Vector2 mousePos;
    #endregion

    #region "Driving Methods"
    private void Start()
    {
        Initialisation();
    }
           

    // Update is called once per frame
    void Update()
    {
        HorizontalAndVerticalInput();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }    

    void FixedUpdate()
    {
        MouseControls();
    }
    #endregion

    #region "Extracted Methods"
    private void Initialisation()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }
    private void HorizontalAndVerticalInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void MouseControls()
    {
        //Moves the character to a new vector2 times moveSpeed and the fixedDeltaTime 
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Creates another vector2 that deals with where the cgaracter is looking
        Vector2 lookDirection = mousePos - rigidBody.position;

        //Atan2 finds the angle from the x axis to the directional vector(the mouse position)
        //Rad2Deg changes into degrees and then we subtract 90 to make sure it's what we need.
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        //Delays the rotation to give a more Mecha feel
        float delayedRotation = turretRotationSpeed * Time.fixedDeltaTime;

        //uses the above created variable to drive the rotation on the Rigidbody2d
        rigidBody.rotation = Mathf.Lerp(rigidBody.rotation, angle, delayedRotation );
    }
    #endregion
}
