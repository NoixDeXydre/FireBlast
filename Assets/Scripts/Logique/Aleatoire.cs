using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Offre des méthodes supplémentaires pour gérer
/// l'aléatoire.
/// </summary>
public static class Aleatoire 
{

    /// <summary>
    /// Donne un nombre entier entre 0 et l'entier donné (inclusif)
    /// </summary>
    /// <param name="entierNaturel">L'entier servant de borne</param>
    /// <returns>Un entier naturel entre 0 et l'entier donné</returns>
    public static int ChoisirNombreEntierNaturel(int entierNaturel)
    {
        return (int)Mathf.Round(Random.value * entierNaturel);
    }

    /// <summary>
    /// Choisi un index en se basant sur une liste de fréquences (supérieures à 0)
    /// </summary>
    /// <param name="frequences">Fréquences des items</param>
    /// <returns>L'index de la fréquence choisie</returns>
    public static int ChoisirIndexParmisFrequences(List<float> frequences)
    {

        // Génère des clés aléatoires pondérées.
        List<(double cle, int index)> cles = new();
        for (int i = 0; i < frequences.Count; i++)
        {
            cles.Add((Mathf.Pow(Random.value, 1.0f / frequences[i]), i));
        }

        // Prend l'élément avec la plus grande clé.
        return cles.OrderByDescending(x => x.cle).First().index;
    }

    /// <summary>
    /// Choisi un nombre dans la plage (inclusif)
    /// 
    /// Si spécifié, le poids permet d'influencer 
    /// la borne min (si < 1) ou la borne max (si > 1)
    /// Elle aura plus tendance à sélectionner un point min 
    /// ou un point max en fonction du poids.
    /// </summary>
    /// <param name="plageMin">La borne minimum</param>
    /// <param name="plageMax">La borne maximum</param>
    /// <param name="poids">Le poids influençant la borne</param>
    /// <returns>Un nombre dans cette plage</returns>
    public static float ChoisirNombreParmisPlage(float plageMin, float plageMax, float poids = 1.0f)
    {

        // Si le poids est neutre, pas besoin d'aller dans les autres branches.
        if (poids == 1.0f)
        {
            return Random.Range(plageMin, plageMax);
        }

        // Sélection du nombre en fonction du poids.
        float nombreSelectionne;
        if (poids > 1)
        {
            nombreSelectionne = Random.Range(plageMin, plageMax * poids);
        } 
        else
        {
            nombreSelectionne = Random.Range(plageMin * poids, plageMax);
        }

        // Si dépassement, on renvoit une des bornes.
        if (nombreSelectionne <= plageMin)
        {
            return plageMin;
        }
        else if (nombreSelectionne >= plageMax)
        {
            return plageMax;
        }

        return nombreSelectionne;
    }

    /// <summary>
    /// Donne un point aléatoire dans un plan 
    /// à partir de deux axes min-max en X-Y.
    /// </summary>
    /// <param name="axeX">Une rangée sur X</param>
    /// <param name="axeY">Une rangée sur Y</param>
    /// <returns>Donne un point dans le plan XY</returns>
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