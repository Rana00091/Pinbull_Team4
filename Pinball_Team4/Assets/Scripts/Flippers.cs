using UnityEngine;

public class Flippers : MonoBehaviour
{
    public bool Right;
    public bool Left;

    void Update()
    {
        switch (true)
        {
            case true when Left && Input.GetKey(KeyCode.A):
                GetComponent<HingeJoint2D>().useMotor = true;
                break;

            case true when Right && Input.GetKey(KeyCode.D):
                GetComponent<HingeJoint2D>().useMotor = true;
                break;

            default:
                GetComponent<HingeJoint2D>().useMotor = false;
                break;
        }
    }
}
