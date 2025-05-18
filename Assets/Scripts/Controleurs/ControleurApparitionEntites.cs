using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Fait appara�tre les entit�s dans la carte au bon moment,
/// et selon l'�tat du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    /// <summary>
    /// D�lais avant que le jeu regarde les entit�s � faire appara�tre.
    /// </summary>
    private const float TempsAttenteUsine = .5f;

    /// <summary>
    /// La map o� les entit�s vont appara�tre.
    /// </summary>
    public Tilemap map;

    private CreateurEntites usineEntites;
    private MapVirtuelle mapVirtuelle;

    private PrefabsBD prefabsBD;

    /// <summary>
    /// Initialise les composants pour rep�rer la map.
    /// </summary>
    private void Start()
    {

        mapVirtuelle = new(map);
        usineEntites = new(mapVirtuelle);

        prefabsBD = Resources.Load<PrefabsBD>(nameof(PrefabsBD));

        // On cr�e le joueur
        usineEntites.CreerEntite(prefabsBD.joueur, mapVirtuelle.GetCentreMap());
        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de v�rifier les entit�s � cr�er.
    /// </summary>
    private void IterationTournageUsine()
    {
        SousIterationCollectibles();
        Invoke(nameof(IterationTournageUsine), TempsAttenteUsine);
    }

    private void SousIterationCollectibles()
    {
        usineEntites.CreerEntite(prefabsBD.collectiblePiece, 
            Aleatoire.ChoisirPointParmisDeuxAxes(mapVirtuelle.GetCoordonneesIntervallesX(), mapVirtuelle.GetCoordonneesIntervallesY()));
    }
}
