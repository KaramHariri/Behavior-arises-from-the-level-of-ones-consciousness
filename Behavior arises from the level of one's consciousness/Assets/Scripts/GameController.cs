using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 playerLastSightingPosition = new Vector3(1000.0f, 1000.0f, 1000.0f);
    public Vector3 resetPlayerPosition = new Vector3(1000.0f, 1000.0f, 1000.0f);

    public Guard[] chasingGuards;
    public ArmedGuard[] armedGuards;

    //#region Subject Implementation
    //public List<IPlayerSoundObserver> playerSoundObservers;

    //public void AddObserver(IPlayerSoundObserver observer)
    //{
    //    playerSoundObservers.Add(observer);
    //}

    //public void RemoveObserver(IPlayerSoundObserver observer)
    //{
    //    playerSoundObservers.Remove(observer);
    //}

    //void NotifyObserver()
    //{
    //    foreach(IPlayerSoundObserver observer in playerSoundObservers)
    //    {
    //        observer.Notify();
    //    }
    //}

    //#endregion

    private void Awake()
    {
        //FindAllChasingGuards();
        //FindAllArmedGuards();
    }

    void FindAllChasingGuards()
    {
        GameObject[] allChasingGuards = GameObject.FindGameObjectsWithTag("ChasingGuards");
        for(int i = 0; i < allChasingGuards.Length; i++)
        {
            chasingGuards[i] = allChasingGuards[i].GetComponent<Guard>();
        }
    }

    void FindAllArmedGuards()
    {
        GameObject[] allArmedGuards = GameObject.FindGameObjectsWithTag("ArmedGuard");
        for(int i = 0; i < allArmedGuards.Length; i++)
        {
            armedGuards[i] = allArmedGuards[i].GetComponent<ArmedGuard>();
        }
    }

    void PlayerThrewDistaction()
    {

    }

    void PlayerWalking()
    {

    }
}
