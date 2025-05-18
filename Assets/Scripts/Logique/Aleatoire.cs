using UnityEngine;

/// <summary>
/// Offre des m�thodes suppl�mentaires pour g�rer
/// l'al�atoire.
/// </summary>
public static class Aleatoire 
{

    /// <summary>
    /// Donne un point al�atoire dans un plan 
    /// � partir de deux axes min-max en X-Y.
    /// </summary>
    /// <param name="axeX">Une rang�e sur X</param>
    /// <param name="axeY">Une rang�e sur Y</param>
    /// <returns></returns>
    public static Vector2 ChoisirPointParmisDeuxAxes(Vector2 axeX, Vector2 axeY)
    {
        return new(Random.Range(axeX.x, axeX.y), Random.Range(axeY.x, axeY.y)); 
    }

    /// <summary>
    /// G�n�re une nouvelle graine pour le g�n�rateur.
    /// </summary>
    public static void PermuterGraineGenerateur()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
    
}
