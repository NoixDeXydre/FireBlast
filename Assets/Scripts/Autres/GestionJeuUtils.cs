using UnityEngine;

/// <summary>
/// Op�rations suppl�mentaires apport�s en plus du controleur principal.
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
    /// Retourne le script GestionJeu initialis�.
    /// </summary>
    /// <returns>Le script GestionJeu</returns>
    public static GestionJeu GetScriptGestionJeu()
    {
        return comportementJeu.GetComponent<GestionJeu>();
    }
}
