using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Repr�sente la map du jeu (fixe)
/// </summary>
public class MapVirtuelle
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
    /// Coordonn�es du point en haut � droite de la map.
    /// </summary>
    private readonly Vector2 coordonneesCoinSuperieurDroitMap;

    /// <summary>
    /// Coordonn�es du point en bas � gauche de la map.
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
    /// R�f�rence une nouvelle map.
    /// </summary>
    /// <param name="map">La map � r�f�rencer</param>
    /// <param name="margeInterne">Marge restreignant les entit�s</param>
    public MapVirtuelle(Tilemap map, float margeInterne)
    {

        this.map = map;

        Vector2 margeVectoriel = new(margeInterne, margeInterne);

        // Calcul des bordures de la map
        BoundsInt coinsMap = map.cellBounds;
        coordonneesCoinSuperieurDroitMap = (Vector2) map.CellToWorld(coinsMap.max) - margeVectoriel;
        coordonneesCoinInferieurGaucheMap = (Vector2) map.CellToWorld(coinsMap.min) + margeVectoriel;

        coordonneesCoinSuperieurDroitMap.y--; // Est exclusif

        // Calculer directement pour gagner en performance.
        centreCoordonnees = (coordonneesCoinSuperieurDroitMap + coordonneesCoinInferieurGaucheMap) * .5f;
        limitesCoordonneesX = new(coordonneesCoinInferieurGaucheMap.x, coordonneesCoinSuperieurDroitMap.x);
        limitesCoordonneesY = new(coordonneesCoinInferieurGaucheMap.y, coordonneesCoinSuperieurDroitMap.y);
    }

    /// <returns>Un point visant le centre de la map</returns>
    public Vector2 GetCentreMap()
    {
        return centreCoordonnees;
    }

    /// <returns>Retourne un intervalle des limites en X, de gauche � droite.</returns>
    public Vector2 GetCoordonneesIntervallesX()
    {
        return limitesCoordonneesX;
    }

    /// <returns>Retourne un intervalle des limites en Y, de gauche � droite.</returns>
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

    /// <param name="point">Un point donn� dans le monde</param>
    /// <returns>True si le point est dans la map, sinon false</returns>
    public bool IsPointSurLaMap(Vector2 point)
    {
        return IsAxeXSurLaMap(point.x) && IsAxeYSurLaMap(point.y);
    }

    /// <param name="point">le point � normaliser</param>
    /// <returns>Un point normalis�, restant dans la map</returns>
    public Vector2 NormaliserPoint(Vector2 point)
    {

        Vector2 pointNormalise = new(point.x, point.y);

        if (pointNormalise.x < limitesCoordonneesX.x)
        {
            pointNormalise.x = limitesCoordonneesX.x;
        }
        else if (pointNormalise.x > limitesCoordonneesX.y)
        {
            pointNormalise.x = limitesCoordonneesX.y;
        }

        if (pointNormalise.y < limitesCoordonneesY.x)
        {
            pointNormalise.y = limitesCoordonneesX.x;
        }
        else if (pointNormalise.y > limitesCoordonneesY.y)
        {
            pointNormalise.y = limitesCoordonneesY.y;
        }

        return pointNormalise;
    }
}
