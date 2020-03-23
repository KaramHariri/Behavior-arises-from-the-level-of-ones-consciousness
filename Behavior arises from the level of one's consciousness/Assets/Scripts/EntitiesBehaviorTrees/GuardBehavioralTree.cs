public class GuardBehavioralTree
{
    SelectorNode rootNode = new SelectorNode();
    SequenceNode chasePlayerNode = new SequenceNode();
    PlayerIsVisibleCheck playerVisibleCheckAction = new PlayerIsVisibleCheck();
    ChasePlayer chasePlayerAction = new ChasePlayer();
    Patrol patrol = new Patrol();

    public GuardBehavioralTree()
    {
        rootNode.AddChild(chasePlayerNode);
        rootNode.AddChild(patrol);
        chasePlayerNode.AddChild(playerVisibleCheckAction);
        chasePlayerNode.AddChild(chasePlayerAction);
    }

    public void Run()
    {
        rootNode.Run();
    }

    public void SetAgent(Guard agent)
    {
        playerVisibleCheckAction.guard = agent;
        chasePlayerAction.guard = agent;
        patrol.guard = agent;
    }
}
