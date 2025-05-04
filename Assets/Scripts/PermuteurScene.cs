using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Charge et transitionne proprement 
/// chaque scène du jeu.
/// </summary>
public class PermuteurScene : MonoBehaviour
{

    public GameObject a;

    /// <summary>
    /// Lance le jeu principal
    /// </summary>
    public void LancerPartie()
    {
        StartCoroutine(AfficherEcranChargementEnAttente());
        //SceneManager.LoadScene("Jeu");
    }

    private IEnumerator AfficherEcranChargementEnAttente()
    {

        Scene ecranChargement = SceneManager.GetSceneByName("EcranChargement");
        if (!ecranChargement.isLoaded)
        {

            AsyncOperation operationAsync 
                = SceneManager.LoadSceneAsync("EcranChargement", LoadSceneMode.Additive);

            while (!operationAsync.isDone)
            {
                yield return null;
            }

            ecranChargement = SceneManager.GetSceneByName("EcranChargement");
        }

        SceneManager.SetActiveScene(ecranChargement);

        GestionEcranChargement test = ecranChargement.GetRootGameObjects()[2].GetComponent<GestionEcranChargement>();
        test.SetEcranVisible();
    }
}
