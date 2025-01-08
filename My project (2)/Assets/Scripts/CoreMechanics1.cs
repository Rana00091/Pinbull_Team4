using System.Collections;
using UnityEngine;

namespace PinBall
{
    public class CoreMechanics : MonoBehaviour
    {
        [SerializeField] private Life lifeRef; // Reference to the Life component
        [SerializeField] private GameObject myBall; // Reference to the ball GameObject
        private Rigidbody2D RgBall; // Rigidbody2D component of the ball
        [SerializeField] private float springForce = 4f; // Force applied when hitting a spring
        [SerializeField] private float speedMultiplier = 3f; // Multiplier for increasing speed
        [SerializeField] private float slowMultiplier = 0.5f; // Multiplier for decreasing speed
        [SerializeField] private float launchForce = 60f; // Initial launch force
        [SerializeField] private float launchImpulseX = 200f; // X-axis impulse when pressing space
        [SerializeField] private float launchImpulseY = 200f; // Y-axis impulse when pressing space

        void Start()
        {

            // Assign the Life component to the reference
            lifeRef = FindObjectOfType<Life>();
            // Get the Rigidbody2D component attached to the ball
            RgBall = myBall.GetComponent<Rigidbody2D>();

            // Set Rigidbody2D properties
            RgBall.gravityScale = 1f; // Default gravity for proper ball behavior
            RgBall.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            RgBall.interpolation = RigidbodyInterpolation2D.Interpolate;
            RgBall.linearDamping = 0f; // Ensure no linear drag
            RgBall.angularDamping = 0.05f; // Small angular drag for smooth rotation

            // Start the coroutine to launch the ball after a slight delay
            StartCoroutine(DelayStart());
        }

        void Update()
        {
            // Launch the ball manually when pressing the space key
            if (Input.GetKeyDown("space"))
            {
                RgBall.AddForce(new Vector2(launchImpulseX, launchImpulseY), ForceMode2D.Impulse);
            }
        }

        private IEnumerator DelayStart()
        {
            // Delay the start of the launch for better gameplay flow
            yield return new WaitForSeconds(0.5f);
            RgBall.AddForce(new Vector2(0f, launchForce), ForceMode2D.Impulse);
            Debug.Log("Ball launched with initial force!");
        }

        private void OnTriggerEnter2D(Collider2D wall)
        {
            Debug.Log("Entered OnTriggerEnter2D with wall: " + wall.gameObject.name);
            if (wall.CompareTag("SpeedWall"))
            {
                IncreaseSpeed();
            }
            else if (wall.CompareTag("SlowWall"))
            {
                DecreaseSpeed();
            }
            else if (wall.CompareTag("Zapper"))
            {
                Debug.Log("Zapper has been triggered. Destroying the ball...");
                lifeRef.DecreaseLife();
                Destroy(gameObject); // Destroy the current ball instance
                Debug.Log("Ball destroyed!");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Spring"))
            {
                ApplySpringForce(collision);
            }
        }

        private void IncreaseSpeed()
        {
            AdjustSpeed(speedMultiplier);
        }

        private void DecreaseSpeed()
        {
            AdjustSpeed(slowMultiplier);
        }

        private void AdjustSpeed(float multiplier)
        {
            if (RgBall.linearVelocity.magnitude == 0)
            {
                RgBall.linearVelocity = new Vector2(0, 1) * multiplier;
            }
            else
            {
                Vector2 direction = RgBall.linearVelocity.normalized;
                float newSpeed = RgBall.linearVelocity.magnitude * multiplier;
                RgBall.linearVelocity = direction * newSpeed;
            }
            Debug.Log($"Speed adjusted with multiplier: {multiplier}");
        }

        private void ApplySpringForce(Collision2D spring)
        {
            RgBall.AddForce(-spring.contacts[0].normal * springForce, ForceMode2D.Impulse);
            Debug.Log("Spring force applied!");
        }
    }
}
