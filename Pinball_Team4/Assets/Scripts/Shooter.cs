using UnityEngine;

public class Shooter : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player") {

 }
}
}
