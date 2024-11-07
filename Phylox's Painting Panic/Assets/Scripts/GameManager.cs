using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isGameOver = false;
    float timer = 300f;
    [SerializeField] TextMeshProUGUI money;
    [SerializeField] TextMeshProUGUI time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        time.text = "Time: " + (int)timer;
        if(timer <= 0)
        {
            isGameOver = true;
        }
    }
}
