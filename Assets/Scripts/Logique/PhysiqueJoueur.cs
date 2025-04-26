using UnityEngine;

/// <summary>
/// Modifie la position du joueur 
/// selon les forces appliqu�es.
/// </summary>
public class PhysiqueJoueur
{

    /// <summary>
    /// Le taux de linear damping de base du personnage.
    /// </summary>
    private readonly float tauxFreinageDefaut;

    /// <summary>
    /// Le personnage o� l'on applique la physique.
    /// </summary>
    private Rigidbody2D joueur;

    public PhysiqueJoueur(Rigidbody2D joueur)
    {
        this.joueur = joueur;
        tauxFreinageDefaut = joueur.linearDamping;
    }

    /// <summary>
    /// Remet la friction du personnage comme avant.
    /// </summary>
    public void AnnulerFreinage()
    {
        joueur.linearDamping = tauxFreinageDefaut;
    }

    /// <summary>
    /// Freine les mouvements du personnage 
    /// en multipliant la friction par 2.
    /// </summary>
    public void Freiner()
    {
        joueur.linearDamping = 2.0f;
    }

    /// <summary>
    /// Propulse le joueur dans le sens oppos�e � une force indiqu�e.
    /// </summary>
    /// <param name="forcePropulsion">Sens de la force</param>
    public void Propulser(Vector2 forcePropulsion)
    {

        // On remet la friction comme avant pour ne pas ralentir.
        AnnulerFreinage();

        joueur.AddForceX(-forcePropulsion.x, ForceMode2D.Impulse);
        joueur.AddForceY(-forcePropulsion.y, ForceMode2D.Impulse);
    }
}
