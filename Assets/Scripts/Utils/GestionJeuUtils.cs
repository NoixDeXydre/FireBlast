using UnityEngine;

/// <summary>
/// Opérations supplémentaires apportés en plus du controleur principal.
/// </summary>
public static class GestionJeuUtils
{

    /// <summary>
    /// Nom du GameObject contenant GestionJeu.
    /// </summary>
    private const string NomObjetComportementJeu = "ComportementJeu";

    /// <summary>
    /// L'objet contenant le script principal de la partie.
    /// </summary>
    private static readonly GameObject comportementJeu = GameObject.Find(NomObjetComportementJeu);

    /// <summary>
    /// Retourne le script GestionJeu initialisé.
    /// </summary>
    /// <returns>Le script GestionJeu</returns>
    public static GestionJeu GetScriptGestionJeu()
    {
        return comportementJeu.GetComponent<GestionJeu>();
    }
}
