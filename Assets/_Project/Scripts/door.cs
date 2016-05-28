﻿using UnityEngine;
using System.Collections.Generic;

public class door : MonoBehaviour {
    public Vector3 OpenPosition;
    public float OpenSpeed = 3;
    public bool DoorLocked;
    public List<GameObject> Listeners;

    private keys keyRing;
    private bool isOpening;

	// Use this for initialization
	void Start () {
        var player = GameObject.FindGameObjectWithTag("Player");
        keyRing = player.GetComponent<keys>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpening)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, OpenPosition, OpenSpeed * Time.deltaTime);

            if (Mathf.Approximately(transform.localPosition.y, OpenPosition.y))
            {
                isOpening = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(object damage)
    {
        Debug.Log("Door was shot");
        if (DoorLocked)
        {
            if (keyRing != null)
            {
                keyRing.UnlockDoor(gameObject);
            }
        }
        else
        {
            OpenDoor();
        }
    }

    public void Unlock()
    {
        DoorLocked = false;
        OpenDoor();
    }

    public void OpenDoor()
    {
        isOpening = true;
        Debug.Log("door.OpenDoor");

        Listeners.ForEach(l => {
            l.SendMessage("DoorOpened", SendMessageOptions.DontRequireReceiver);
        });
    }
}
