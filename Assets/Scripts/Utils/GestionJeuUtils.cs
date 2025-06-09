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
    private static GameObject comportementJeu;

    /// <returns>Le script GestionJeu</returns>
    public static GestionJeu GetScriptGestionJeu()
    {

        if (comportementJeu != null)
        {
            return comportementJeu.GetComponent<GestionJeu>();
        }

        comportementJeu = GameObject.Find(NomObjetComportementJeu);
        return comportementJeu.GetComponent<GestionJeu>();
    }
}
