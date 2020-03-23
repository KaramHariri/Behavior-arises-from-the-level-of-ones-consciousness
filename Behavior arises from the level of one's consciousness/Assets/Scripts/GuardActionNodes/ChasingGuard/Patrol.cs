public class Patrol : Node
{
    public Guard guard;
    
    public override NodeState Run()
    {
        NodeState nodeState = NodeState.RUNNING;
        guard.FollowPath();
        return nodeState;
    }
}
