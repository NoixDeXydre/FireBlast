using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Représente la map du jeu (fixe)
/// </summary>
public class Map
{

    /// <summary>
    /// Map actuelle du jeu
    /// </summary>
    private readonly Tilemap map;

    /// <summary>
    /// Centre de la map
    /// </summary>
    private readonly Vector2 centreCoordonnees;

    /// <summary>
    /// Coordonnées du point en haut à droite de la map.
    /// </summary>
    private readonly Vector2 coordonneesCoinSuperieurDroitMap;

    /// <summary>
    /// Coordonnées du point en bas à gauche de la map.
    /// </summary>
    private readonly Vector2 coordonneesCoinInferieurGaucheMap;

    /// <summary>
    /// Limites gauche et droite en X.
    /// </summary>
    private readonly Vector2 limitesCoordonneesX;

    /// <summary>
    /// Limites gauche et droite en Y.
    /// </summary>
    private readonly Vector2 limitesCoordonneesY;

    /// <summary>
    /// Référence une nouvelle map.
    /// </summary>
    /// <param name="map">La map à référencer</param>
    public Map(Tilemap map)
    {

        this.map = map;

        // Calcul des bordures de la map
        BoundsInt coinsMap = map.cellBounds;
        coordonneesCoinSuperieurDroitMap = map.CellToWorld(coinsMap.max);
        coordonneesCoinInferieurGaucheMap = map.CellToWorld(coinsMap.min);

        coordonneesCoinSuperieurDroitMap.y--; // Est exclusif

        // Calculer directement pour gagner en performance.
        centreCoordonnees = coordonneesCoinSuperieurDroitMap / 2.0f;
        limitesCoordonneesX = new(coordonneesCoinInferieurGaucheMap.x, coordonneesCoinSuperieurDroitMap.x);
        limitesCoordonneesY = new(coordonneesCoinInferieurGaucheMap.y, coordonneesCoinSuperieurDroitMap.y);
    }

    /// <returns>Un point visant le centre de la map</returns>
    public Vector2 GetCentreMap()
    {
        return centreCoordonnees;
    }

    /// <returns>Retourne un intervalle des limites en X, de gauche à droite.</returns>
    public Vector2 GetCoordonneesIntervallesX()
    {
        return limitesCoordonneesX;
    }

    /// <returns>Retourne un intervalle des limites en Y, de gauche à droite.</returns>
    public Vector2 GetCoordonneesIntervallesY()
    {
        return limitesCoordonneesY;
    }

    /// <param name="axeX">Un point dans l'axe horizontal de la map</param>
    /// <returns>True si ce point appartient au plan horizontal de la map</returns>
    public bool IsAxeXSurLaMap(float axeX)
    {
        return axeX >= limitesCoordonneesX.x && axeX <= limitesCoordonneesX.y;
    }

    /// <param name="axeY">Un point dans l'axe vertical de la map</param>
    /// <returns>True si ce point appartient au plan vertical de la map</returns>
    public bool IsAxeYSurLaMap(float axeY)
    {
        return axeY >= limitesCoordonneesY.x && axeY <= limitesCoordonneesY.y;
    }

    /// <param name="point">Un point donné dans le monde</param>
    /// <returns>True si le point est dans la map, sinon false</returns>
    public bool IsPointSurLaMap(Vector2 point)
    {
        return IsAxeXSurLaMap(point.x) && IsAxeYSurLaMap(point.y);
    }
}
