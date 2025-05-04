using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Charge et transitionne proprement chaque sc�ne du jeu.
/// </summary>
public class PermuteurScene : MonoBehaviour
{

    /// <summary>
    /// Une op�ration async en cours.
    /// </summary>
    private AsyncOperation operationAsync;

    /// <summary>
    /// Script de l'�cran de chargement (� r�f�rencer une fois)
    /// </summary>
    private GestionEcranChargement scriptEcranChargement;

    /// <summary>
    /// Sc�ne active, en excluant le chargement d'�cran.
    /// </summary>
    private Scene sceneActive;

    /// <summary>
    /// Lance la sc�ne correspondante.
    /// </summary>
    public void ChargerEtLancerScene(string nomScene)
    {
        StartCoroutine(ChargerEtLancerSceneCoroutine(nomScene));
    }

    private IEnumerator ChargerEtLancerSceneCoroutine(string nomScene)
    {

        sceneActive = SceneManager.GetActiveScene();
        yield return StartCoroutine(AfficherEcranChargementEnAttente());

        // Charge en arri�re plan.
        operationAsync = SceneManager.LoadSceneAsync(nomScene, LoadSceneMode.Additive);
        operationAsync.allowSceneActivation = false;

        while (operationAsync.progress < .9f)
        {
            yield return null;
        }

        // La sc�ne peut �tre chang�e si l'�cran de chargement a fini son animation.
        scriptEcranChargement.SetEcranVisible();
        scriptEcranChargement.OnEcranTotalementVisible += () => ActiverScene(nomScene);
    }

    private void ActiverScene(string nomScene)
    {

        // On �vite d'autres appels
        scriptEcranChargement.OnEcranTotalementVisible -= () => ActiverScene(null);

        // Autorise la sc�ne � �tre active.
        operationAsync.allowSceneActivation = true;

        // On d�charge la sc�ne pr�c�dente.
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

        // Charger la sc�ne d'�cran de chargement si pas d�j� charg�e
        if (!ecranChargement.isLoaded)
        {
            AsyncOperation chargementEcran = SceneManager.LoadSceneAsync("EcranChargement", LoadSceneMode.Additive);
            while (!chargementEcran.isDone)
            {
                yield return null;
            }

            ecranChargement = SceneManager.GetSceneByName("EcranChargement");

            // On doit r�cup�rer le script sans faire confiance � la hi�rarchie d'Unity.
            int indexGo = 0;
            GameObject[] gameObjectsScene = ecranChargement.GetRootGameObjects();
            while (scriptEcranChargement == null)
            {
                scriptEcranChargement = gameObjectsScene[indexGo++].GetComponent<GestionEcranChargement>();
            }
        }

        // Mettre la sc�ne �cran de chargement active
        SceneManager.SetActiveScene(ecranChargement);
    }
}
