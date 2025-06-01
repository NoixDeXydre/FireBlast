using System.Collections.Generic;

/// <summary>
/// Repr�sente un groupe d'entit�s avec leur nature
/// et leurs fr�quences d'apparition.
/// </summary>
public class EntitesGroupeStructure
{
    
    /// <summary>
    /// Range chaque entit� correctement avec son index des listes.
    /// </summary>
    private readonly Dictionary<string, int> entitesBibliotheque;

    /// <summary>
    /// Nom des entit�s du groupe
    /// </summary>
    private readonly List<string> entitesGroupe;

    /// <summary>
    /// Liste globale des fr�quences d'apparition.
    /// </summary>
    private readonly List<float> frequencesApparitionGroupe;

    /// <summary>
    /// Initialise un nouveau groupe d'entit�
    /// </summary>
    public EntitesGroupeStructure()
    {
        entitesBibliotheque = new();
        entitesGroupe = new();
        frequencesApparitionGroupe = new();
    }

    /// <summary>
    /// Ajoute une nouvelle entit� dans le groupe.
    /// </summary>
    /// <param name="entiteObjet">Entit�</param>
    /// <param name="nomEntite">Nom de l'entit�</param>
    /// <param name="frequenceApparition">Sa fr�quence d'apparition</param>
    public void AjouterEntite(string nomEntite, float frequenceApparition)
    {

        entitesGroupe.Add(nomEntite);
        frequencesApparitionGroupe.Add(frequenceApparition);

        entitesBibliotheque[nomEntite] = entitesGroupe.Count - 1;
    }

    /// <returns>
    /// Le nom d'une entit� du groupe al�atoirement 
    /// en se basant sur les fr�quences.
    /// </returns>
    public string ChoisirEntiteAleatoirement()
    {
        return entitesGroupe[Aleatoire.ChoisirIndexParmisFrequences(frequencesApparitionGroupe)];
    }

    /// <summary>
    /// Enl�ve l'entit� du groupe.
    /// </summary>
    /// <param name="nomEntite">Nom de l'entit�</param>
    public void EnleverEntite(string nomEntite)
    {

        int indexEntite = entitesBibliotheque[nomEntite];
        entitesGroupe.RemoveAt(indexEntite);
        frequencesApparitionGroupe.RemoveAt(indexEntite);
    }
}
