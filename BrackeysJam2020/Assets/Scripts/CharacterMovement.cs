using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    public CharacterStats characterStats;
    public InputManager inputManager;
    private float InputX;
    private float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float verticalVel;
    private Vector3 moveVector;
    public float allowPlayerRotation = 0.1f;
    public bool isGrounded;
    private Camera cam;
    Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        cam = Camera.main; 
        if (cam == null)
        {
            Debug.LogError("The cam is null");
        }
        inputManager = InputManager.instance;
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("The CharacterController in CharacterMovment is NULL");
        }
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }
    void MoveCharacter()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * characterStats.movementSpeed);
        }

        //If you don't need the character grounded then get rid of this part.
        isGrounded = controller.isGrounded;
        if (isGrounded) {
        	verticalVel -= 0;
        } else {
        	verticalVel -= .05f * Time.deltaTime;
        }
        moveVector = new Vector3 (0, verticalVel, 0);
        controller.Move (moveVector);
        //inefficient
        /*
        if (inputManager.GetKeyUp(KeybindingActions.MoveForward)) { moveDirection.z = 0; }
        if (inputManager.GetKeyUp(KeybindingActions.MoveBack)) { moveDirection.z = 0; }
        if (inputManager.GetKeyUp(KeybindingActions.MoveLeft)) { moveDirection.x = 0; }
        if (inputManager.GetKeyUp(KeybindingActions.MoveRight)) { moveDirection.x = 0; }
        if (characterController.isGrounded) {
            //Vector3 moveDirection = new Vector3(0, 0, 0);
            if (inputManager.GetKey(KeybindingActions.MoveForward)) { moveDirection.z = 1; }
            if (inputManager.GetKey(KeybindingActions.MoveBack)) { moveDirection.z = -1; }
            if (inputManager.GetKey(KeybindingActions.MoveLeft)) { moveDirection.x = -1; }
            if (inputManager.GetKey(KeybindingActions.MoveRight)) { moveDirection.x = 1; }
            moveDirection = moveDirection.normalized;
            moveDirection *= characterStats.movementSpeed;
            if (inputManager.GetKeyDown(KeybindingActions.Jump))
            {
                moveDirection.y = characterStats.movementSpeed;
            }
        }
        else
        {
            if (inputManager.GetKey(KeybindingActions.MoveForward)) { moveDirection.z = 1f; }
            if (inputManager.GetKey(KeybindingActions.MoveBack)) { moveDirection.z = -.5f; }
            if (inputManager.GetKey(KeybindingActions.MoveLeft)) { moveDirection.x = -.5f; }
            if (inputManager.GetKey(KeybindingActions.MoveRight)) { moveDirection.x = .5f; }
        }
        moveDirection.y -= characterStats.weight * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        */
    }
}
