using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de créer des entités sur la map.
/// </summary>
public class CreateurEntites
{

    /// <summary>
    /// Map sur laquelle les entités vont apparaitre.
    /// </summary>
    private readonly Map map;

    /// <summary>
    /// Crée un nouveau créateur d'entités
    /// </summary>
    /// <param name="map">Map sur laquelle les entités vont apparaitre</param>
    public CreateurEntites(Map map)
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

        if (!map.IsPointSurLaMap(position))
        {
            
            // Normalisation de la position si elle n'est pas dans le plan.

            Vector2 limitesMapX = map.GetCoordonneesIntervallesX();
            if (position.x < limitesMapX.x)
            {
                position.x = limitesMapX.x;
            }
            else if (position.x > limitesMapX.y)
            {
                position.x = limitesMapX.y;
            }

            Vector2 limitesMapY = map.GetCoordonneesIntervallesY();
            if (position.y < limitesMapY.x)
            {
                position.y = limitesMapY.x;
            }
            else if (position.y > limitesMapY.y)
            {
                position.y = limitesMapY.y;
            }
        }

        return Object.Instantiate(entite, position, Quaternion.identity);
    }
}
