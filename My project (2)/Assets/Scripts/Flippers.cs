using UnityEngine;

public class Flippers : MonoBehaviour
{
  public bool Fliper;

    
    void Update()
    {
        if((Fliper && Input.GetKey(KeyCode.A)) || (!Fliper && Input.GetKey(KeyCode.D))){

            GetComponent<HingeJoint2D>().useMotor = true;
        }
        else {
            GetComponent<HingeJoint2D>().useMotor = false;
        }
    }
}
