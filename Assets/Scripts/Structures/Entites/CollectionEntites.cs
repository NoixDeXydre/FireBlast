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

    public EntiteStructure datasetJoueur;
    public List<EntiteStructure> datasetsCollectibles;
    public List<EntiteStructure> datasetsEnnemis;
    public List<EntiteStructure> datasetsProjectiles;

    // ======= Définition des propriétés =======

    public List<EntiteStructure> datasets;
    public EntitesGroupe groupeCollectibles;
    public EntitesGroupe groupeEnnemis;
    public EntitesGroupe groupeProjectiles;

    /// <summary>
    /// Initialise les éléments référencées manuellement.
    /// </summary>
    private void OnEnable()
    {

        // Ajout de tout les datasets.
        datasets = new();
        datasets.AddRange(datasetsCollectibles);
        datasets.AddRange(datasetsEnnemis);
        datasets.AddRange(datasetsProjectiles);

        // Création des groupes ici

        groupeCollectibles = new();
        foreach (EntiteStructure entite in datasetsCollectibles)
        {
            groupeCollectibles.AjouterEntite(entite.nomEntite, entite.chanceApparition);
        }

        groupeEnnemis = new();
        foreach (EntiteStructure entite in datasetsEnnemis)
        {
            groupeEnnemis.AjouterEntite(entite.nomEntite, entite.chanceApparition);
        }

        groupeProjectiles = new();
        foreach (EntiteStructure entite in datasetsCollectibles)
        {
            groupeProjectiles.AjouterEntite(entite.nomEntite, entite.chanceApparition);
        }
    }
}
