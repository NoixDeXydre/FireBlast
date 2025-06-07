using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rassemble une collection d'entit�s avec leurs propri�t�s.
/// </summary>
[CreateAssetMenu(fileName = "CollectionEntites", menuName = "FireBall - Entites/CollectionEntites")]
public class CollectionEntites : ScriptableObject
{

    // ======= D�finition des GameObject =======

    // /!\ � d�finir /!\

    public Entite datasetJoueur;
    public List<Entite> datasetsCollectibles;
    public List<Entite> datasetsProjectiles;

    // ======= D�finition des propri�t�s =======

    public List<Entite> datasets;

    public EntitesGroupe groupeCollectibles;
    public EntitesGroupe groupeProjectiles;

    /// <summary>
    /// Initialise les �l�ments r�f�renc�es manuellement.
    /// </summary>
    private void OnEnable()
    {

        // Ajout de tout les datasets.
        datasets = new();
        datasets.AddRange(datasetsCollectibles);
        datasets.AddRange(datasetsProjectiles);

        // Cr�ation des groupes ici

        groupeCollectibles = new();
        foreach (Entite entite in datasetsCollectibles)
        {
            groupeCollectibles.AjouterEntite(entite.nomEntite, entite.chanceApparition);
        }

        groupeProjectiles = new();
        foreach (Entite entite in datasetsCollectibles)
        {
            groupeProjectiles.AjouterEntite(entite.nomEntite, entite.chanceApparition);
        }
    }
}
