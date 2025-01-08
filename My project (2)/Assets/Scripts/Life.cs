using UnityEngine;
using UnityEngine.SceneManagement;

namespace PinBall
{
    public class Life : MonoBehaviour
    {
        //ScreenMang sceneManager;

        public GameObject Heart1;
        public GameObject Heart2;
        public GameObject Heart3;

        [SerializeField] public GameObject Playerprefab;

        public int lifecount = 3;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {


        }


        public void DecreaseLife()
        {

            lifecount--;
            if (lifecount == 2)
            {
                Heart3.SetActive(false);
            }
            if (lifecount == 1)
            {
                Heart2.SetActive(false);
            }
            if (lifecount == 0)
            {
                Heart1.SetActive(false);
                SceneManager.LoadScene("EndGame");
            }
            if (lifecount > 0)
            {

                RespawnPlayer();
            }


        }

        private void RespawnPlayer()
        {
            Vector2 resPos = new Vector2(9.16f, -6.4f);
            Instantiate(Playerprefab, resPos, Quaternion.identity);

        }
    }
}