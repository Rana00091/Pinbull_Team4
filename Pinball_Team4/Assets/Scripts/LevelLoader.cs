using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelLoader : MonoBehaviour
{
    
    
    
    LevelController levelController;
    Canvas  gameplayCanvas;

     //[Header("Level")]
     
    // public TMP_Text LevelText;


        void Start()
    {
        levelController = GameObject.FindObjectOfType<LevelController>();
        gameplayCanvas = FindAnyObjectByType<LevelController>().gameplayCanvas;

        
        //UpdateLevelText();
        //CheckGameplayCanvasVisibility();
        
    }

    private void Update() {
        
       //CheckGameplayCanvasVisibility();
        
    }
  

  

  /* public void decutBriks(){
    
    if()
    {
       
       //Invoke("NextLevel", 2f);

    }

   }
   public void NextLevel()
   {
    

    int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    if(sceneIndex +1 < SceneManager.sceneCountInBuildSettings){
        SceneManager.LoadScene(sceneIndex + 1);
    }
    else {
        SceneManager.LoadScene("EndGame");
    }
   


   }

   public void CheckGameplayCanvasVisibility(){

    string currentSceneName = SceneManager.GetActiveScene().name;

       if (currentSceneName == "EndGame" || currentSceneName == "StartMenu") 
        {
            gameplayCanvas.gameObject.SetActive(false); // Hide canvase 
        }

        else{
            gameplayCanvas.gameObject.SetActive(true); // Show canvas
        }


   }*/


}
