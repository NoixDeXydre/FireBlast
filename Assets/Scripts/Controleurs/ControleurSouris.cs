using UnityEngine;

/// <summary>
/// G�re la notification des �v�nements
/// suite aux clics de la souris, et donne des informations
/// visuelles et num�riques en cons�quence.
/// </summary>
public class ControleurSouris : MonoBehaviour
{

    // TODO input buffer

    // TODO
    /// <summary>
    /// Se d�clenche lorsque le joueur clique.
    /// </summary>
    // public event Action SourisClicActionne;

    /// <summary>
    /// Se d�clenche lorsque le joueur clique et glisse la souris.
    /// </summary>
    public event CallbackSourisClicEnfonce SourisClicEnfonce;

    /// <summary>
    /// Se d�clenche lorsque le joueur rel�che apr�s avoir cliqu�.
    /// </summary>
    public event CallbackSourisClicRelache SourisClicRelache;

    /// <summary>
    /// Callback SourisClicEnfonce
    /// </summary>
    /// <param name="estEnfoncementSansGlissement">
    /// Informe si le joueur glisse sa souris ou non.
    /// </param>
    public delegate void CallbackSourisClicEnfonce(bool estEnfoncementSansGlissement);

    /// <summary>
    /// Callback SourisClicRelache
    /// </summary>
    /// <param name="vecteurDirectionEnfoncement">
    /// Donne des informations sur le glissement de la souris (si pr�sent)
    /// </param>
    public delegate void CallbackSourisClicRelache(Vector2 vecteurDirectionEnfoncement);

    /// <summary>
    /// La cam�ra qui suit le joueur.
    /// </summary>
    public Camera cameraJoueur;

    /// <summary>
    /// La cam�ra qui repr�sente pr�cis�ment les coordonn�es du monde.
    /// </summary>
    public Camera cameraReference;

    /// <summary>
    /// Surface pouvant �tre cliqu�e.
    /// </summary>
    private BoxCollider2D ecranHitbox;

    /// <summary>
    /// Logique m�tier pour la souris.
    /// </summary>
    private ControlesSouris controlesSouris;

    private void Start()
    {
        controlesSouris = new ControlesSouris(cameraReference);
        ecranHitbox = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Permet de suivre la surface cliquable vers le joueur.
    /// </summary>
    private void Update()
    {
        ecranHitbox.offset = cameraJoueur.transform.position;
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// clique une fois avec la souris.
    /// </summary>
    private void OnMouseDown()
    {
        // TODO
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// enfonce et glisse la souris.
    /// </summary>
    private void OnMouseDrag()
    {
        controlesSouris.UpdateOnEnfoncement();
        OnSourisClicEnfonce();
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// relache le clic de la souris.
    /// </summary>
    private void OnMouseUp()
    {
        controlesSouris.UpdateOnRelachement();
        OnSourisClicRelache();
    }

    protected virtual void OnSourisClicEnfonce()
    {
        SourisClicEnfonce?.Invoke(controlesSouris.EstEnfoncementSansGlissement());
    }

    protected virtual void OnSourisClicRelache()
    {
        SourisClicRelache?.Invoke(controlesSouris.GetVecteurEnfoncement());
    }
}
