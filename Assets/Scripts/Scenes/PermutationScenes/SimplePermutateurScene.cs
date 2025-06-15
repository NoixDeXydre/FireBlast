using UnityEngine;

/// <summary>
/// Permet de changer de scène facilement.
/// </summary>
public class SimplePermutateurScene : MonoBehaviour
{

    /// <summary>
    /// Scène prête à être permutée.
    /// </summary>
    public SceneReference scenePermutation;

    /// <summary>
    /// Permute sur la scène ciblée.
    /// </summary>
    public void PermuterScene()
    {
        GestionnaireScenes.GetInstance().PermuterScene(scenePermutation);
    }
}
