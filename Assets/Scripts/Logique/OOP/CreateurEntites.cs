using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de créer des entités sur la map.
///
/// Utilisez plutôt EntitesPoolGroupe 
/// si les objets doivent se détruire souvent !
/// </summary>
public class CreateurEntites
{

    /// <summary>
    /// Map sur laquelle les entités vont apparaitre.
    /// </summary>
    private readonly MapVirtuelle map;

    /// <summary>
    /// Crée un nouveau créateur d'entités
    /// </summary>
    /// <param name="map">Map sur laquelle les entités vont apparaitre</param>
    public CreateurEntites(MapVirtuelle map)
    {
        this.map = map;
    }

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
        return Object.Instantiate(entite, map.NormaliserPoint(position), Quaternion.identity);
    }
}
