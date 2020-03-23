using UnityEngine;

public class MoveToShootingRange : Node
{
    public ArmedGuard guard;

    public override NodeState Run()
    {
        NodeState nodeState = NodeState.SUCCESS;
        
        if (Vector3.Distance(guard.transform.position, guard.player.position) > guard.shootingRange)
        {
            guard.Chase();
            nodeState = NodeState.RUNNING;
        }
        else
            nodeState = NodeState.SUCCESS;
        return nodeState;
    }
}
