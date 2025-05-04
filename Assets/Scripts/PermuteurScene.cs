using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Charge et transitionne proprement chaque scène du jeu.
/// </summary>
public class PermuteurScene : MonoBehaviour
{

    /// <summary>
    /// Informe si une scène est en train de charger.
    /// </summary>
    private bool estEnChargement;

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

    private void Start()
    {
        estEnChargement = false;
        sceneActive = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// Lance la scène correspondante.
    /// </summary>
    /// <param name="nomScene">Nom de la scène à charger</param>
    public void ChargerEtLancerScene(string nomScene)
    {

        // On vérifie si une scène est en chargement avant.
        if (!estEnChargement)
        {
            StartCoroutine(ChargerEtLancerSceneCoroutine(nomScene));
        }
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

    private IEnumerator AfficherEcranChargementEnAttente()
    {

        // Restera en cache si fait une deuxième fois.
        Scene ecranChargement = SceneManager.GetSceneByName("EcranChargement");
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

    private IEnumerator ChargerEtLancerSceneCoroutine(string nomScene)
    {

        // Mise à jour des informations que l'on possède.
        estEnChargement = true;

        // On déclenche l'écran de chargement pour faire patienter l'utilisateur.
        yield return StartCoroutine(AfficherEcranChargementEnAttente());

        // Charge en arrière plan la scène demandée jusqu'à un certain seuil.
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

    private IEnumerator FinaliserChangementDeScene(string nomScene)
    {

        // On termine totalement le chargement de la scène.
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
