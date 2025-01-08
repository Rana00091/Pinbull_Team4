using UnityEngine;

public class AudioManager : MonoBehaviour
{

    /// <summary>
    /// to use it , first make an instancr of class 
    /// AudioManager audioManager; 
    /// 
    /// " Add a tag Audio to the empty game object that you will assign this scrit to 
    /// then identify it in start function 
    /// audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    /// 
    /// then to call it for die ex: audioManager.PlayeSFX(audioManager.DieClip);
    /// 
    /// </summary>
    /// 

    [Header("Audio Source")]

    [SerializeField] AudioSource backgroundMusic;
    
    [SerializeField] AudioSource SFX;


    [Header("Audio Clip")]
    [SerializeField] AudioClip backgroundMusicClip;
    public AudioClip slimeClip;
    public AudioClip DieClip;
    public AudioClip Win ;
    public AudioClip Fire ;
    
    

    void Start()
    {
        backgroundMusic.clip = backgroundMusicClip ;
        backgroundMusic.volume = 0.3f ;
        backgroundMusic.Play();

    }

   public void PlayeSFX (AudioClip clip){
       
        SFX.PlayOneShot(clip);
        // only playes effects 

   }

}
