using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenMang : MonoBehaviour
{
   AudioManager  audioManager;
   private void Awake() {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }
   public void OnClickStart(){
       audioManager.PlayeSFX(audioManager.Click);
    SceneManager.LoadScene("SampleScene");

    //[use when levels created]
    //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    
   // SceneManager.LoadScene(sceneIndex +1 );

   }

    public void OnClickPlay(){
       audioManager.PlayeSFX(audioManager.Click);
    SceneManager.LoadScene("SampleScene");
    
   }

    public void OnClickReturn(){
      audioManager.PlayeSFX(audioManager.Click);
    SceneManager.LoadScene("StartMenu");
    
   }
   
    public void OnClickTutorial(){
       audioManager.PlayeSFX(audioManager.Click);
    SceneManager.LoadScene("Tutorial");
   
   }

   public void onclickExite(){
      audioManager.PlayeSFX(audioManager.Click);
      //UnityEditor.EditorApplication.isPlaying = false;
       Application.Quit();
   }
    
}
