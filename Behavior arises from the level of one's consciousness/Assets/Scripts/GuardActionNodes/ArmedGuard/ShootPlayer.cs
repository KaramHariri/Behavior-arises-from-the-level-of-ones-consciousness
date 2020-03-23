public class ShootPlayer : Node
{
    public ArmedGuard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.RUNNING;
        guard.Shoot();
        return nodeState;
    }
}