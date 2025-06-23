using UnityEngine;
using Zenject;

/// <summary>
/// Usine permettant de créer un joueur.
/// </summary>
public class UsineJoueur : IFactory<Vector3, Joueur>
{

    [Inject] private readonly DiContainer _container;
    [Inject] private readonly CollectionEntites _db;

    /// <summary>
    /// Instancie un joueur
    /// </summary>
    /// <param name="position">La position du joueur</param>
    /// <returns></returns>
    public Joueur Create(Vector3 position)
    {
        return _container.InstantiatePrefabForComponent<Joueur>(_db.datasetJoueur.entite,
            position, Quaternion.identity, null);
    }
}