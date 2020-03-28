public class PlayerInSightCheck : Node
{
    public Guard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.FAILURE;
        if(guard.sensing.CheckPlayerInSight())
        {
            nodeState = NodeState.SUCCESS;
        }
        return nodeState;
    }
}
