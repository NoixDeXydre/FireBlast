using UnityEngine;

/// <summary>
/// 
/// Contr�le les mouvements du personnage
/// command�s par le joueur.
/// 
/// Trois commandes :
/// - Clic enfonc� sans glisser : le joueur freine;
/// - Clic simple : le joueur effectue une parade;
/// - Glisser souris en enfon�ant : le joueur se propulse.
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
    /// Initialise des composants n�cessaires dans d'autres scripts.
    /// </summary>
    private void Awake()
    {
        physiqueJoueur = new(GetComponent<Rigidbody2D>());
    }

    /// <summary>
    /// Assignement de la logique m�tier et des �v�nements.
    /// </summary>
    private void Start()
    {

        etatsJeu = EtatsJeu.GetInstanceEtatsJeu();

        // Ev�nements d�clench�s par le pilote.
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
