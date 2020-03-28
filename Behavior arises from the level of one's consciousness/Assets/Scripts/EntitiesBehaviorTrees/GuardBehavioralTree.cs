public class GuardBehavioralTree
{
    SelectorNode rootNode = new SelectorNode();

    //// Used in multiple Nodes.
    //Idle idle = new Idle();
    //Inverter playerWasDetectedInverter = new Inverter();
    //PlayerWasDetectedCheck playerWasDetectedCheck = new PlayerWasDetectedCheck();
    //MoveToAgent moveToAgent = new MoveToAgent();

    //// Player Visible
    //SequenceNode playerVisible = new SequenceNode();
    //PlayerInSightCheck playerInSightCheck = new PlayerInSightCheck();
    //ChasePlayer chasePlayer = new ChasePlayer();

    //// Player Was Detected
    //SequenceNode playerWasDetected = new SequenceNode();
    //MoveToLastSightingPosition moveToLastSightingPosition = new MoveToLastSightingPosition();

    //// Interact With Other Agents
    //SelectorNode interactWithOtherAgents = new SelectorNode();
    //// Sleeping Guard Detection.
    //SequenceNode sleepingGuardDetection = new SequenceNode();
    //SleepingGuardCheck sleepingGuardCheck = new SleepingGuardCheck();
    //WakeUpAgent wakeUpAgent = new WakeUpAgent();
    //// Talking To Other Agents.
    //SequenceNode talkToOtherAgent = new SequenceNode();
    //NearbyGuardCheck nearbyGuardCheck = new NearbyGuardCheck();

    // Suspicious
    //SelectorNode suspicious = new SelectorNode();
    //SequenceNode heardSomethingSuspicious = new SequenceNode();
    //SequenceNode foundKnockedOutGuard = new SequenceNode();
    //HearingSensing hearingSensingCheck = new HearingSensing();
    //SequenceNode suspiciousObjectDetected = new SequenceNode();
    //MoveToPosition moveToSuspiciousObjectPosition = new MoveToPosition();
    //Investigate investigate = new Investigate();
    //KnockedOutGuardCheck knockedOutGuardCheck = new KnockedOutGuardCheck();
    //SequenceNode knockedOutGuardDetected = new SequenceNode();
    //MoveToPosition moveToKnockedOutGuardPosition = new MoveToPosition();
    //WakeUpGuard wakeUpGuard = new WakeUpGuard();

    // Patrol
    SelectorNode patrol = new SelectorNode();
    SequenceNode InteractWithTheOtherGuard = new SequenceNode();
    TalkToOtherGuardCheck talkToOtherGuardCheck = new TalkToOtherGuardCheck();
    Succeeder talkToOtherGuardSucceeder = new Succeeder();
    TalkToOtherGuard talkToOtherGuard = new TalkToOtherGuard();
    Idle idle = new Idle();

    FollowPath followPath = new FollowPath();

    public GuardBehavioralTree()
    {
        //playerWasDetectedInverter.AddChild(playerWasDetected);
        //rootNode.AddChild(playerVisible);

        //// Player Visible.
        //playerVisible.AddChild(playerInSightCheck);
        //playerVisible.AddChild(chasePlayer);

        //// Player Was Detected.
        //rootNode.AddChild(playerWasDetected);
        //playerWasDetected.AddChild(playerWasDetectedCheck);
        //playerWasDetected.AddChild(moveToLastSightingPosition);
        //playerWasDetected.AddChild(idle);

        ////Interact With Other Agents.
        //rootNode.AddChild(interactWithOtherAgents);
        //// Sleeping Guards.
        //interactWithOtherAgents.AddChild(sleepingGuardDetection);
        //sleepingGuardDetection.AddChild(playerWasDetectedInverter);
        //sleepingGuardDetection.AddChild(sleepingGuardCheck);
        //sleepingGuardDetection.AddChild(moveToAgent);
        //sleepingGuardDetection.AddChild(wakeUpAgent);
        //// Talking To Other Guards.
        //interactWithOtherAgents.AddChild(talkToOtherAgent);
        //talkToOtherAgent.AddChild(playerWasDetectedInverter);
        //talkToOtherAgent.AddChild(nearbyGuardCheck);
        //talkToOtherAgent.AddChild(moveToAgent);
        //talkToOtherAgent.AddChild(idle);

        // Suspicious
        

        // Patrol
        rootNode.AddChild(patrol);
        patrol.AddChild(InteractWithTheOtherGuard);
        patrol.AddChild(idle);
        patrol.AddChild(followPath);
        InteractWithTheOtherGuard.AddChild(talkToOtherGuardCheck);
        InteractWithTheOtherGuard.AddChild(talkToOtherGuardSucceeder);
        talkToOtherGuardSucceeder.AddChild(talkToOtherGuard);
    }

    public void Run()
    {
        rootNode.Run();
    }

    public void SetAgent(Guard agent)
    {
        //playerInSightCheck.guard = agent;
        //chasePlayer.guard = agent;
        //patrolMovement.guard = agent;
        followPath.guard = agent;
        idle.guard = agent;
        talkToOtherGuardCheck.guard = agent;
        talkToOtherGuard.guard = agent;
    }
}
