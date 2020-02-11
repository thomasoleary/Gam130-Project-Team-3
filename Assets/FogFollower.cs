using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogFollower : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    // Start is called before the first frame update
    public float speed = 6f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
}
