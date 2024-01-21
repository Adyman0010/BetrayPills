using Exiled.API.Interfaces;
using LiteNetLib.Utils;

namespace BetrayPills
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public BetrayPills BetrayPills = new BetrayPills();
    }
}