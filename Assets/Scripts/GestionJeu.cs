using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Tilemaps;

/// <summary>
/// Contrôleur de la logique et 
/// de l'affichage de données du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    // =========== Objets à référencer ===========

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
    public TextMeshProUGUI score;

    // ===== Variables destinées aux calculs =====

    private Vector3 coordonneesCoinSuperieurDroitMap;
    private Vector3 coordonneesCoinInferieurGaucheMap;

    // ============= Logique métier ==============

    private ControlesSouris controlesSouris;
    private PhysiqueJoueur physiqueJoueur;

    /// <summary>
    /// Initialise la logique métier 
    /// et l'affichage du jeu.
    /// </summary>
    void Start()
    {
        Debug.Log("Lancement de la partie...");   

        Debug.Log("Initialisation de la logique du jeu...");
        controlesSouris = new ControlesSouris();
        physiqueJoueur = new PhysiqueJoueur(joueur);

        Debug.Log("Analyse de la carte...");
        BoundsInt coinsMap = map.cellBounds;
        coordonneesCoinSuperieurDroitMap = map.CellToWorld(coinsMap.max);
        coordonneesCoinInferieurGaucheMap = map.CellToWorld(coinsMap.min);

        coordonneesCoinSuperieurDroitMap.y--; // Est exclusif

        Debug.Log("Map : " + coordonneesCoinSuperieurDroitMap.ToString() 
            + " - " + coordonneesCoinInferieurGaucheMap.ToString());
    }

    // Capture de la souris à l'aide
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
