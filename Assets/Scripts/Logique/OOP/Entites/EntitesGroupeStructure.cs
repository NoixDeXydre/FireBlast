using System.Collections.Generic;

/// <summary>
/// Représente un groupe d'entités avec leur nature
/// et leurs fréquences d'apparition.
/// </summary>
public class EntitesGroupeStructure
{
    
    /// <summary>
    /// Range chaque entité correctement avec son index des listes.
    /// </summary>
    private readonly Dictionary<string, int> entitesBibliotheque;

    /// <summary>
    /// Nom des entités du groupe
    /// </summary>
    private readonly List<string> entitesGroupe;

    /// <summary>
    /// Liste globale des fréquences d'apparition.
    /// </summary>
    private readonly List<float> frequencesApparitionGroupe;

    /// <summary>
    /// Initialise un nouveau groupe d'entité
    /// </summary>
    public EntitesGroupeStructure()
    {
        entitesBibliotheque = new();
        entitesGroupe = new();
        frequencesApparitionGroupe = new();
    }

    /// <summary>
    /// Ajoute une nouvelle entité dans le groupe.
    /// </summary>
    /// <param name="entiteObjet">Entité</param>
    /// <param name="nomEntite">Nom de l'entité</param>
    /// <param name="frequenceApparition">Sa fréquence d'apparition</param>
    public void AjouterEntite(string nomEntite, float frequenceApparition)
    {

        entitesGroupe.Add(nomEntite);
        frequencesApparitionGroupe.Add(frequenceApparition);

        entitesBibliotheque[nomEntite] = entitesGroupe.Count - 1;
    }

    /// <returns>
    /// Le nom d'une entité du groupe aléatoirement 
    /// en se basant sur les fréquences.
    /// </returns>
    public string ChoisirEntiteAleatoirement()
    {
        return entitesGroupe[Aleatoire.ChoisirIndexParmisFrequences(frequencesApparitionGroupe)];
    }

    /// <summary>
    /// Enlève l'entité du groupe.
    /// </summary>
    /// <param name="nomEntite">Nom de l'entité</param>
    public void EnleverEntite(string nomEntite)
    {

        int indexEntite = entitesBibliotheque[nomEntite];
        entitesGroupe.RemoveAt(indexEntite);
        frequencesApparitionGroupe.RemoveAt(indexEntite);
    }
}
