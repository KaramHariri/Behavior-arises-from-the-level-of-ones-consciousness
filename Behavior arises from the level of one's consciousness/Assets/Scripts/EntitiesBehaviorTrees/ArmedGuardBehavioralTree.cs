using UnityEngine;

public class ArmedGuardBehavioralTree : MonoBehaviour
{
    SelectorNode rootNode = new SelectorNode();
    SequenceNode attackPlayer = new SequenceNode();
    PlayerIsVisibleToArmedGuardCheck playerVisibleCheckAction = new PlayerIsVisibleToArmedGuardCheck();
    MoveToShootingRange moveToShootingRange = new MoveToShootingRange();
    ShootPlayer shootPlayerAction = new ShootPlayer();
    ShootingTimer shootingTimer = new ShootingTimer();
    ArmedGuardPatrol patrol = new ArmedGuardPatrol();

    public ArmedGuardBehavioralTree()
    {
        rootNode.AddChild(attackPlayer);
        rootNode.AddChild(patrol);
        attackPlayer.AddChild(playerVisibleCheckAction);
        attackPlayer.AddChild(moveToShootingRange);
        attackPlayer.AddChild(shootingTimer);
        attackPlayer.AddChild(shootPlayerAction);
    }

    public void Run()
    {
        rootNode.Run();
    }

    public void SetAgent(ArmedGuard agent)
    {
        playerVisibleCheckAction.guard = agent;
        moveToShootingRange.guard = agent;
        patrol.guard = agent;
        shootingTimer.guard = agent;
        shootPlayerAction.guard = agent;
    }
}
