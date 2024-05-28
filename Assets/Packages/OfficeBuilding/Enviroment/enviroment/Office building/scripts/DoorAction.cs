using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour {
    private PlayerPoints playerPoints;

    void Start()
    {
        playerPoints = GetComponent<PlayerPoints>();
        if (playerPoints == null)
        {
            Debug.LogError("PlayerPoints script not found on player.");
        }
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);

            if (hit.transform.tag == "door")
            {
                DoorWithPoints doorWithPoints = hit.transform.gameObject.GetComponent<DoorWithPoints>();
                if (doorWithPoints != null)
                {
                    doorWithPoints.TryOpenDoor();
                }
                else
                {
                    Door door = hit.transform.gameObject.GetComponent<Door>();
                    if (door != null)
                    {
                        door.ActionDoor();
                    }
                }
            }

            if (hit.collider.gameObject.name == "Button floor 1")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 1");
            }
            if (hit.collider.gameObject.name == "Button floor 2")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 2");
            }
            if (hit.collider.gameObject.name == "Button floor 3")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 3");
            }
            if (hit.collider.gameObject.name == "Button floor 4")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 4");
            }
            if (hit.collider.gameObject.name == "Button floor 5")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 5");
            }
            if (hit.collider.gameObject.name == "Button floor 6")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 6");
            }
        }	
	}
}
