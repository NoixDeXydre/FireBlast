using AnnulusGames.SceneSystem;
using UnityEngine;

/// <summary>
/// Permet de changer de scène facilement.
/// </summary>
public class SimplePermutateurScene : MonoBehaviour
{

    /// <summary>
    /// Ecran de chargement affiché.
    /// </summary>
    public GameObject ecranChargement;

    /// <summary>
    /// Scène prête à être permutée.
    /// </summary>
    public SceneReference scenePermutation;

    /// <summary>
    /// Permute sur la scène ciblée.
    /// </summary>
    public void PermuterScene()
    {
        GestionnaireScenes.GetInstance().PermuterScene(scenePermutation, ecranChargement);
    }
}
