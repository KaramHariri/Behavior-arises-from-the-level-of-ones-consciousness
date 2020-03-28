public class TalkToOtherGuardCheck : Node
{
    public Guard guard;
    public override NodeState Run()
    {
        NodeState nodeState = NodeState.FAILURE;
        float distance = UnityEngine.Vector3.Distance(guard.transform.position, guard.guardMovement.path[0]);
        if (distance <= guard.guardMovement.navMeshAgent.stoppingDistance && guard.guardMovement.talkingTimer > 0 && guard.guardMovement.CloseGuardNearby())
        {
            UnityEngine.Debug.Log("finish Checking");
            nodeState = NodeState.SUCCESS;
        }
        return nodeState;
    }
}