using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    public Transform pathHolder;
    public Vector3[] path;
    public Vector3 currentWayPoint;
    public int wayPointIndex = 0;

    public float talkingTimer = 0.0f;
    public float idleTimer = 0.0f;
    
    [SerializeField]
    GameObject[] allGuard;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {
        allGuard = GameObject.FindGameObjectsWithTag("Guard");
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetPath();
    }

    public void FollowPath()
    {
        float distance = Vector3.Distance(transform.position, currentWayPoint);
        if (distance <= navMeshAgent.stoppingDistance)
        {
            wayPointIndex = (wayPointIndex + 1) % path.Length;
            if (wayPointIndex == 0)
                navMeshAgent.stoppingDistance = 0.1f;
            else
                navMeshAgent.stoppingDistance = 1.5f;
        }
        currentWayPoint = path[wayPointIndex];
        MoveTowardsTarget(currentWayPoint, GuardStaticVariables.patrolSpeed);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    void RotateTowardsTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, 30 * Time.deltaTime , 0.0f);
        Quaternion newRot = Quaternion.LookRotation(newDir.normalized, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot.normalized, Time.deltaTime * 2.0f);
    }

    void MoveTowardsTarget(Vector3 target, float speed)
    {
        Vector3 currentPosition = transform.position;

        float distance = Vector3.Distance(transform.position, target);
        if (distance > navMeshAgent.stoppingDistance)
        {
            RotateTowardsTarget(target);
            Vector3 movement = transform.forward * Time.deltaTime * speed;

            navMeshAgent.updateRotation = false;
            navMeshAgent.Move(movement);
        }
    }

    public void ChasePlayer()
    {
        RotateTowardsTarget(PlayerController.position);
        MoveTowardsTarget(PlayerController.position, GuardStaticVariables.chaseSpeed);
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

    public void ResetPatrolTimer()
    {
        talkingTimer = GuardStaticVariables.maxTalkingTimer;
    }

    public void ResetIdleTimer()
    {
        idleTimer = GuardStaticVariables.maxIdletimer;
    }

    public bool CloseGuardNearby()
    {
        float closestDistanceSquared = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject guard in allGuard)
        {
            if (guard != this.gameObject)
            {
                Vector3 directionToGuard = guard.transform.position - currentPosition;
                float distanceSquaredToGuard = directionToGuard.sqrMagnitude;
                if (distanceSquaredToGuard < closestDistanceSquared && distanceSquaredToGuard < 3.0f)
                {
                    closestDistanceSquared = distanceSquaredToGuard;
                    return true;
                }
            }
        }
        return false;
    }

    public void StartTalking()
    {
        // Play some kind of audio.
    }
}
