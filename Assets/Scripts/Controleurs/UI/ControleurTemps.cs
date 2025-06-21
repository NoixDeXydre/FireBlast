using TMPro;
using UnityEngine;

/// <summary>
/// Gère le temps de la partie graphiquement et numériquement.
/// </summary>
public class ControleurTemps : MonoBehaviour
{

    /// <summary>
    /// Temps écoulé de la partie affiché dans l'UI.
    /// </summary>
    private TextMeshProUGUI timerTexte;

    /// <summary>
    /// Timer de la partie
    /// </summary>
    private TimerPartie timerPartie;

    /// <returns>Le timer global de la partie</returns>
    public TimerPartie GetTimerPartie()
    {
        return timerPartie;
    }

    /// <summary>
    /// Initialise le contrôleur.
    /// </summary>
    private void Start()
    {
        timerTexte = GetComponent<TextMeshProUGUI>();
        timerPartie = new();
    }

    /// <summary>
    /// Met à jour le timer visuellement et numériquement.
    /// </summary>
    private void FixedUpdate()
    {
        timerPartie.Update();
        timerTexte.SetText(timerPartie.ToString());
    }
}
