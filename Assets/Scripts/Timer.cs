using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private GameManager gameManager;
    private Button button;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        ClickToPlay();
    }
    void ClickToPlay()
    {
        button.onClick.AddListener(SetTimer);
        
    }
    void SetTimer()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(2.5f);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            TimeCounting();
        }
        Debug.Log("is game active:" + gameManager.isGameActive);
    }

    void TimeCounting()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
            gameManager.GameOver();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        //timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);//timer voi phut va giay
        timerText.text = string.Format("Time:{0:00}", remainingTime);
        timerText.fontSize = 40;
        Debug.Log("Time Counting is active");
    }
    
   
}
