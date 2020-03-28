public class TalkToOtherGuard : Node
{
    public Guard guard;
    public override NodeState Run()
    {
        NodeState nodeState = NodeState.SUCCESS;

        UnityEngine.Debug.Log("talking");
        guard.guardMovement.StartTalking();
        guard.guardMovement.talkingTimer -= UnityEngine.Time.deltaTime;
        return nodeState;
    }
}