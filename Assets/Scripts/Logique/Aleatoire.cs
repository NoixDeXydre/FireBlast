using UnityEngine;

/// <summary>
/// Offre des méthodes supplémentaires pour gérer
/// l'aléatoire.
/// </summary>
public static class Aleatoire 
{

    /// <summary>
    /// Donne un point aléatoire dans un plan 
    /// à partir de deux axes min-max en X-Y.
    /// </summary>
    /// <param name="axeX">Une rangée sur X</param>
    /// <param name="axeY">Une rangée sur Y</param>
    /// <returns></returns>
    public static Vector2 ChoisirPointParmisDeuxAxes(Vector2 axeX, Vector2 axeY)
    {
        return new(Random.Range(axeX.x, axeX.y), Random.Range(axeY.x, axeY.y)); 
    }

    /// <summary>
    /// Génère une nouvelle graine pour le générateur.
    /// </summary>
    public static void PermuterGraineGenerateur()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
    
}
