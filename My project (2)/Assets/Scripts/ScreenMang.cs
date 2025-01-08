using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenMang : MonoBehaviour
{
   
   public void OnClickStart(){

    SceneManager.LoadScene("SampleScene");

    //[use when levels created]
    //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    
   // SceneManager.LoadScene(sceneIndex +1 );

   }

    public void OnClickPlay(){

    SceneManager.LoadScene("SampleScene");
   }

    public void OnClickReturn(){

    SceneManager.LoadScene("StartMenu");
   }
   
    public void OnClickTutorial(){

    SceneManager.LoadScene("Tutorial");
   }

   public void onclickExite(){
      UnityEditor.EditorApplication.isPlaying = false;
       Application.Quit();
   }
    
}
