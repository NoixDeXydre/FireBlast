/// <summary>
/// Singleton rassemblant les états du jeu et leurs évènements.
/// </summary>
public class EtatsJeu
{

    /// <summary>
    /// Interface pour designer la valeur 
    /// de retour lorsqu'un état change via un évènement.
    /// </summary>
    /// <param name="nouvelleValeur">La nouvelle valeur après modification</param>
    public delegate void OnBooleenModifie(bool nouvelleValeur);

    // Evènements pouvant être abonnés 

    // TODO placer des évènements

    // Etats disponibles du jeu

    /// <summary>
    /// S'active si les mouvements du joueur 
    /// sont bloquées d'une quelconque manière.
    /// </summary>
    public bool SontMouvementsBloquees
    {
        get { return SontMouvementsBloqueesParDommage || SontMouvementsBloqueesParJeu; }
    }

    /// <summary>
    /// S'active si les mouvements du joueur sont bloquées 
    /// à cause d'un dégât subit.
    /// </summary>
    public bool SontMouvementsBloqueesParDommage
    {
        get { return _sontMouvementsBloqueesParDommage; }
        set { _sontMouvementsBloqueesParDommage = value; }
    }

    /// <summary>
    /// S'active si les mouvements du joueur sont bloquées 
    /// à cause d'un dégât subit.
    /// </summary>
    public bool SontMouvementsBloqueesParJeu
    {
        get { return _sontMouvementsBloqueesParJeu; }
        set { _sontMouvementsBloqueesParJeu = value; }
    }

    // Référence des états

    private bool _sontMouvementsBloqueesParDommage = false;
    private bool _sontMouvementsBloqueesParJeu = false;

    /// <summary>
    /// Instance globale des états.
    /// </summary>
    private static EtatsJeu instanceEtatsJeu;

    // Méthodes

    /// <returns>Une instance du singleton</returns>
    public static EtatsJeu GetInstanceEtatsJeu()
    {

        if (instanceEtatsJeu != null)
        {
            return instanceEtatsJeu;
        }

        instanceEtatsJeu = new();
        return instanceEtatsJeu;
    }

    private static void AppelerEvenementSurNouvelleValeur(OnBooleenModifie evenement,
        bool ancienneValeur, bool nouvelleValeur)
    {

        if (ancienneValeur != nouvelleValeur)
        {
            evenement?.Invoke(nouvelleValeur);
        }
    }
}
