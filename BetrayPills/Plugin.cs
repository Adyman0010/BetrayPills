using Exiled.API.Features;
using Exiled.CustomItems.API.Features;

namespace BetrayPills
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Adyman0010";

        public override string Name { get; } = "BetrayPills";

        public override string Prefix { get; } = "BetrayPills";

        public override void OnEnabled()
        {
            CustomItem.RegisterItems();
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();
            
            base.OnDisabled();
        }
    }
}