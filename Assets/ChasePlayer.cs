using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 3;

    public bool teleport;
    public int teleportSpeed;

    private bool isRunning;

    void Start()
    {
    }

    void Update()
    {

        transform.LookAt(Player);
        if(teleport)
        {
            if (Vector3.Distance(transform.position, Player.position) >= MinDist && !isRunning)
            {
                StartCoroutine(ExecuteAfterTime(teleportSpeed));
            }
        }

        else
        {
            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }

        }

    }

    IEnumerator ExecuteAfterTime(float teleportSpeed)
    {
        isRunning = true;

        yield return new WaitForSeconds(teleportSpeed);
        print(teleportSpeed);

        transform.position = (transform.position + Player.position) / 2;
        
        isRunning = false;
    }
}
