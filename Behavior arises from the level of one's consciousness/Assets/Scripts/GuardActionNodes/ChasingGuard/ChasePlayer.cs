public class ChasePlayer : Node
{
    public Guard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.SUCCESS;
        guard.Chase();
        if (guard.transform.position != guard.player.position)
        {
            nodeState = NodeState.RUNNING;
        }
        else
            nodeState = NodeState.SUCCESS;
        return nodeState;
    }
}
