using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerConnectionObject : NetworkBehaviour
{
    public GameObject PlayerUnitPrefab;

    GameObject myPlayerUnit;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == false)
        {
            //this obj belongs to another player
            return;
        }


        Debug.Log("Spawning personal unit...");
        //Instantiate(PlayerUnitPrefab);
        CmdSpawnMyUnit();
    }



    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.V)) // V to spawn unit
        {
            CmdSpawnMyUnit();
        }
        if (Input.GetKeyDown(KeyCode.X)) // X to destroy unit
        {
            CmdDestroyMyUnit();
        }
    }

    [Command]
    void CmdSpawnMyUnit() // create a unit, cache it, give athority to client and let everyone else know it exists.
    {
        if (myPlayerUnit != null) //player should only spawn and controll one thing
        {
            return;
        }
        GameObject player = Instantiate(PlayerUnitPrefab);
        myPlayerUnit = player;
        NetworkServer.Spawn(player);
        player.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient); //spawn first then set athority or else it complains
        
    }

    [Command]
    void CmdDestroyMyUnit()
    {
        NetworkServer.Destroy(myPlayerUnit);
    }
}
