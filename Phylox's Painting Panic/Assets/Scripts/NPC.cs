using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private bool isTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTarget()
    {
        return isTarget;
    }

    public void MakeTarget()
    {
        isTarget = true;
    }
}
