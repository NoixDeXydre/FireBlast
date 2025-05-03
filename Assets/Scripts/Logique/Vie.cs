/// <summary>
/// Composant g�rant la vie d'un joueur.
/// </summary>
public class Vie
{

    /// <summary>
    /// Nombre de vie maximum d'un joueur.
    /// </summary>
    private const int NombreVieMax = 3;

    /// <summary>
    /// Nombre de vie actuel du joueur.
    /// </summary>
    private int vies;

    public Vie()
    {
        vies = NombreVieMax;
    }

    /// <summary>
    /// Diminuer la vie d'un joueur d'une unit�.
    /// </summary>
    public void DiminuerVies()
    {
        SetVies(GetVies() - 1);
    }

    /// <returns>Les vies du joueur</returns>
    public int GetVies()
    {
        return vies;
    }

    /// <summary>
    /// Incr�mente la vie d'un joueur d'une unit�.
    /// </summary>
    public void IncrementerVies()
    {
        SetVies(GetVies() + 1);
    }

    /// <summary>
    /// Red�fini le nombre de vies pour le joueur.
    /// La vie ne pourra pas d�passer le seuil entre 0 et NombreVieMax.
    /// </summary>
    public void SetVies(int vies)
    {

        if (vies <= NombreVieMax && vies >= 0)
        {
            this.vies = vies;
        }
    }
}
