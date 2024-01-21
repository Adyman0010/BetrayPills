using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using PlayerRoles;

namespace BetrayPills
{
    public class BetrayPills : CustomItem
    {
        public override uint Id { get; set; } = 999;

        public override string Name { get; set; } = "Betray Pills";

        public override string Description { get; set; } = "Po požití změní tvůj team na protivníky";

        public override float Weight { get; set; } = 1;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>()
            {
                new DynamicSpawnPoint()
                {
                    Chance = 10,
                    Location = SpawnLocationType.InsideNukeArmory
                }
            }
        };

        protected override void SubscribeEvents()
        {
            Player.UsedItem += OnUsed;
            
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.UsedItem -= OnUsed;
            
            base.UnsubscribeEvents();
        }

        private void OnUsed(UsedItemEventArgs ev)
        {
            switch (ev.Player.Role.Type)
            {
                case RoleTypeId.ClassD:
                    ev.Player.Role.Set(RoleTypeId.Scientist);
                    ev.Player.ShowHint("Měním tě na Scientistu!");
                    break;
                
                case RoleTypeId.Scientist:
                    ev.Player.Role.Set(RoleTypeId.ClassD);
                    ev.Player.ShowHint("Měním tě na Class-D!");
                    break;
                
                case RoleTypeId.FacilityGuard:
                    ev.Player.Role.Set(RoleTypeId.ChaosRifleman);
                    ev.Player.ShowHint("Měním tě na Chaos Rifleman!");
                    break;
                
                case RoleTypeId.NtfCaptain:
                    ev.Player.Role.Set(RoleTypeId.ChaosRepressor);
                    ev.Player.ShowHint("Měním tě na Chaos Repressor!");
                    break;
                
                case RoleTypeId.NtfSergeant:
                    ev.Player.Role.Set(RoleTypeId.ChaosMarauder);
                    ev.Player.ShowHint("Měním tě na Chaos Marauder!");
                    break;
                
                case RoleTypeId.NtfPrivate:
                    ev.Player.Role.Set(RoleTypeId.ChaosRifleman);
                    ev.Player.ShowHint("Měním tě na Chaos Rifleman!");
                    break;
                
                case RoleTypeId.ChaosRepressor:
                    ev.Player.Role.Set(RoleTypeId.NtfCaptain);
                    ev.Player.ShowHint("Měním tě na MTF Kapitána!");
                    break;
                
                case RoleTypeId.ChaosMarauder:
                    ev.Player.Role.Set(RoleTypeId.NtfSergeant);
                    ev.Player.ShowHint("Měním tě na MTF Seržanta!");
                    break;
                
                case RoleTypeId.ChaosRifleman:
                    ev.Player.Role.Set(RoleTypeId.NtfPrivate);
                    ev.Player.ShowHint("Měním tě na MTF Vojína!");
                    break;
                
                case RoleTypeId.ChaosConscript:
                    ev.Player.Role.Set(RoleTypeId.NtfPrivate);
                    ev.Player.ShowHint("Měním tě na MTF Vojína!");
                    break;
            }
        }
    }
}