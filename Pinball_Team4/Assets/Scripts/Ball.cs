using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //LevelController levelController ;
   // AudioManager audioManager;
    Rigidbody2D Rb;
    //[SerializeField] ParticleSystem particleSystemfire;

    
    void Start()
    {   
        //levelController = FindAnyObjectByType<LevelController>();
//        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Rb = GetComponent<Rigidbody2D>();

        //[Stops prefab for player]
        //particleSystemfire.Stop();

        StartCoroutine(DelayStart());
        
        
    }

    void Update(){

       if (
            Input.GetKeyDown("space")){
            GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 200f));

            //[Start prefab if needed]
            //particleSystemfire.Play();
            

          // StartCoroutine(StopFireEffectAfterDelay());
       }
          
       
    }

              
/* this function playes prefab for 3 seconds 
    private IEnumerator StopFireEffectAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        particleSystemfire.Stop();
    }
*/
/*
    private void OnCollisionEnter2D(Collision2D other) {

     

     if(other.gameObject.tag == "Briks"){
      levelController.Increase();
     }
    }

    private void OnTriggerEnter2D(Collider2D other) {

       
        //audioManager.SFX
        levelController.DecreaseLife();
        Destroy(gameObject);

    }
    */
    IEnumerator DelayStart(){
        //delay the stat of object # can be used with the spring effect 
        yield return new WaitForSeconds(1);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(250f, 250f));
        Rb.AddForce(new Vector2(0f, 50f), ForceMode2D.Impulse);

    }


}
