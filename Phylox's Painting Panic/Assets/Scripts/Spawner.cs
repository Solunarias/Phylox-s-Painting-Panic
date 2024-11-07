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
        SpawnTargetNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject SpawnNPC()
    {
        float selector = Random.Range(0, 3);
        GameObject npc = new GameObject();
        if (selector == 0)
        {
            float red = Random.Range(0, 255)/255f;
            float green = Random.Range(0, 255)/255f;
            float blue = Random.Range(0, 255)/255f;

            Color randcolor = new Color(red, green, blue);
            npc = Instantiate(cat);
            npc.GetComponent<SpriteRenderer>().color = randcolor;
        }
        else if (selector == 1)
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            npc = Instantiate(dog);
            npc.GetComponent<SpriteRenderer>().color = randcolor;
        }
        else
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            npc = Instantiate(fox);
            npc.GetComponent<SpriteRenderer>().color = randcolor;
        }
        selector = Random.Range(0, 2);
        if (selector == 0)
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            GameObject accesory = new GameObject();
            accesory = Instantiate(top);
            accesory.transform.parent = npc.transform;
            accesory.GetComponent<SpriteRenderer>().color = randcolor;
        }
        selector = Random.Range(0, 2);
        if (selector == 0)
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            GameObject accesory = new GameObject();
            accesory = Instantiate(glasses);
            accesory.transform.parent = npc.transform;
            accesory.GetComponent<SpriteRenderer>().color = randcolor;
        }
        selector = Random.Range(0, 2);
        if (selector == 0)
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            GameObject accesory = new GameObject();
            accesory = Instantiate(hat);
            accesory.transform.parent = npc.transform;
            accesory.GetComponent<SpriteRenderer>().color = randcolor;
        }
        RelocateNPC(npc);
        return npc;
    }

    void SpawnTargetNPC()
    {
        GameObject npc = SpawnNPC();
        npc.GetComponent<NPC>().MakeTarget();
    }

    void RelocateNPC(GameObject npc)
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
        npc.transform.position = new Vector3(randX, randy, 0);
    }
}
