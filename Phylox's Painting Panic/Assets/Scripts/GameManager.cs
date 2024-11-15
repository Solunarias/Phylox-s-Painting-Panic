using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool isGameOver = false;
    float timer = 100f;
    float points = 0f;
    [SerializeField] TextMeshProUGUI money;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject rank;
    [SerializeField] GameObject playagain;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject fox;
    [SerializeField] GameObject top;
    [SerializeField] GameObject glasses;
    [SerializeField] GameObject hat;
    [SerializeField] Camera cam;
    GameObject UINPC;

    private List<GameObject> targets = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        rank.SetActive(false);
        playagain.SetActive(false);
        for (int i = 0; i < 9; i++)
        {
            SpawnNPC();
        }
        SpawnTargetNPC();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        time.text = "Time: " + (int)timer;
        money.text = "Money: $" + points;
        if (timer <= 0)
        {
            isGameOver = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "NPC")
                    {
                        if (hit.collider.gameObject.GetComponent<NPC>().IsActive())
                        {
                            if (hit.collider.gameObject.GetComponent<NPC>().IsTarget())
                            {
                                timer += 5f;
                                points += 50f;
                                Next();
                            }
                            else
                            {
                                timer -= 5f;
                            }
                        }
                    }
                }
            }
        }

        if (isGameOver)
        {
            gameover.SetActive(true);
            rank.SetActive(true);
            playagain.SetActive(true);
            if (points >= 0)
            {
                rank.GetComponent<TextMeshProUGUI>().text = "Rank: F \nNO MONEY, HOW'S PHYLOX GONNA EAT TONIGHT!!!";
                if (points >= 50)
                {
                    rank.GetComponent<TextMeshProUGUI>().text = "Rank: D \nPitiful, Phylox can barely feed his family with this";
                    if (points >= 200)
                    {
                        rank.GetComponent<TextMeshProUGUI>().text = "Rank: C \nGood, this will last Phylox at least a week";
                        if (points >= 400)
                        {
                            rank.GetComponent<TextMeshProUGUI>().text = "Rank: B \nGreat, Phylox could live a month off this";
                            if (points >= 600)
                            {
                                rank.GetComponent<TextMeshProUGUI>().text = "Rank: A \nAmazing, Phylox will be living in comfort for sure";
                                if (points >= 1000)
                                {
                                    rank.GetComponent<TextMeshProUGUI>().text = "Rank: S \nINCREDIBLE, Phylox will be living in luxury";
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            targets.Add(npc);
        }
        else if (selector == 1)
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            npc = Instantiate(dog);
            npc.GetComponent<SpriteRenderer>().color = randcolor;
            targets.Add(npc);
        }
        else
        {
            float red = Random.Range(0, 255) / 255f;
            float green = Random.Range(0, 255) / 255f;
            float blue = Random.Range(0, 255) / 255f;

            Color randcolor = new Color(red, green, blue);
            npc = Instantiate(fox);
            npc.GetComponent<SpriteRenderer>().color = randcolor;
            targets.Add(npc);
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
        UINPC = Instantiate(npc);
        UINPC.GetComponent<NPC>().MakeInactive();
        targets.Add(UINPC);
        UINPC.transform.parent = cam.transform;
        UINPC.transform.position = new Vector3(cam.transform.position.x + -6.5f,cam.transform.position.y + 2f, 0);
        UINPC.GetComponent<Renderer>().sortingOrder = 5;
        int children = UINPC.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            UINPC.transform.GetChild(i).GetComponent<Renderer>().sortingOrder = 6;
        }

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

    void Next()
    {
        for (int j = 0; j < targets.Count; j++)
        {
            Destroy(targets[j]);
        }
        targets.Clear();
        for (int i = 0; i < 9; i++)
        {
            SpawnNPC();
        }
        SpawnTargetNPC();
    }
}
