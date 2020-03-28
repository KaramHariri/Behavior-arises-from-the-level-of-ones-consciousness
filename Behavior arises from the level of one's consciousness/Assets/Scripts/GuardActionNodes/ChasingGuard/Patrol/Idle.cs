public class Idle : Node
{
    public Guard guard;
    public override NodeState Run()
    {
        NodeState nodeState = NodeState.FAILURE;
        float distance = UnityEngine.Vector3.Distance(guard.transform.position, guard.guardMovement.path[0]);
        if (distance <= guard.guardMovement.navMeshAgent.stoppingDistance && guard.guardMovement.idleTimer > 0 && guard.guardMovement.wayPointIndex == 0)
        {
            guard.guardMovement.idleTimer -= UnityEngine.Time.deltaTime;
            nodeState = NodeState.SUCCESS;
        }
        return nodeState;
    }
}