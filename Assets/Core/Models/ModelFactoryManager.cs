using Core.Extensions;
using Core.Factory;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using Core.Models.Character;
using Core.Models.SceneLogic;
using UnityEngine;

namespace Core.Models
{
    public static class ModelFactoryManager
    {
        public static FactoryBuilder Factory { get; private set; }
        
        public static void Init(FactoryBuilder factory)
        {
            Factory = factory;
            RegisterSceneLogics();
            RegisterModels();
            RegisterSimpleTypes();
            RegisterBuildableItems();
            RegisterLogicProcessors();
        }

        private static void RegisterLogicProcessors()
        {
            Factory.AddVariantFunc<ILogicProcessor>(Consts.MoveComponent, objects => new TrajectoryMoveLogicProcessor(objects.GetValue<ICharacterModel>(0)));
        }

        private static void RegisterBuildableItems()
        {
            Factory.AddVariantFunc<IBuildable>(Consts.Position, objects => new ModelPosition().BuildItem(objects.GetNode(0)));
        }

        private static void RegisterSimpleTypes()
        {
            Factory.AddVariantFunc<ModelPosition>(objects => new ModelPosition(objects.GetValue<Vector3>(0)));
            Factory.AddVariantFunc<int>(objects => objects.GetInt(0));
        }
        
        private static void RegisterSceneLogics()
        {
            Factory.AddVariantFunc<ISceneLogic>(Consts.StringEmpty, objects => new EmptySceneLogic(objects.GetValue<IMain>(0)));
            Factory.AddVariantFunc<ISceneLogic>(Consts.StartSceneLogic, objects => new StartGameSceneLogic(objects.GetValue<IMain>(0)));
        }

        private static void RegisterModels()
        {
            Factory.AddVariantFunc<IModel>(Consts.Scene, objects => new SceneModel(objects.GetValue<UserData>(0), objects.GetValue<ISceneConfig>(1)));
            Factory.AddVariantFunc<IModel>(Consts.Location, objects => new LocationModel(objects.GetValue<UserData>(0), objects.GetValue<ILocationConfig>(1), objects.TryGetNode(2)));
           
            Factory.AddVariantFunc<ICharacterModel>(Consts.Character, objects => new Character.Character(objects.GetValue<UserData>(0), objects.GetValue<ICharacterConfig>(1), objects.TryGetNode(2)));

            Factory.AddVariantFunc<ILocationObjectModel>(Consts.StringEmpty, objects => new SimpleLocationObject(objects.GetValue<UserData>(0), objects.GetValue<ILocationObjectConfig>(1)));
            Factory.AddVariantFunc<ILocationObjectModel>(Consts.Simple, objects => new SimpleLocationObject(objects.GetValue<UserData>(0), objects.GetValue<ILocationObjectConfig>(1)));
            Factory.AddVariantFunc<ILocationObjectModel>(Consts.LocationObject, objects => new SimpleLocationObject(objects.GetValue<UserData>(0), objects.GetValue<ILocationObjectConfig>(1)));
        }
    }
}