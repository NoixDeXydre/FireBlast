using TMPro;
using UnityEngine;

/// <summary>
/// G�re le temps de la partie graphiquement et num�riquement.
/// </summary>
public class ControleurTemps : MonoBehaviour
{

    /// <summary>
    /// Temps �coul� de la partie affich� dans l'UI.
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
    /// Initialise le contr�leur.
    /// </summary>
    private void Start()
    {
        timerTexte = GetComponent<TextMeshProUGUI>();
        timerPartie = new();
    }

    /// <summary>
    /// Met � jour le timer visuellement et num�riquement.
    /// </summary>
    private void FixedUpdate()
    {
        timerPartie.Update();
        timerTexte.SetText(timerPartie.ToString());
    }
}
