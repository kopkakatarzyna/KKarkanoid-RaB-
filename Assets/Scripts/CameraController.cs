using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition();

    }

    // Update is called once per frame
    void Update()
    {
        TransformCameraPosition();
    }

    public void CameraPosition()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = player.position - transform.position;
    }

    public void TransformCameraPosition()
    {
        transform.position = player.position - offset;
    }
}
