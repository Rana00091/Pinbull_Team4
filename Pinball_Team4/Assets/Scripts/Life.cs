using UnityEngine;
using UnityEngine.SceneManagement;
public class Life : MonoBehaviour
{
    //ScreenMang sceneManager;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    [SerializeField] GameObject Playerprefab;

    public int lifecount = 3; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
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
           SceneManager.LoadScene("EndGame");
        }
        if(lifecount > 0){

            RespawnPlayer(); 
        }


    }

    private void RespawnPlayer(){
        Vector3 resPos = new Vector3(0, -1, 0);
        Instantiate(Playerprefab , resPos , Quaternion.identity);

    }
}
