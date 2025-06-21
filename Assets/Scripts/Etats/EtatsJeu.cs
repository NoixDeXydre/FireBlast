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

    public event OnBooleenModifie OnChangementEstPartieTerminee;

    // Etats disponibles du jeu

    /// <summary>
    /// S'active lorsque le joueur n'a plus de vie.
    /// </summary>
    public bool EstPartieTerminee
    {
        get { return _estPartieTerminee; }
        set
        {
            AppelerEvenementSurNouvelleValeur(OnChangementEstPartieTerminee, _estPartieTerminee, value);
            _estPartieTerminee = value;
        }
    }

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

    private bool _estPartieTerminee = false;
    private bool _sontMouvementsBloqueesParDommage = false;
    private bool _sontMouvementsBloqueesParJeu = false;

    // M�thodes

    private static void AppelerEvenementSurNouvelleValeur(OnBooleenModifie evenement,
        bool ancienneValeur, bool nouvelleValeur)
    {

        if (ancienneValeur != nouvelleValeur)
        {
            evenement?.Invoke(nouvelleValeur);
        }
    }
}
