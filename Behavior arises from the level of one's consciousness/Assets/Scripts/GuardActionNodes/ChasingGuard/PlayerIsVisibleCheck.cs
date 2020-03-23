public class PlayerIsVisibleCheck : Node
{
    public Guard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.FAILURE;
        if(guard.CheckPlayerInSight())
        {
            nodeState = NodeState.SUCCESS;
        }
        return nodeState;
    }
}
