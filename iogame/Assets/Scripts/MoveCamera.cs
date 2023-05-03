using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject player;
    private Vector3 _camPos;
    // Update is called once per frame
    private void Update()
    {
        _camPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        gameObject.transform.position = _camPos;
    }
}
