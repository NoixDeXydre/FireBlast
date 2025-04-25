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
