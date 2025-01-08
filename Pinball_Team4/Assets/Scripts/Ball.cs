using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    LevelController levelController ;
    AudioManager audioManager;
    Rigidbody2D Rb;
    [SerializeField] bool shoot;
    //[SerializeField] ParticleSystem particleSystemfire;

    
    void Start()
    {   
        


        levelController = FindAnyObjectByType<LevelController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Rb = GetComponent<Rigidbody2D>();

        //[Stops prefab for player]
        //particleSystemfire.Stop();

       StartCoroutine(DelayStart());
        
        
    }

    void Update()
    {

      /* if (Input.GetKeyDown("space")){

            Rb.AddForce(new Vector2(0f, 60f), ForceMode2D.Impulse);
            
           

            //[Start prefab if needed]
            //particleSystemfire.Play();
            

          // StartCoroutine(StopFireEffectAfterDelay());
       }
       */
          
       
    }

              
/* this function playes prefab for 3 seconds 
    private IEnumerator StopFireEffectAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        particleSystemfire.Stop();
    }
*/

    private void OnCollisionEnter2D(Collision2D other) {

        /*if (other.gameObject.CompareTag("Shoot")) {
            shoot = true;
        }*/

        if(other.gameObject.tag == "Score500"){
        audioManager.PlayeSFX(audioManager.Coin);
        levelController.Increase500();
        }

        if(other.gameObject.tag == "Score100"){
            audioManager.PlayeSFX(audioManager.Coin);
        levelController.Increase();
        }
    }


    
    IEnumerator DelayStart(){
        //delay the stat of object # can be used with the spring effect 
        yield return new WaitForSeconds(2);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(250f, 250f));
        Rb.AddForce(new Vector2(0f, 55f), ForceMode2D.Impulse);

    }

    

        private void OnTriggerEnter2D(Collider2D other) {

            if(other.gameObject.tag =="Spring"){
                audioManager.PlayeSFX(audioManager.Fire);
                 Rb.AddForce(new Vector2(0f, 100f), ForceMode2D.Impulse);
                  

               
            }

            if(other.gameObject.tag=="Die"){

                audioManager.PlayeSFX(audioManager.DieClip);
                Destroy(gameObject);
                levelController.DecreaseLife();
                
            }
       
        
       

    }


}
