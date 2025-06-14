using UnityEngine;
using UnityEngine.SceneSystem;

/// <summary>
/// Singleton g�rant le chargement des sc�nes,
/// accompagn� d'un menu de chargement.
/// </summary>
public class GestionnaireScenes : MonoBehaviour
{

    /// <summary>
    /// True si une sc�ne est en chargement, sinon false.
    /// </summary>
    private bool estSceneEnChargement = false;

    /// <summary>
    /// Seule instance de la classe.
    /// </summary>
    private static GestionnaireScenes instanceGestionnaireScenes;

    /// <returns>Une instance du gestionnaire de sc�nes</returns>
    public static GestionnaireScenes GetInstance()
    {

        if (instanceGestionnaireScenes == null)
        {
            GameObject objetSingleton = new GameObject("GestionnaireScenes");
            instanceGestionnaireScenes = objetSingleton.AddComponent<GestionnaireScenes>();
            DontDestroyOnLoad(objetSingleton);
        }

        return instanceGestionnaireScenes;
    }

    /// <summary>
    /// Charge et permute la sc�ne en ne gardant que la nouvelle.
    /// </summary>
    /// <param name="scene">Sc�ne � permuter</param>
    /// <param name="ecranChargement">
    /// L'�cran de chargement � montrer 
    /// pendant le chargement
    /// </param>
    public void PermuterScene(SceneReference scene, GameObject ecranChargement)
    {

        if (!estSceneEnChargement)
        {

            estSceneEnChargement = true;
            var ecranChargementCharge = Instantiate(ecranChargement).GetComponent<SceneLoader>();
            DontDestroyOnLoad(ecranChargementCharge);

            var levier = Scenes.LoadSceneAsync(scene).WithLoadingScreen(ecranChargementCharge);
            levier.onCompleted += () => { estSceneEnChargement = false; };
        }
    }
}