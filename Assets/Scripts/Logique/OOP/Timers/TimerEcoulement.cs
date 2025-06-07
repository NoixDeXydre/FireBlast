using UnityEngine;

/// <summary>
/// Permet de faire disparaître une entité 
/// au bout d'une certaine période.
/// </summary>
public class TimerEcoulement
{

    /// <summary>
    /// Temps dans lequel un timer est considéré comme écoulé.
    /// </summary>
    private const float TIMER_ECOULE_VALEUR = 0.0f;

    /// <summary>
    /// Durée de vie du timer
    /// </summary>
    private readonly float dureeVie;

    /// <summary>
    /// Temps dans lequel le timer peut envoyer un avertissement.
    /// </summary>
    private readonly float tempsAvertissement;

    /// <summary>
    /// Durée de vie restante du timer
    /// </summary>
    private float tempsVieRestante;

    /// <summary>
    /// Défini si le timer doit s'écouler ou non.
    /// </summary>
    private bool EstTimerEnPause;

    /// <summary>
    /// Initialise le composant avec
    /// l'entité concernée et sa période de vie.
    /// </summary>
    /// <param name="dureeVie">Durée de vie en secondes</param>
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

    /// <returns>True si le timer est écoulé, sinon false</returns>
    public bool IsTimerEcoule() {
        return tempsVieRestante <= TIMER_ECOULE_VALEUR;
    }

    /// <returns>
    /// True si le temps restant est inférieur au temps d'avertissement,
    /// sinon false
    /// </returns>
    public bool IsTimerEnAvertissement()
    {
        return tempsVieRestante <= tempsAvertissement;
    }

    /// <summary>
    /// Met à zéro le temps écoulé.
    /// </summary>
    public void ResetTimer()
    {
        tempsVieRestante = dureeVie;
    }

    /// <summary>
    /// Défini si le timer doit être en pause.
    /// </summary>
    /// <param name="estEnPause">True si le timer doit se mettre en pause, sinon false</param>
    public void SetPauseTimer(bool estEnPause)
    {
        EstTimerEnPause = estEnPause;
    }

    /// <summary>
    /// Met à jour le timer pour effectuer la destruction de l'objet
    /// avec le temps demandé.
    /// </summary>
    /// <returns>True si le timer est écoulé, sinon false</returns>
    public bool Update()
    {

        // Le temps ne s'écoulera pas en pause.
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
