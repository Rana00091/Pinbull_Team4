using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
   // [SerializeField] GameObject Playerprefab;
    LevelLoader levelLoader;

    

    [Header ("Score")]
    public TMP_Text scoreText;
    int score = 0 ;
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text LoseText;
    [SerializeField] TMP_Text LevelText;
    int sceneLevel = 1;

    
     

    //public TMP_Text LevelText;

    // private LevelLoader levelLoader ;
     
    
    private void Awake() {

        LevelController[] objct = Object.FindObjectsOfType<LevelController>();

        if (objct.Length > 1){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {

        levelLoader = GameObject.FindObjectOfType<LevelLoader>();

        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
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
                score ++ ; 
                scoreText.text =score.ToString();

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

                RespawnPlayer(); 
            }


    }

    public void WinStatment(){

          //  audioManager.PlayeMewo(audioManager.Win);
            winText.gameObject.SetActive(true);

             Invoke("HideText", 2f);
    }

    public void LoseStatment(){
       // audioManager.PlayeMewo(audioManager.mewoDieClip);
        LoseText.gameObject.SetActive(true);

        Invoke("LoadEndGame", 2f);
        Invoke("HideText", 2f);
    }
    private void LoadEndGame(){
        //SceneManager.LoadScene("EndGame");


    }

    public void HideText(){
        sceneLevel++;
         winText.gameObject.SetActive(false);
         LoseText.gameObject.SetActive(false);
         
    }

    private void RespawnPlayer(){
        Vector3 resPos = new Vector3(0, -1, 0);
       // Instantiate(Playerprefab , resPos , Quaternion.identity);

    }
}
