using UnityEngine;

namespace Platformer397
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        [SerializeField] private Rigidbody rb;
        private Vector3 movement;

        [SerializeField] private float moveSpeed = 200f;
        [SerializeField] private float rotationSpeed = 200f;

        [SerializeField] private Transform mainCam;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            mainCam = Camera.main.transform;
        }
        private void Start()
        {
            input.EnablePlayerActions();
        }
        private void OnEnable()
        {
            input.Move += GetMovement;
        }
        private void OnDisable()
        {
            input.Move -= GetMovement;
        }
        private void FixedUpdate()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movement;
            if (adjustedDirection.magnitude > 0f)
            {
                // Handle the rotation and movement
                HandleRotation(adjustedDirection);
                HandleMovement(adjustedDirection);
            }
            else
            {
                // not change the rotation or movement, but need to apply rigidbody Y movement for gravity
                rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            }
        }
        private void HandleMovement(Vector3 adjustedMovement)
        {
            var velocity = adjustedMovement * moveSpeed * Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        }
        private void HandleRotation(Vector3 adjustedMovement)
        {
            var targetRotation = Quaternion.LookRotation(adjustedMovement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        private void GetMovement(Vector2 move)
        {
            movement.x = move.x;
            movement.z = move.y;
        }
    }
}
