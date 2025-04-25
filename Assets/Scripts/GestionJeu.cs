using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

/// <summary>
/// Contr�leur de la logique et 
/// de l'affichage de donn�es du jeu.
/// </summary>
public class GestionJeu : MonoBehaviour
{

    // =========== Objets � r�f�rencer ===========

    /// <summary>
    /// Entit� contr�l�e par le joueur.
    /// </summary>
    public Rigidbody2D joueur;

    /// <summary>
    /// Score total de la partie affich� dans l'UI.
    /// </summary>
    public TextMeshProUGUI score;

    // ============= Logique m�tier ==============

    private ControlesSouris controlesSouris;
    private PhysiqueJoueur physiqueJoueur;

    /// <summary>
    /// Initialise la logique m�tier 
    /// et l'affichage du jeu.
    /// </summary>
    void Start()
    {
        Debug.Log("Lancement de la partie...");   

        Debug.Log("Initialisation de la logique du jeu");
        controlesSouris = new ControlesSouris();
        physiqueJoueur = new PhysiqueJoueur(joueur);
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
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// relache le clic de la souris.
    /// </summary>
    private void OnMouseUp()
    {
        controlesSouris.UpdateOnRelachement();
    }
}
