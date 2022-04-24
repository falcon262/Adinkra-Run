using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rBody;
    public Animator anim;
    public float forwardSpeed;
    public float jumpForce;
    int desiredLane = 1;
    public float distance = 4;

    public float lerpTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }


    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector3(rBody.velocity.x, rBody.velocity.y, forwardSpeed);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * distance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * distance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("isSliding");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
