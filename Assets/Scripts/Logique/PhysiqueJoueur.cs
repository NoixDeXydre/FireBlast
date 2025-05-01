using UnityEngine;

/// <summary>
/// Modifie la position du joueur 
/// selon les forces appliquées.
/// </summary>
public class PhysiqueJoueur
{

    /// <summary>
    /// Le taux de friction en cas de freinage.
    /// </summary>
    private const float TauxFrictionFreinage = 2.0f;

    /// <summary>
    /// Vitesse maximale pouvant être atteinte.
    /// </summary>
    private const float VelociteMaximale = 40.0f;

    /// <summary>
    /// Le taux de linear damping de base du personnage.
    /// </summary>
    private readonly float tauxFrictionDefaut;

    /// <summary>
    /// Le personnage où l'on applique la physique.
    /// </summary>
    private Rigidbody2D joueur;

    public PhysiqueJoueur(Rigidbody2D joueur)
    {
        this.joueur = joueur;
        tauxFrictionDefaut = joueur.linearDamping;
    }

    /// <summary>
    /// Remet la friction du personnage comme avant.
    /// </summary>
    public void AnnulerFreinage()
    {
        joueur.linearDamping = tauxFrictionDefaut;
    }

    /// <summary>
    /// Freine les mouvements du personnage 
    /// en multipliant la friction par 2.
    /// </summary>
    public void Freiner()
    {
        joueur.linearDamping = TauxFrictionFreinage;
    }

    /// <summary>
    /// Propulse le joueur dans le sens opposée à une force indiquée.
    /// </summary>
    /// <param name="forcePropulsion">Sens de la force</param>
    public void Propulser(Vector2 forcePropulsion)
    {

        // On remet la friction comme avant pour ne pas ralentir.
        AnnulerFreinage();

        joueur.AddForce(-forcePropulsion, ForceMode2D.Impulse);

        // La vitesse est bridée par défaut.
        if (joueur.linearVelocity.magnitude > VelociteMaximale)
        {
            joueur.linearVelocity = joueur.linearVelocity.normalized * VelociteMaximale;
        }
    }
}
