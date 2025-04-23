using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Charge et transitionne proprement 
/// chaque sc�ne du jeu.
/// </summary>
public class PermuteurScene : MonoBehaviour
{

    /// <summary>
    /// Lance le jeu principal
    /// </summary>
    public void LancerPartie()
    {
        SceneManager.LoadScene("Jeu");
    }

}
