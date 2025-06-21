using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Permet de créer des entités sur la map.
///
/// Utilisez plutôt EntitesGroupePool 
/// si les objets doivent se détruire souvent !
/// </summary>
public class EntitesCreateur
{

    /// <summary>
    /// Map sur laquelle les entités vont apparaitre.
    /// </summary>
    [Inject] private readonly MapVirtuelle _map;

    /// <summary>
    /// Crée les entités à la chaîne.
    /// </summary>
    /// <param name="entites">Les entités à créer</param>
    /// <param name="positions">Leur position correspondante</param>
    /// <returns>Les entités créees</returns>
    public List<GameObject> CreerEntites(List<GameObject> entites, List<Vector2> positions)
    {

        List<GameObject> entitesEffectives = new();
        for (int i = 0; i < entites.Count; i++)
        {

            // Crée l'entité et ajoute dans la liste.
            entitesEffectives.Add(CreerEntite(entites[i], positions[i]));
        }

        return entitesEffectives;
    }

    /// <summary>
    /// Fait apparaître une nouvelle entité.
    /// L'entité ne peut pas apparaître hors de la map.
    /// </summary>
    /// <param name="entite">L'entité a créer</param>
    /// <param name="position">La position de l'entité</param>
    /// <returns>L'entité créee</returns>
    public GameObject CreerEntite(GameObject entite, Vector2 position)
    {
        return Object.Instantiate(entite, _map.NormaliserPoint(position), Quaternion.identity);
    }
}
