public class ArmedGuardPatrol : Node
{
    public ArmedGuard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.RUNNING;
        guard.FollowPath();
        return nodeState;
    }
}
