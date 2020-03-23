using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform player;
    public LayerMask playerLayerMask;

    public float fieldOfView = 90.0f;
    public float viewDistance = 1.0f;
    float speed = 3.0f;

    public Transform pathHolder;
    public Vector3[] path;
    public Vector3 currentWayPoint;
    public int wayPointIndex = 0;

    GuardBehavioralTree guardBehavioralTree;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        SetPath();
        guardBehavioralTree = new GuardBehavioralTree();
        guardBehavioralTree.SetAgent(this);
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        while (true)
        {
            guardBehavioralTree.Run();
            yield return null;
        }
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
}
