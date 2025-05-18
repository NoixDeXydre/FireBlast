using UnityEngine;

/// <summary>
/// 
/// Contrôle les mouvements du personnage
/// commandés par le joueur.
/// 
/// Trois commandes :
/// - Clic enfoncé sans glisser : le joueur freine;
/// - Clic simple : le joueur effectue une parade;
/// - Glisser souris en enfonçant : le joueur se propulse.
/// 
/// </summary>
public class ControlesJoueur : MonoBehaviour
{

    /// <summary>
    /// Pilote permettant de capturer les clics de la souris.
    /// </summary>
    public ControleurSouris scriptPiloteSouris;

    /// <summary>
    /// Logique pour mouvoir le joueur.
    /// </summary>
    public PhysiqueJoueur physiqueJoueur;

    private EtatsJeu etatsJeu;

    /// <summary>
    /// Initialise des composants nécessaires dans d'autres scripts.
    /// </summary>
    private void Awake()
    {
        physiqueJoueur = new(GetComponent<Rigidbody2D>());
    }

    /// <summary>
    /// Assignement de la logique métier et des évènements.
    /// </summary>
    private void Start()
    {

        etatsJeu = EtatsJeu.GetInstanceEtatsJeu();

        // Evènements déclenchés par le pilote.
        scriptPiloteSouris.SourisClicEnfonce += OnSourisClicEnfonce;
        scriptPiloteSouris.SourisClicRelache += OnSourisClicRelache;
    }

    private void OnSourisClicEnfonce(bool estEnEnfoncementSansGlissement)
    {

        if (!etatsJeu.SontMouvementsBloquees)
        {

            if (estEnEnfoncementSansGlissement)
            {
                physiqueJoueur.Freiner();
            }
            else
            {
                physiqueJoueur.AnnulerFreinage();
            }
        }
    }

    private void OnSourisClicRelache(Vector2 directionGlissement)
    {

        if (!etatsJeu.SontMouvementsBloquees)
        {
            physiqueJoueur.Propulser(directionGlissement);
        }
    }
}
