using UnityEngine;

/// <summary>
/// Contr�leur de la logique et 
/// de l'affichage de donn�es du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    /// <summary>
    /// Initialise la logique m�tier, les controleurs
    /// et l'affichage du jeu.
    /// </summary>
    private void Awake()
    {

        // Remet les variables de la partie � z�ro.
        EtatsJeu.NullifierInstance(); 
    }

    /// <summary>
    /// Met � jour les composants
    /// n�cessitant le delta.
    /// </summary>
    private void Update()
    {

        // Le taux de raffraichissement n'est jamais bon sur Android.
        #if UNITY_ANDROID
            Application.targetFrameRate = 60;
        #endif
    }
}
