using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform cameraTarget;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f);
    }
}
