using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
