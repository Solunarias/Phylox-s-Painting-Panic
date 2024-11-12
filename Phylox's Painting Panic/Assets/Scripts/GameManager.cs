using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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

        if (Input.GetMouseButton(0))
        {
            Collider2D hit;
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            hit = Physics2D.OverlapCircle(screenPosition, 1f);
            if (hit != null)
            {
                Debug.Log(hit.name);
            }

            Debug.Log(worldPosition);
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(worldPosition, Vector3.up, 1f);
        }

    }
}
