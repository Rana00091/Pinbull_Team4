using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour
{
    [Header ("lIFE")]
    ScreenMang sceneManager;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public int lifecount = 3; 


    [Header ("referance")]
    public Canvas gameplayCanvas;
    AudioManager audioManager;
    [SerializeField] GameObject Playerprefab;
    LevelLoader levelLoader;
    [SerializeField] public Vector3 resPos;
    Ball ball;

    

    [Header ("Score")]
    public TMP_Text scoreText;
    int score = 0 ;
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text LoseText;
    [SerializeField] TMP_Text LevelText;
    int sceneLevel = 1;
    private Color originalColor;
    
     

    //public TMP_Text LevelText;

    // private LevelLoader levelLoader ;
     
    
    private void Awake() {
        
        /*LevelController[] objct = Object.FindObjectsOfType<LevelController>();

        if (objct.Length > 1){
            Destroy(gameObject);
        }*/

        //DontDestroyOnLoad(gameObject);
    }

    private void Start() {

        //levelLoader = GameObject.FindObjectOfType<LevelLoader>();
        ball = FindAnyObjectByType<Ball>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
         originalColor = scoreText.color;
        
        //levelnum =levelLoader.sceneLevel;
    }

    private void Update() {

        //[TO hide canvase in start and end screen]
       // levelLoader.CheckGameplayCanvasVisibility();
       // UpdateLevelText();
         
       // LevelText.text = levelnum.ToString();
    }


         public void UpdateLevelText()
            {
                LevelText.text = $"Level {sceneLevel}";
                
            }
 
         public void Increase ()
            {
                CheckWin();
                if(score < 2000){
                score +=100 ; 
                scoreText.text =score.ToString();
                scoreText.color = Color.green;
                StartCoroutine(ResetColor());
            
                }
        

            }
            public void Increase500 ()
            {
                CheckWin();
                if(score < 2000){
                score +=500 ; 
                scoreText.text =score.ToString();
                scoreText.color = Color.yellow;
                StartCoroutine(ResetColor());
                
                }
             

            }

        public void CheckWin(){
            if (score >= 2000) {

            WinStatment();

            }

            else{return;}
        }

           public void WinStatment(){

           audioManager.PlayeSFX(audioManager.Win);
           //Destroy(ball.gameObject);
           //Destroy(Playerprefab.gameObject);
            winText.gameObject.SetActive(true);
            
            Invoke("LoadEndGame", 1f);
             Invoke("HideText", 1f);

    }
        public void DecreaseLife (){
        
            lifecount -- ;
            if(lifecount == 2){
                Heart3.SetActive(false);
            }
            if(lifecount == 1){
                Heart2.SetActive(false);
            }
            if(lifecount == 0){
                Heart1.SetActive(false);
                LoseStatment();
            }
            if(lifecount > 0){

                 Invoke("RespawnPlayer", 2f); 
            }


    }

 

    public void LoseStatment(){
        audioManager.PlayeSFX(audioManager.DieClip);
        LoseText.gameObject.SetActive(true);

        Invoke("LoadEndGame", 2f);
        Invoke("HideText", 2f);
    }
    private void LoadEndGame(){
        SceneManager.LoadScene("EndGame");


    }

    public void HideText(){
        sceneLevel++;
         winText.gameObject.SetActive(false);
         LoseText.gameObject.SetActive(false);
         
    }

    private void RespawnPlayer(){
         
        Instantiate(Playerprefab , resPos , Quaternion.identity);

    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f); 
        scoreText.color = originalColor;     
    }
}
