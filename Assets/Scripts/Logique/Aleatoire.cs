using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Offre des m�thodes suppl�mentaires pour g�rer
/// l'al�atoire.
/// </summary>
public static class Aleatoire 
{

    /// <summary>
    /// Donne un nombre entier entre 0 et l'entier donn� (inclusif)
    /// </summary>
    /// <param name="entierNaturel">L'entier servant de borne</param>
    /// <returns>Un entier naturel entre 0 et l'entier donn�</returns>
    public static int ChoisirNombreEntierNaturel(int entierNaturel)
    {
        return (int)Mathf.Round(Random.value * entierNaturel);
    }

    /// <summary>
    /// Choisi un index en se basant sur une liste de fr�quences (sup�rieures � 0)
    /// </summary>
    /// <param name="frequences">Fr�quences des items</param>
    /// <returns>L'index de la fr�quence choisie</returns>
    public static int ChoisirIndexParmisFrequences(List<float> frequences)
    {

        // G�n�re des cl�s al�atoires pond�r�es.
        List<(double cle, int index)> cles = new();
        for (int i = 0; i < frequences.Count; i++)
        {
            cles.Add((Mathf.Pow(Random.value, 1.0f / frequences[i]), i));
        }

        // Prend l'�l�ment avec la plus grande cl�.
        return cles.OrderByDescending(x => x.cle).First().index;
    }

    /// <summary>
    /// Choisi un nombre dans la plage (inclusif)
    /// 
    /// Si sp�cifi�, le poids permet d'influencer 
    /// la borne min (si < 1) ou la borne max (si > 1)
    /// Elle aura plus tendance � s�lectionner un point min 
    /// ou un point max en fonction du poids.
    /// </summary>
    /// <param name="plageMin">La borne minimum</param>
    /// <param name="plageMax">La borne maximum</param>
    /// <param name="poids">Le poids influen�ant la borne</param>
    /// <returns>Un nombre dans cette plage</returns>
    public static float ChoisirNombreParmisPlage(float plageMin, float plageMax, float poids = 1.0f)
    {

        // Si le poids est neutre, pas besoin d'aller dans les autres branches.
        if (poids == 1.0f)
        {
            return Random.Range(plageMin, plageMax);
        }

        // S�lection du nombre en fonction du poids.
        float nombreSelectionne;
        if (poids > 1)
        {
            nombreSelectionne = Random.Range(plageMin, plageMax * poids);
        } 
        else
        {
            nombreSelectionne = Random.Range(plageMin * poids, plageMax);
        }

        // Si d�passement, on renvoit une des bornes.
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
    /// Donne un point al�atoire dans un plan 
    /// � partir de deux axes min-max en X-Y.
    /// </summary>
    /// <param name="axeX">Une rang�e sur X</param>
    /// <param name="axeY">Une rang�e sur Y</param>
    /// <returns>Donne un point dans le plan XY</returns>
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