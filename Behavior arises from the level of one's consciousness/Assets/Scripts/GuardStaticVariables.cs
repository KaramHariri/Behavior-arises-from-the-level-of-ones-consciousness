[System.Serializable]
public static class GuardStaticVariables
{
    [UnityEngine.Header("Timers")]
    public static float maxIdletimer = 5.0f;
    public static float maxTalkingTimer = 5.0f;

    [UnityEngine.Header("Speed")]
    public static float patrolSpeed = 1.0f;
    public static float chaseSpeed = 3.0f;
    public static float cautiousSpeed = 2.0f;

    [UnityEngine.Header("Sensing")]
    public static float fieldOfViewAngle = 90.0f;

    [UnityEngine.Header("Player Variables")]
    public static UnityEngine.Vector3 playerLastSightingPosition = new UnityEngine.Vector3(1000.0f, 1000.0f, 1000.0f);
    public static UnityEngine.Vector3 resetPlayerPosition = new UnityEngine.Vector3(1000.0f, 1000.0f, 1000.0f);
}
