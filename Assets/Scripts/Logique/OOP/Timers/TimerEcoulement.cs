using UnityEngine;

/// <summary>
/// Permet de faire dispara�tre une entit� 
/// au bout d'une certaine p�riode.
/// </summary>
public class TimerEcoulement
{

    /// <summary>
    /// Temps dans lequel un timer est consid�r� comme �coul�.
    /// </summary>
    private const float TIMER_ECOULE_VALEUR = 0.0f;

    /// <summary>
    /// Dur�e de vie du timer
    /// </summary>
    private readonly float dureeVie;

    /// <summary>
    /// Temps dans lequel le timer peut envoyer un avertissement.
    /// </summary>
    private readonly float tempsAvertissement;

    /// <summary>
    /// Dur�e de vie restante du timer
    /// </summary>
    private float tempsVieRestante;

    /// <summary>
    /// D�fini si le timer doit s'�couler ou non.
    /// </summary>
    private bool EstTimerEnPause;

    /// <summary>
    /// Initialise le composant avec
    /// l'entit� concern�e et sa p�riode de vie.
    /// </summary>
    /// <param name="dureeVie">Dur�e de vie en secondes</param>
    /// <param name="tempsAvertissement">Temps d'avertissement</param>
    /// <param name="EstTimerEnPause">Le timer sera en pause si true</param>
    public TimerEcoulement(float dureeVie, float tempsAvertissement, bool EstTimerEnPause)
    {

        this.dureeVie = dureeVie;
        this.tempsAvertissement = tempsAvertissement;
        tempsVieRestante = dureeVie;

        this.EstTimerEnPause = EstTimerEnPause;
    }

    /// <returns>Le temps restant du timer</returns>
    public float GetTempsRestant()
    {
        return tempsVieRestante;
    }

    /// <returns>True si le timer est �coul�, sinon false</returns>
    public bool IsTimerEcoule() {
        return tempsVieRestante <= TIMER_ECOULE_VALEUR;
    }

    /// <returns>
    /// True si le temps restant est inf�rieur au temps d'avertissement,
    /// sinon false
    /// </returns>
    public bool IsTimerEnAvertissement()
    {
        return tempsVieRestante <= tempsAvertissement;
    }

    /// <summary>
    /// Met � z�ro le temps �coul�.
    /// </summary>
    public void ResetTimer()
    {
        tempsVieRestante = dureeVie;
    }

    /// <summary>
    /// D�fini si le timer doit �tre en pause.
    /// </summary>
    /// <param name="estEnPause">True si le timer doit se mettre en pause, sinon false</param>
    public void SetPauseTimer(bool estEnPause)
    {
        EstTimerEnPause = estEnPause;
    }

    /// <summary>
    /// Met � jour le timer pour effectuer la destruction de l'objet
    /// avec le temps demand�.
    /// </summary>
    /// <returns>True si le timer est �coul�, sinon false</returns>
    public bool Update()
    {

        // Le temps ne s'�coulera pas en pause.
        if (EstTimerEnPause)
        {
            return IsTimerEcoule();
        }

        tempsVieRestante -= Time.deltaTime;
        if (tempsVieRestante <= TIMER_ECOULE_VALEUR)
        {
            tempsVieRestante = TIMER_ECOULE_VALEUR;
            return true;
        }

        return false;
    }
}
