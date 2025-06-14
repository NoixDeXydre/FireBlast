using AnnulusGames.SceneSystem;
using UnityEngine;

/// <summary>
/// Permet de changer de sc�ne facilement.
/// </summary>
public class SimplePermutateurScene : MonoBehaviour
{

    /// <summary>
    /// Ecran de chargement affich�.
    /// </summary>
    public GameObject ecranChargement;

    /// <summary>
    /// Sc�ne pr�te � �tre permut�e.
    /// </summary>
    public SceneReference scenePermutation;

    /// <summary>
    /// Permute sur la sc�ne cibl�e.
    /// </summary>
    public void PermuterScene()
    {
        GestionnaireScenes.GetInstance().PermuterScene(scenePermutation, ecranChargement);
    }
}
