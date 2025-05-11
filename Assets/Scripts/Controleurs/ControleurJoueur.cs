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
public class ControleurJoueur : MonoBehaviour
{

    /// <summary>
    /// Pilote permettant de capturer les clics de la souris.
    /// </summary>
    public ControleurSouris scriptPiloteSouris;

    /// <summary>
    /// Logique pour mouvoir le joueur.
    /// </summary>
    private PhysiqueJoueur physiqueJoueur;

    private EtatsJeu etatsJeu;

    /// <summary>
    /// Assignement de la logique métier et des évènements.
    /// </summary>
    private void Start()
    {

        etatsJeu = EtatsJeu.GetInstanceEtatsJeu();

        physiqueJoueur = GestionJeuUtils.GetScriptGestionJeu().physiqueJoueur;

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
