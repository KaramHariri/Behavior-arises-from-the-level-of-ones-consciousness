using System.Collections.Generic;

public static class PlayerSoundSubject
{
    public static List<IPlayerSoundObserver> observers = new List<IPlayerSoundObserver>();

    public static void AddObserver(IPlayerSoundObserver observer)
    {
        observers.Add(observer);
    }

    public static void RemoveObserver(IPlayerSoundObserver observer)
    {
        observers.Remove(observer);
    }

    public static void NotifyObservers(SoundType soundType)
    {
        foreach (IPlayerSoundObserver observer in observers)
        {
            observer.Notify(soundType);
        }
    }
}
