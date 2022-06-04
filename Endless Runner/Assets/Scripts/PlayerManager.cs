using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPannel;
    public static bool gameIsActivated;
    public GameObject tapToStartText;
   
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        gameIsActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            Time.timeScale = 0;
            GameOverPannel.SetActive(true);
        }
        
        if (SwipeManager.tap)
        {
            gameIsActivated = true;
            Destroy(tapToStartText);
        }
    }
    

}
