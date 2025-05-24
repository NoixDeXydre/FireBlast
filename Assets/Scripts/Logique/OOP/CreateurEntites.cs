using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de cr�er des entit�s sur la map.
///
/// Utilisez plut�t EntitesPoolGroupe 
/// si les objets doivent se d�truire souvent !
/// </summary>
public class CreateurEntites
{

    /// <summary>
    /// Map sur laquelle les entit�s vont apparaitre.
    /// </summary>
    private readonly MapVirtuelle map;

    /// <summary>
    /// Cr�e un nouveau cr�ateur d'entit�s
    /// </summary>
    /// <param name="map">Map sur laquelle les entit�s vont apparaitre</param>
    public CreateurEntites(MapVirtuelle map)
    {
        this.map = map;
    }

    /// <summary>
    /// Cr�e les entit�s � la cha�ne.
    /// </summary>
    /// <param name="entites">Les entit�s � cr�er</param>
    /// <param name="positions">Leur position correspondante</param>
    /// <returns>Les entit�s cr�ees</returns>
    public List<GameObject> CreerEntites(List<GameObject> entites, List<Vector2> positions)
    {

        List<GameObject> entitesEffectives = new();
        for (int i = 0; i < entites.Count; i++)
        {

            // Cr�e l'entit� et ajoute dans la liste.
            entitesEffectives.Add(CreerEntite(entites[i], positions[i]));
        }

        return entitesEffectives;
    }

    /// <summary>
    /// Fait appara�tre une nouvelle entit�.
    /// L'entit� ne peut pas appara�tre hors de la map.
    /// </summary>
    /// <param name="entite">L'entit� a cr�er</param>
    /// <param name="position">La position de l'entit�</param>
    /// <returns>L'entit� cr�ee</returns>
    public GameObject CreerEntite(GameObject entite, Vector2 position)
    {
        return Object.Instantiate(entite, map.NormaliserPoint(position), Quaternion.identity);
    }
}
