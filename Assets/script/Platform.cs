using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    bool moveing;
    public float speed;

    private void FixedUpdate() {
        if(transform.position.x > 6f)
        {
            moveing = false;
        }
        if(transform.position.x <-5)
        {
            moveing = true;
        }

        if(moveing)
        {
            transform.position = new Vector2(transform.position.x + speed * speed * Time.fixedDeltaTime, transform.position.y);
        }
        if(!moveing)
        {
            transform.position = new Vector2(transform.position.x - speed * speed * Time.fixedDeltaTime, transform.position.y);
        }
    }

}
