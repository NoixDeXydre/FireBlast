using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Charge et transitionne proprement chaque scène du jeu.
/// </summary>
public class PermuteurScene : MonoBehaviour
{

    /// <summary>
    /// Une opération async en cours.
    /// </summary>
    private AsyncOperation operationAsync;

    /// <summary>
    /// Script de l'écran de chargement (à référencer une fois)
    /// </summary>
    private GestionEcranChargement scriptEcranChargement;

    /// <summary>
    /// Scène active, en excluant le chargement d'écran.
    /// </summary>
    private Scene sceneActive;

    /// <summary>
    /// Lance la scène correspondante.
    /// </summary>
    public void ChargerEtLancerScene(string nomScene)
    {
        StartCoroutine(ChargerEtLancerSceneCoroutine(nomScene));
    }

    private IEnumerator ChargerEtLancerSceneCoroutine(string nomScene)
    {

        sceneActive = SceneManager.GetActiveScene();
        yield return StartCoroutine(AfficherEcranChargementEnAttente());

        // Charge en arrière plan.
        operationAsync = SceneManager.LoadSceneAsync(nomScene, LoadSceneMode.Additive);
        operationAsync.allowSceneActivation = false;

        while (operationAsync.progress < .9f)
        {
            yield return null;
        }

        // La scène peut être changée si l'écran de chargement a fini son animation.
        scriptEcranChargement.SetEcranVisible();
        scriptEcranChargement.OnEcranTotalementVisible += () => ActiverScene(nomScene);
    }

    private void ActiverScene(string nomScene)
    {

        // On évite d'autres appels
        scriptEcranChargement.OnEcranTotalementVisible -= () => ActiverScene(null);

        // Autorise la scène à être active.
        operationAsync.allowSceneActivation = true;

        // On décharge la scène précédente.
        SceneManager.UnloadSceneAsync(sceneActive);

        StartCoroutine(FinaliserChangementDeScene(nomScene));
    }

    private IEnumerator FinaliserChangementDeScene(string nomScene)
    {
        // 7. Attendre la fin de l'activation
        while (!operationAsync.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nomScene));

        scriptEcranChargement.SetEcranNonVisible();
    }

    private IEnumerator AfficherEcranChargementEnAttente()
    {
        Scene ecranChargement = SceneManager.GetSceneByName("EcranChargement");

        // Charger la scène d'écran de chargement si pas déjà chargée
        if (!ecranChargement.isLoaded)
        {
            AsyncOperation chargementEcran = SceneManager.LoadSceneAsync("EcranChargement", LoadSceneMode.Additive);
            while (!chargementEcran.isDone)
            {
                yield return null;
            }

            ecranChargement = SceneManager.GetSceneByName("EcranChargement");

            // On doit récupérer le script sans faire confiance à la hiérarchie d'Unity.
            int indexGo = 0;
            GameObject[] gameObjectsScene = ecranChargement.GetRootGameObjects();
            while (scriptEcranChargement == null)
            {
                scriptEcranChargement = gameObjectsScene[indexGo++].GetComponent<GestionEcranChargement>();
            }
        }

        // Mettre la scène écran de chargement active
        SceneManager.SetActiveScene(ecranChargement);
    }
}
