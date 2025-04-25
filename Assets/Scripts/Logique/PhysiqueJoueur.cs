using UnityEngine;

/// <summary>
/// Modifie la position du joueur 
/// selon les forces appliquées.
/// </summary>
public class PhysiqueJoueur
{

    private Rigidbody2D joueur;

    // TODO
    public PhysiqueJoueur(Rigidbody2D joueur)
    {
        this.joueur = joueur;
    }
}
