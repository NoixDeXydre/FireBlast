using UnityEngine;

public class ChargementEcran : MonoBehaviour
{
    public  void OnCompleted()
    {
        Debug.Log("completed");
    }

    public  void OnLoadCompleted()
    {
        Debug.Log("load completed");
    }

    public  void OnLoading(float progress)
    {
        Debug.Log("loading...");
    }
}