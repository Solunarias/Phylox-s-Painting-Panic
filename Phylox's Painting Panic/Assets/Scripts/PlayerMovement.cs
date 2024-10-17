using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed;

    [SerializeField] private Rigidbody2D rb2d;

    float moveInputHorizontal;
    float moveInputVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputHorizontal = Input.GetAxis("Horizontal");
        moveInputVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveInputHorizontal * runSpeed, moveInputVertical * runSpeed);
    }
}
