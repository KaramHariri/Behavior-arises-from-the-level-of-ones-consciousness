public class FollowPath : Node
{
    public Guard guard;
    
    public override NodeState Run()
    {
        NodeState nodeState = NodeState.SUCCESS;
        guard.guardMovement.ResetPatrolTimer();
        guard.guardMovement.ResetIdleTimer();
        guard.guardMovement.FollowPath();
        return nodeState;
    }
}