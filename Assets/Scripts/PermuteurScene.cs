using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Charge et transitionne proprement chaque sc�ne du jeu.
/// </summary>
public class PermuteurScene : MonoBehaviour
{

    /// <summary>
    /// Informe si une sc�ne est en train de charger.
    /// </summary>
    private bool estEnChargement;

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

    private void Start()
    {
        estEnChargement = false;
        sceneActive = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// Lance la sc�ne correspondante.
    /// </summary>
    /// <param name="nomScene">Nom de la sc�ne � charger</param>
    public void ChargerEtLancerScene(string nomScene)
    {

        // On v�rifie si une sc�ne est en chargement avant.
        if (!estEnChargement)
        {
            StartCoroutine(ChargerEtLancerSceneCoroutine(nomScene));
        }
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

    private IEnumerator AfficherEcranChargementEnAttente()
    {

        // Restera en cache si fait une deuxi�me fois.
        Scene ecranChargement = SceneManager.GetSceneByName("EcranChargement");
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

    private IEnumerator ChargerEtLancerSceneCoroutine(string nomScene)
    {

        // Mise � jour des informations que l'on poss�de.
        estEnChargement = true;

        // On d�clenche l'�cran de chargement pour faire patienter l'utilisateur.
        yield return StartCoroutine(AfficherEcranChargementEnAttente());

        // Charge en arri�re plan la sc�ne demand�e jusqu'� un certain seuil.
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

    private IEnumerator FinaliserChangementDeScene(string nomScene)
    {

        // On termine totalement le chargement de la sc�ne.
        while (!operationAsync.isDone)
        {
            yield return null;
        }

        Scene sceneChargee = SceneManager.GetSceneByName(nomScene);
        sceneActive = sceneChargee;
        estEnChargement = false;

        SceneManager.SetActiveScene(sceneChargee);
        scriptEcranChargement.SetEcranNonVisible();
    }
}
