using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rassemble une collection d'entités avec leurs propriétés.
/// </summary>
[CreateAssetMenu(fileName = "CollectionEntites", menuName = "FireBall - Entites/CollectionEntites")]
public class CollectionEntites : ScriptableObject
{

    // ======= Définition des GameObject =======

    // /!\ À définir /!\

    public Entite datasetJoueur;
    public List<Entite> datasetsCollectibles;
    public List<Entite> datasetsProjectiles;

    // ======= Définition des propriétés =======

    public List<Entite> datasets;

    public EntitesGroupe groupeCollectibles;
    public EntitesGroupe groupeProjectiles;

    /// <summary>
    /// Initialise les éléments référencées manuellement.
    /// </summary>
    private void OnEnable()
    {

        // Ajout de tout les datasets.
        datasets = new();
        datasets.AddRange(datasetsCollectibles);
        datasets.AddRange(datasetsProjectiles);

        // Création des groupes ici

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
