
public class ChasePlayer : Node
{
    public Guard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.SUCCESS;
        guard.guardMovement.ChasePlayer();
        if (guard.transform.position != PlayerController.position)
        {
            nodeState = NodeState.RUNNING;
        }
        else
            nodeState = NodeState.SUCCESS;
        return nodeState;
    }
}
