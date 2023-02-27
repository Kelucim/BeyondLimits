using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // The speed at which the object will move
    public float speed = 50.0f;

    // The force of gravity when it is switched on
    public float gravity = 9.81f;

    // Whether gravity is currently switched on or off
    bool gravityOn = true;
    SpriteRenderer spriteFlip;

    private CharacterController playerController;
    private PlayerInput playerInput;
    Vector3 playerVelocity;

    // The InputAction that will be used for movement
    InputAction movementAction;

    // The InputAction that will be used for gravity switching
    InputAction gravityAction;

    //Checks if grounded
    public Transform groundedGOn;
    public Transform groundedGOff;
    public float gCheckDistance;
    public LayerMask groundMask;
    bool isGroundedGOn;
    bool isGroundedGOff;

    // Awake is called when the script is first enabled
    void Awake()
    {
        // Get the InputActions from the InputActionMap
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<CharacterController>();
        spriteFlip = GetComponent<SpriteRenderer>();
        movementAction = playerInput.actions["Movement"];
        gravityAction = playerInput.actions["Gravity"];
    }

    // Update is called once per frame
    void Update()
    {   
        //Check if player is on ground
        isGroundedGOn = Physics.CheckSphere(groundedGOn.position, gCheckDistance, groundMask);
        isGroundedGOff = Physics.CheckSphere(groundedGOff.position, gCheckDistance, groundMask);

        //Gravity ↓
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);   

        // Get the direction of movement from the InputAction
        Vector2 direction = playerInput.actions["Movement"].ReadValue<Vector2>();
        

        // Move the object in the direction of movement at the specified speed
        /// transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;
        playerController.Move(direction * speed * Time.deltaTime);

        // If the gravity switch input is triggered, switch gravity on or off
        if (gravityAction.triggered && isGroundedGOn)
        {
            gravityOn = !gravityOn;
        }
        else if(gravityAction.triggered && isGroundedGOff)
        {
            gravityOn = !gravityOn;
        }

        // Apply the appropriate force of gravity to the object
        if (gravityOn)
        {
            playerVelocity.y = -gravity;
            spriteFlip.flipY = false;
        }
        else if(!gravityOn)
        {
            playerVelocity.y = gravity;
            spriteFlip.flipY = true;
        }
    }
}
