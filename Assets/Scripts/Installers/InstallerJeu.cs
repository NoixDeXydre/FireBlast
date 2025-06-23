using UnityEngine;
using Zenject;

/// <summary>
/// Défini les dépendances à un injecter dans la scène Jeu.
/// </summary>
public class InstallerJeu : MonoInstaller
{

    /// <summary>
    /// Défini et injecte
    /// </summary>
    public override void InstallBindings()
    {

        // Base de données

        Container.Bind<CollectionEcransChargement>().FromResource(nameof(CollectionEcransChargement));
        Container.Bind<CollectionEntites>().FromResource(nameof(CollectionEntites));

        // Composants principaux

        Container.Bind<EtatsJeu>().AsSingle();

        Container.Bind<MapVirtuelle>().FromComponentInHierarchy().AsSingle();

        Container.Bind<EntitesCreateur>().AsSingle();

        // Contrôleurs 
        Container.Bind<ControleurScore>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurTemps>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurVie>().FromComponentInHierarchy().AsSingle();

        // Usines
        Container.BindInterfacesAndSelfTo<UsineJoueur>().AsSingle();
        Container.BindInterfacesAndSelfTo<EntitesGroupePool>().AsSingle().WithArguments(200);
    }
}