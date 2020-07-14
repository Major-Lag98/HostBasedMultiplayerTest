using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerUnit : NetworkBehaviour
{
    

    // Update is called once per frame
    void Update() // no need to write code to let people know where obj location is because networkTransform componenet handles it already
    {
        if (hasAuthority == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
        }
    }
}
