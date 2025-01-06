using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector2(0f , -3.63f);
    }

    // Update is called once per frame
    void Update()
    { // condictions here -5.5 is for the bar not to cross walls 
        if(Input.GetKey("a")&& transform.position.x > -6f  ){

            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-10, 0f);
        }
        else if(Input.GetKey("d")&& transform.position.x < 6f ){

            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(10, 0f);
        }

        else {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, 0f);
        }
    }
}
