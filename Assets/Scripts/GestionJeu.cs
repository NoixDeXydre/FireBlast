using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

/// <summary>
/// Contr�leur de la logique et 
/// de l'affichage de donn�es du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    // =========== Objets � r�f�rencer ===========

    /// <summary>
    /// Affiche les vies dans l'UI
    /// </summary>
    public Image panelVies;

    /// <summary>
    /// Map du jeu
    /// </summary>
    public Tilemap map;

    /// <summary>
    /// Score total de la partie affich� dans l'UI.
    /// </summary>
    public TextMeshProUGUI scoreTexte;

    /// <summary>
    /// Temps �coul� de la partie affich� dans l'UI.
    /// </summary>
    public TextMeshProUGUI timerTexte;

    // ============= Logique m�tier ==============

    // Composants accessibles
    // RIEN

    // Composants inaccessibles
    private Score score;
    private Timer timer;
    private Vie vie;

    // ============== Controleurs ================

    public ControleurScore controleurScore;
    public ControleurVie controleurVie;

    /// <summary>
    /// Initialise la logique m�tier, les controleurs
    /// et l'affichage du jeu.
    /// </summary>
    private void Awake()
    {

        timer = new Timer();
        score = new Score();
        vie = new Vie();

        controleurScore = new ControleurScore(score, scoreTexte, timer);
        controleurVie = new ControleurVie(vie, panelVies);
    }

    /// <summary>
    /// Met � jour les composants
    /// n�cessitant le delta.
    /// </summary>
    private void Update()
    {

        // Le taux de raffraichissement n'est jamais bon sur Android.
        #if UNITY_ANDROID
            Application.targetFrameRate = 60;
        #endif
    }

    /// <summary>
    /// Met � jour les composants 
    /// ayant besoin d'un timer r�el.
    /// </summary>
    private void FixedUpdate()
    {

        timer.Update();
        timerTexte.SetText(timer.ToString()); // TODO mettre � un contr�leur interm�diaire

        controleurScore.Update();
    }
}
