/// <summary>
/// Singleton rassemblant les �tats du jeu et leurs �v�nements.
/// </summary>
public class EtatsJeu
{

    /// <summary>
    /// Interface pour designer la valeur 
    /// de retour lorsqu'un �tat change via un �v�nement.
    /// </summary>
    /// <param name="nouvelleValeur">La nouvelle valeur apr�s modification</param>
    public delegate void OnBooleenModifie(bool nouvelleValeur);

    // Ev�nements pouvant �tre abonn�s 

    // TODO placer des �v�nements

    // Etats disponibles du jeu

    /// <summary>
    /// S'active si les mouvements du joueur 
    /// sont bloqu�es d'une quelconque mani�re.
    /// </summary>
    public bool SontMouvementsBloquees
    {
        get { return SontMouvementsBloqueesParDommage || SontMouvementsBloqueesParJeu; }
    }

    /// <summary>
    /// S'active si les mouvements du joueur sont bloqu�es 
    /// � cause d'un d�g�t subit.
    /// </summary>
    public bool SontMouvementsBloqueesParDommage
    {
        get { return _sontMouvementsBloqueesParDommage; }
        set { _sontMouvementsBloqueesParDommage = value; }
    }

    /// <summary>
    /// S'active si les mouvements du joueur sont bloqu�es 
    /// � cause d'un d�g�t subit.
    /// </summary>
    public bool SontMouvementsBloqueesParJeu
    {
        get { return _sontMouvementsBloqueesParJeu; }
        set { _sontMouvementsBloqueesParJeu = value; }
    }

    // R�f�rence des �tats

    private bool _sontMouvementsBloqueesParDommage = false;
    private bool _sontMouvementsBloqueesParJeu = false;

    /// <summary>
    /// Instance globale des �tats.
    /// </summary>
    private static EtatsJeu instanceEtatsJeu;

    // M�thodes

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
