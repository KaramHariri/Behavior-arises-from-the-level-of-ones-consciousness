public class ShootingTimer : Node
{
    public ArmedGuard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.RUNNING;
        if (guard.CanFire())
        {
            nodeState = NodeState.SUCCESS;
        }
        return nodeState;
    }
}
