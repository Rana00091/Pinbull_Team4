using UnityEngine;

public class CoreMechanics : MonoBehaviour
{
    [SerializeField] public GameObject ball;
    private Rigidbody2D rgBall;
    [SerializeField] public float springForce=4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgBall = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgBall.angularVelocity = new Vector2(0, rgBall.angularVelocity.y);
    }

    private void OnCollisionEnter(Collision Wall)
    {
        if (Wall.gameObject.CompareTag("SpeedWall")) {
            Speedy();
        }
        else if (Wall.gameObject.CompareTag("SlowWall"))
        {
            Slow();
        }
        else if (Wall.gameObject.CompareTag("Spring"))
        {
            Spring();
        }
    }
    private void Speedy() {
        Vector2 direction = rgBall.velocity.normalized;
        float newSpeed = rgBall.velocity.magnitude * 1.5f; // Use 1.5f for float literal
        rgBall.velocity = direction * newSpeed;
        Debug.Log("Speed increased!");

    }
    private void Slow() {

        Vector2 direction = rgBall.velocity.normalized;
        float newSpeed = rgBall.velocity.magnitude * 0.5f;
        rgBall.velocity = direction * newSpeed;
    }
    private void Spring() {

        rgBall.AddForce(Vector2.up * springForce, ForceMode2D.Impulse);
    }
}
