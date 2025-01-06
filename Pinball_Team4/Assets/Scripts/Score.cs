using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TMP_Text scoreText;
    int score = 0 ;
  

      public void Increase ()
    {
        score ++ ; 
        scoreText.text =score.ToString();

    }
}
