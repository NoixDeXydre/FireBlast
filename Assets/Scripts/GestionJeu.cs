using TMPro;
using UnityEngine;

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
    /// Score total de la partie affiché dans l'UI.
    /// </summary>
    public TextMeshProUGUI score;

    // ============= Logique métier ==============

    private ControlesSouris controlesSouris;
    private PhysiqueJoueur physiqueJoueur;

    // TODO
    void Start()
    {
        Debug.Log("Lancement de la partie...");   

        Debug.Log("Initialisation de la logique du jeu");
        controlesSouris = new ControlesSouris();
        physiqueJoueur = new PhysiqueJoueur(joueur);
    }

    // TODO
    void Update()
    {
           
    }
}
