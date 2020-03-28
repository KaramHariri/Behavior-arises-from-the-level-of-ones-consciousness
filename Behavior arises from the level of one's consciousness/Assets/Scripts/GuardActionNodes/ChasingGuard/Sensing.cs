using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensing : MonoBehaviour, IPlayerSoundObserver
{
    public bool playerInSight;
    public bool canHear = false;
    public bool suspicious = false;

    Vector3 personalLastPlayerSightingPosition;
    Vector3 previousPlayerSightingPosition;

    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public SphereCollider sensingCollider;

    private void Awake()
    {
        personalLastPlayerSightingPosition = GuardStaticVariables.playerLastSightingPosition;
        previousPlayerSightingPosition = GuardStaticVariables.playerLastSightingPosition;
        sensingCollider = GetComponent<SphereCollider>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        PlayerSoundSubject.AddObserver(this);
    }

    public bool CheckPlayerInSight()
    {
        if (playerInSight)
            return true;

        return false;
    }

    public bool PlayerWasDetected()
    {
        if (GuardStaticVariables.playerLastSightingPosition != previousPlayerSightingPosition)
        {
            personalLastPlayerSightingPosition = GuardStaticVariables.playerLastSightingPosition;
            return true;
        }
        previousPlayerSightingPosition = GuardStaticVariables.playerLastSightingPosition;
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == PlayerController.playerTransform.gameObject)
        {
            playerInSight = true;
            canHear = true;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < GuardStaticVariables.fieldOfViewAngle * 0.5f)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(transform.position, direction.normalized, out raycastHit, sensingCollider.radius))
                {
                    if (raycastHit.collider.gameObject == PlayerController.playerTransform.gameObject)
                    {
                        playerInSight = true;
                        GuardStaticVariables.playerLastSightingPosition = PlayerController.position;
                    }
                }
            }

            // hearing
            if (suspicious)
            {
                if (CalculateLength(PlayerController.position) <= sensingCollider.radius)
                {
                    suspicious = false;
                    Debug.Log("Hearing something");
                    personalLastPlayerSightingPosition = PlayerController.position;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.playerTransform.gameObject)
        {
            playerInSight = false;
            canHear = false;
        }
    }

    float CalculateLength(Vector3 targetPosition)
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        if (navMeshAgent.enabled)
            navMeshAgent.CalculatePath(targetPosition, path);
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;


        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0.0f;

        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        //for (int i = 0; i < path.corners.Length - 1; i++)
        //    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        return pathLength;
    }

    public void Notify(SoundType soundType)
    {
        if (soundType == SoundType.WALKING)
        {
            suspicious = true;
        }
        else if (soundType == SoundType.DISTRACTION)
        {
            Debug.Log("Distraction");
        }
    }
}
