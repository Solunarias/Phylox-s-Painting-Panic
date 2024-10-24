using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject cat;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject fox;
    [SerializeField] GameObject top;
    [SerializeField] GameObject glasses;
    [SerializeField] GameObject hat;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            SpawnNPC();
        }
        SpawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject NPCCreator()
    {
        float selector = Random.Range(0, 2);
        GameObject npc = new GameObject();
        if (selector == 0)
        {
            npc = GameObject.Instantiate(cat);
        }
        else if (selector == 1)
        {
            npc = GameObject.Instantiate(dog);
        }
        else
        {
            npc = GameObject.Instantiate(fox);
        }
        selector = Random.Range(0, 1);
        if (selector == 0)
        {
            GameObject.Instantiate(top).transform.parent = npc.transform;
        }
        selector = Random.Range(0, 1);
        if (selector == 0)
        {
            GameObject.Instantiate(glasses).transform.parent = npc.transform;
        }
        selector = Random.Range(0, 1);
        if (selector == 0)
        {
            GameObject.Instantiate(hat).transform.parent = npc.transform;
        }
        return npc;
    }

    void SpawnNPC()
    {
        float randX = Random.Range((float)-14.5, (float)14.5);
        float randy = 0;
        if ((randX >= -10.5 && randX <= -4.5) || (randX >= 4.5 && randX <= 10.5))
        {
            randy = 7;
            while((randy <= 11 && randy >= 4) || (randy <= -4 && randy >= -11))
            {
                randy = Random.Range(14, -14);
            }
        }
        else if (randX >= -2 && randX <= 2)
        {
            randy = 0;
            while (randy <= 2.5 && randy >= -2.5)
            {
                randy = Random.Range(14, -14);
            }
        }
        else
        {
            randy = Random.Range(14, -14);
        }
        Instantiate(NPCCreator(), new Vector3(randX, randy, 0), Quaternion.identity);
    }
}
