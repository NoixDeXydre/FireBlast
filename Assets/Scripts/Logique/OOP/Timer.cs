using UnityEngine;

/// <summary>
/// Compte le temps d'une partie.
/// </summary>
public class Timer
{

    /// <summary>
    /// Temps total écoulé
    /// </summary>
    private float temps;
    public Timer()
    {
        temps = 0f;
    }

    /// <summary>
    /// Donne le temps total en secondes.
    /// </summary>
    /// <returns>Le temps en secondes</returns>
    public int GetTempsEcoule()
    {
        return (int)temps;
    }

    /// <summary>
    /// Donne le temps total en format lisible 
    /// de la manière suivante : mm:ss
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {

        int minutes = (int)temps / 60;
        int secondes = (int)temps % 60;

        return minutes.ToString().PadLeft(2, '0') + ":" 
            + secondes.ToString().PadLeft(2, '0');
    }

    /// <summary>
    /// Met à jour le timer jusqu'à atteindre les 99 minutes.
    /// </summary>
    public void Update()
    {

        // Le temps est bloqué au bout de 99 minutes.
        if (temps <= 5940)
        {
            temps += Time.deltaTime;
        }
    }
}
