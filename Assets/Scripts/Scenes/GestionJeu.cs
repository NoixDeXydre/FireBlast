using UnityEngine;

/// <summary>
/// Contrôleur de la logique et 
/// de l'affichage de données du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    /// <summary>
    /// Initialise la logique métier, les controleurs
    /// et l'affichage du jeu.
    /// </summary>
    private void Awake()
    {

        // Remet les variables de la partie à zéro.
        EtatsJeu.NullifierInstance(); 
    }

    /// <summary>
    /// Met à jour les composants
    /// nécessitant le delta.
    /// </summary>
    private void Update()
    {

        // Le taux de raffraichissement n'est jamais bon sur Android.
        #if UNITY_ANDROID
            Application.targetFrameRate = 60;
        #endif
    }
}
