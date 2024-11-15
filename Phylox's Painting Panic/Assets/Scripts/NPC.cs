using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private bool isTarget = false;
    private bool isActive = true;
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

    public bool IsActive()
    {
        return isActive;
    }

    public void MakeTarget()
    {
        isTarget = true;
    }

    public void MakeInactive()
    {
        isActive = false;
    }
}
