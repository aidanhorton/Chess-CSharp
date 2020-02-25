using Chess.Model.Board;
using Unity;

namespace Chess.Unity
{
    public class ServiceLocator
    {
        private ServiceLocator()
        {
            // Prevent outside instantiation.
        }

        static ServiceLocator()
        {
            RegisterTypes();
        }

        public static IUnityContainer Container { get; } = new UnityContainer();

        private static void RegisterTypes()
        {
            Container.RegisterType<IBoardUpdate, BoardStore>();
        }
    }
}