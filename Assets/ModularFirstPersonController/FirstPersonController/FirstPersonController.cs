using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    private Rigidbody rb;
    public Camera playerCamera;
    public float fov = 60f;
    public bool cameraCanMove = true;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;
    public bool lockCursor = true;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public bool enableZoom = true;
    public KeyCode zoomKey = KeyCode.Mouse1;
    public float zoomFOV = 30f;
    public float zoomStepTime = 5f;
    private bool isZoomed = false;

    public bool playerCanMove = true;
    public float walkSpeed = 5f;
    public float maxVelocityChange = 10f;
    private bool isWalking = false;

    public bool enableSprint = true;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public float sprintSpeed = 7f;
    public float sprintDuration = 5f;
    public float sprintCooldown = .5f;
    public float sprintFOV = 80f;
    private bool isSprinting = false;
    private float sprintRemaining;

    public bool enableJump = true;
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpPower = 5f;
    private bool isGrounded = false;

    public bool enableCrouch = true;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public float crouchHeight = .75f;
    public float speedReduction = .5f;
    private bool isCrouched = false;
    private Vector3 originalScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
        playerCamera.fieldOfView = fov;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide cursor
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Unlock if pressing Escape
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetMouseButtonDown(0)) // Lock back if clicking
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (cameraCanMove)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);
            transform.localEulerAngles = new Vector3(0, yaw, 0);
            playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        }

        if (enableZoom && Input.GetKeyDown(zoomKey) && !isSprinting)
            isZoomed = !isZoomed;

        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView,
            isZoomed ? zoomFOV : isSprinting ? sprintFOV : fov,
            zoomStepTime * Time.deltaTime);

        if (enableJump && Input.GetKeyDown(jumpKey) && isGrounded)
            Jump();

        if (enableCrouch && Input.GetKeyDown(crouchKey))
            Crouch();

        CheckGround();
    }

    void FixedUpdate()
    {
        if (!playerCanMove) return;

        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        isWalking = (targetVelocity.x != 0 || targetVelocity.z != 0) && isGrounded;

        if (enableSprint && Input.GetKey(sprintKey) && sprintRemaining > 0f)
        {
            targetVelocity = transform.TransformDirection(targetVelocity) * sprintSpeed;
            isSprinting = true;
            if (isCrouched) Crouch();
        }
        else
        {
            targetVelocity = transform.TransformDirection(targetVelocity) * walkSpeed;
            isSprinting = false;
        }

        Vector3 velocity = rb.linearVelocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void CheckGround()
    {
        Vector3 origin = transform.position - Vector3.up * transform.localScale.y * .5f;
        isGrounded = Physics.Raycast(origin, Vector3.down, .75f);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
            if (isCrouched) Crouch();
        }
    }

    private void Crouch()
    {
        if (isCrouched)
        {
            transform.localScale = originalScale;
            walkSpeed /= speedReduction;
        }
        else
        {
            transform.localScale = new Vector3(originalScale.x, crouchHeight, originalScale.z);
            walkSpeed *= speedReduction;
        }
        isCrouched = !isCrouched;
    }
}