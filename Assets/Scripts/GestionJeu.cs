using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

/// <summary>
/// Contrôleur de la logique et 
/// de l'affichage de données du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    // =========== Objets à référencer ===========

    public Image panelVies;

    /// <summary>
    /// Entité contrôlée par le joueur.
    /// </summary>
    public Rigidbody2D joueur;

    /// <summary>
    /// Map du jeu
    /// </summary>
    public Tilemap map;

    /// <summary>
    /// Score total de la partie affiché dans l'UI.
    /// </summary>
    public TextMeshProUGUI scoreTexte;

    /// <summary>
    /// Temps écoulé de la partie affiché dans l'UI.
    /// </summary>
    public TextMeshProUGUI timerTexte;

    // ===== Variables destinées aux calculs =====

    private Vector3 coordonneesCoinSuperieurDroitMap;
    private Vector3 coordonneesCoinInferieurGaucheMap;

    // ============= Logique métier ==============

    // Composants accessibles
    public PhysiqueJoueur physiqueJoueur;

    // Composants inaccessibles
    private Score score;
    private Timer timer;
    private Vie vie;

    // ============== Controleurs ================

    public ControleurScore controleurScore;
    public ControleurVie controleurVie;

    /// <summary>
    /// Initialise la logique métier, les controleurs
    /// et l'affichage du jeu.
    /// </summary>
    private void Awake()
    {

        physiqueJoueur = new PhysiqueJoueur(joueur);
        timer = new Timer();
        score = new Score();
        vie = new Vie();

        controleurScore = new ControleurScore(score, scoreTexte, timer);
        controleurVie = new ControleurVie(vie, panelVies);

        BoundsInt coinsMap = map.cellBounds;
        coordonneesCoinSuperieurDroitMap = map.CellToWorld(coinsMap.max);
        coordonneesCoinInferieurGaucheMap = map.CellToWorld(coinsMap.min);

        coordonneesCoinSuperieurDroitMap.y--; // Est exclusif

        Debug.Log("Map : " + coordonneesCoinSuperieurDroitMap.ToString()
            + " - " + coordonneesCoinInferieurGaucheMap.ToString());
    }

    /// <summary>
    /// Met à jour les composants
    /// nécessitant le delta.
    /// </summary>
    private void Update()
    {

        // Le taux de raffraichissement n'est jamais bon sur Android.
        #if UNITY_ANDROID
            Application.targetFrameRate = 60;
        #endif
    }

    /// <summary>
    /// Met à jour les composants 
    /// ayant besoin d'un timer réel.
    /// </summary>
    private void FixedUpdate()
    {

        timer.Update();
        timerTexte.SetText(timer.ToString()); // TODO mettre à un contrôleur intermédiaire

        controleurScore.Update();
    }
}
