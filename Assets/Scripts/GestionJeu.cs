using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Contr�leur de la logique et 
/// de l'affichage de donn�es du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    // =========== Objets � r�f�rencer ===========

    /// <summary>
    /// R�f�rence de la position dans le monde.
    /// </summary>
    public Camera cameraEcranReference;

    /// <summary>
    /// Entit� contr�l�e par le joueur.
    /// </summary>
    public Rigidbody2D joueur;

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

    // ===== Variables destin�es aux calculs =====

    private Vector3 coordonneesCoinSuperieurDroitMap;
    private Vector3 coordonneesCoinInferieurGaucheMap;

    // ============= Logique m�tier ==============

    // Composants accessibles
    public PhysiqueJoueur physiqueJoueur;

    // Composants inaccessibles
    private ControlesSouris controlesSouris;
    private Score score;
    private Timer timer;

    // ============== Controleurs ================

    public ScoreControleur scoreControleur;

    /// <summary>
    /// Initialise la logique m�tier, les controleurs
    /// et l'affichage du jeu.
    /// </summary>
    private void Awake()
    {

        controlesSouris = new ControlesSouris(cameraEcranReference);
        physiqueJoueur = new PhysiqueJoueur(joueur);
        timer = new Timer();
        score = new Score();

        scoreControleur = new ScoreControleur(score, scoreTexte, timer);

        BoundsInt coinsMap = map.cellBounds;
        coordonneesCoinSuperieurDroitMap = map.CellToWorld(coinsMap.max);
        coordonneesCoinInferieurGaucheMap = map.CellToWorld(coinsMap.min);

        coordonneesCoinSuperieurDroitMap.y--; // Est exclusif

        Debug.Log("Map : " + coordonneesCoinSuperieurDroitMap.ToString()
            + " - " + coordonneesCoinInferieurGaucheMap.ToString());
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

        scoreControleur.Update();
    }

    // Capture de la souris � l'aide
    // du BoxCollider2D du GO ComportementJeu.

    /// <summary>
    /// Comportement lorsque le joueur
    /// enfonce et glisse la souris.
    /// </summary>
    private void OnMouseDrag()
    {
        controlesSouris.UpdateOnEnfoncement();

        if (controlesSouris.EstEnfoncementSansGlissement())
        {
            physiqueJoueur.Freiner();
        } else
        {
            physiqueJoueur.AnnulerFreinage();
        }
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// relache le clic de la souris.
    /// </summary>
    private void OnMouseUp()
    {
        controlesSouris.UpdateOnRelachement();
        physiqueJoueur.Propulser(controlesSouris.GetVecteurEnfoncement());
    }
}
