using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    GuardBehavioralTree guardBehavioralTree;
    public GuardMovement guardMovement;
    public Sensing sensing;

    private void Awake()
    {
        guardMovement = GetComponent<GuardMovement>();
        sensing = GetComponent<Sensing>();
    }

    void Start()
    {
        guardBehavioralTree = new GuardBehavioralTree();
        guardBehavioralTree.SetAgent(this);
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        while (true)
        {
            guardBehavioralTree.Run();
            yield return null;
        }
    }
}
