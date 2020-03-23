using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedGuard : MonoBehaviour
{
    public Transform player;
    public LayerMask playerLayerMask;

    public float fieldOfView = 90.0f;
    public float viewDistance = 15.0f;
    public float shootingRange = 10.0f;
    public float fireRate = 0.5f;
    public float speed = 2.0f;
    public float accuracy = 1.0f;

    public Transform pathHolder;
    public Vector3[] path;
    public Vector3 currentWayPoint;
    public int wayPointIndex = 0;

    ArmedGuardBehavioralTree armedGuardBehavioralTree;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        SetPath();
        armedGuardBehavioralTree = new ArmedGuardBehavioralTree();
        armedGuardBehavioralTree.SetAgent(this);
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        while (true)
        {
            armedGuardBehavioralTree.Run();
            yield return null;
        }
    }

    void SetPath()
    {
        path = new Vector3[pathHolder.childCount];
        for (int i = 0; i < path.Length; i++)
        {
            Vector3 wayPointPosition = new Vector3(pathHolder.GetChild(i).position.x, 0.5f, pathHolder.GetChild(i).position.z);
            path[i] = wayPointPosition;
        }
        currentWayPoint = path[wayPointIndex];
    }

    public void FollowPath()
    {
        transform.LookAt(currentWayPoint);
        if (transform.position == currentWayPoint)
        {
            wayPointIndex = (wayPointIndex + 1) % path.Length;
        }
        currentWayPoint = path[wayPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint, Time.deltaTime * speed);
    }

    public void Chase()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }

    public bool CheckPlayerInSight()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < fieldOfView * 0.5f && direction.magnitude < viewDistance)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, direction.normalized, out raycastHit, viewDistance, playerLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    public bool CanFire()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0.0f)
        {
            fireRate = 0.5f;
            return true;
        }
        return false;
    }

    public void Shoot()
    {
        int probability = Random.Range(0, 100);
        if (probability >= 70)
            accuracy = Random.Range(-1.0f, 1.0f);
        else
            accuracy = 0.0f;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 randDirection = new Vector3(directionToPlayer.x + accuracy, directionToPlayer.y, directionToPlayer.z);
        RaycastHit raycastHit;
        Debug.DrawRay(transform.position, randDirection * 30.0f, Color.red, 0.5f);
        if (Physics.Raycast(transform.position, randDirection, out raycastHit, 30.0f, playerLayerMask))
        {
            Debug.Log("Hit");
        }

        transform.LookAt(player);
    }
}
