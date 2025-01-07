using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoreMechanics : MonoBehaviour
{
    
        [SerializeField] public GameObject ball; // Reference to the ball GameObject
        private Rigidbody2D RgBall; // Rigidbody2D component of the ball
        [SerializeField] public float springForce = 4f; // Force applied when the ball hits a spring
        [SerializeField] public float Speed = 3f;
        [SerializeField] public float slowSpeed = 0.5f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Get Rigidbody component attached to the ball
            RgBall = ball.GetComponent<Rigidbody2D>();

           
           
        }

        // Update is called once per frame
        void Update()
        {   //Keep the ball moving only in the Y-axis by zeroing out X velocity
          // RgBall.linearVelocity = new Vector2(0, RgBall.linearVelocity.y);

            
        }
        // Here is handling initial launch for the ball at the start
      
        // Handle collisions with different walls (SpeedWall, SlowWall, Spring)

        private void OnTriggerEnter2D(Collider2D Wall) {

              //checking if the ball hits that object with this tag
            if (Wall.gameObject.CompareTag("SpeedWall"))
            {
                Speedy();
            }
            //checking if the ball hits that object with this tag
            else if (Wall.gameObject.CompareTag("SlowWall"))
            {
                Slow();
            }
            //checking if the ball hits that object with this tag
            else if (Wall.gameObject.CompareTag("Spring"))
            {
                //Spring(Wall);
            }
        }
     
        private void Speedy()
    {
        if (RgBall.linearVelocity.magnitude == 0)
        {
            // Apply a default direction if velocity is zero
            RgBall.linearVelocity = new Vector2(0, 1) * Speed;
        }
        else
        {
            Vector2 direction = RgBall.linearVelocity.normalized; // Normalize the velocity vector
            float newSpeed = RgBall.linearVelocity.magnitude * Speed; // Calculate the new speed
            RgBall.linearVelocity = direction * newSpeed; // Apply the increased speed
        }
        Debug.Log("Speed increased!");
    }

    private void Slow()
    {
        if (RgBall.linearVelocity.magnitude == 0)
        {
            // Apply a default direction if velocity is zero
            RgBall.linearVelocity = new Vector2(0, 1) * slowSpeed;
        }
        else
        {
            Vector2 direction = RgBall.linearVelocity.normalized; // Normalize the velocity vector
            float newSpeed = RgBall.linearVelocity.magnitude * slowSpeed; // Calculate the new speed
            RgBall.linearVelocity = direction * newSpeed; // Apply the decreased speed
        }
        Debug.Log("Speed decreased!");
    }
    }


