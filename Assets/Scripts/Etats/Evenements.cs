using UnityEngine;

/// <summary>
/// Singleton rassemblant des évènements pouvant être déclenchées.
/// </summary>
public class Evenements
{

    // Evènements

    public event SourisClicEnfonce OnSourisClicEnfonce;
    public event SourisClicRelache OnSourisClicRelache;

    // Délégations

    public delegate void SourisClicEnfonce(bool estEnfoncementStatique);
    public delegate void SourisClicRelache(Vector2 directionRelachement);

    /// <summary>
    /// Instance globale deds évènements
    /// </summary>
    private static Evenements instanceEvenements;

    /// <returns>Une instance du singleton</returns>
    public static Evenements GetInstanceEvenements()
    {

        if (instanceEvenements != null)
        {
            return instanceEvenements;
        }

        instanceEvenements = new();
        return instanceEvenements;
    }

    // Méthodes levier

    /// <summary>
    /// Méthode à déclencher si le clic de la souris est enfoncé.
    /// </summary>
    /// <param name="estEnfoncementStatique">Défini si le joueur glisse la souris en même temps</param>
    public void CallbackSourisClicEnfonce(bool estEnfoncementStatique)
    {
        OnSourisClicEnfonce?.Invoke(estEnfoncementStatique);
    }

    /// <summary>
    /// Méthode à déclencher si le clic de la souris est relâché.
    /// </summary>
    /// <param name="directionRelachement">Direction dans laquelle la souris à relâché le clic</param>
    public void CallbackSourisClicRelache(Vector2 directionRelachement)
    {
        OnSourisClicRelache?.Invoke(directionRelachement);
    }
}
