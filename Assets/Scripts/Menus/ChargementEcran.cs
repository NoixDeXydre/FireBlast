using UnityEngine;
using AnnulusGames.SceneSystem;

public class ChargementEcran : LoadingScreen
{
    public override void OnCompleted()
    {
        Debug.Log("completed");
    }

    public override void OnLoadCompleted()
    {
        Debug.Log("load completed");
    }

    public override void OnLoading(float progress)
    {
        Debug.Log("loading...");
    }
}