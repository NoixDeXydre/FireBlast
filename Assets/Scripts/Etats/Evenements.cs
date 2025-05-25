using UnityEngine;

/// <summary>
/// Singleton rassemblant des �v�nements pouvant �tre d�clench�es.
/// </summary>
public class Evenements
{

    // Ev�nements

    public event SourisClicEnfonce OnSourisClicEnfonce;
    public event SourisClicRelache OnSourisClicRelache;

    // D�l�gations

    public delegate void SourisClicEnfonce(bool estEnfoncementStatique);
    public delegate void SourisClicRelache(Vector2 directionRelachement);

    /// <summary>
    /// Instance globale deds �v�nements
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

    // M�thodes levier

    /// <summary>
    /// M�thode � d�clencher si le clic de la souris est enfonc�.
    /// </summary>
    /// <param name="estEnfoncementStatique">D�fini si le joueur glisse la souris en m�me temps</param>
    public void CallbackSourisClicEnfonce(bool estEnfoncementStatique)
    {
        OnSourisClicEnfonce?.Invoke(estEnfoncementStatique);
    }

    /// <summary>
    /// M�thode � d�clencher si le clic de la souris est rel�ch�.
    /// </summary>
    /// <param name="directionRelachement">Direction dans laquelle la souris � rel�ch� le clic</param>
    public void CallbackSourisClicRelache(Vector2 directionRelachement)
    {
        OnSourisClicRelache?.Invoke(directionRelachement);
    }
}
