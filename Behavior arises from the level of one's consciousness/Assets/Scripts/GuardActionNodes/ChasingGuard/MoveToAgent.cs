public class MoveToAgent : Node
{
    public Guard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.FAILURE;
        //if (guard.transform.position != guard.targetToMoveTo.position)
        //{
        //    guard.MoveToTarget();
        //    nodeState = NodeState.RUNNING;
        //}
        //else
        //    nodeState = NodeState.SUCCESS;
        return nodeState;
    }
}