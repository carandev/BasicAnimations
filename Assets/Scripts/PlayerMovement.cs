using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotationSpeed = 100.0f;

    private float forwardMovement = 0.0f;
    private float sidewaysMovement = 0.0f;

    // Reference to the character controller
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        forwardMovement = Input.GetAxis("Vertical") * speed;
        sidewaysMovement = Input.GetAxis("Horizontal") * rotationSpeed;

        Vector3 movement = new Vector3(sidewaysMovement, 0, forwardMovement);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
}
