using UnityEngine;

/// <summary>
/// Rassemblement de la logique d'un Joueur.
/// </summary>
public class Joueur : Entite
{

    // Scripts liés

    public ComportementJoueur Comportement { get; private set; }
    public ControlesJoueur Controles { get; private set; }

    // Composants

    /// <summary>
    /// Permet de faire bouger le joueur.
    /// </summary>
    public PhysiqueJoueur PhysiqueJoueur { get; private set; }

    private new void Start()
    {

        base.Start();

        Comportement = GetComponent<ComportementJoueur>();
        Controles = GetComponent<ControlesJoueur>();

        PhysiqueJoueur = new(GetComponent<Rigidbody2D>());
    }
}
