using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Timers;

namespace DuckSpeed;

public class DuckSpeed : BasePlugin
{
    public override string ModuleAuthor => "thesamefabius";
    public override string ModuleName => "Duck Speed";
    public override string ModuleVersion => "v1.0.0";

    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnTick>(() =>
        {
            foreach (var player in Utilities.GetPlayers()
                         .Where(player => player is { IsBot: false, IsValid: true, PawnIsAlive: true }))
            {
                if (player.Buttons.HasFlag(PlayerButtons.Duck))
                {
                    var movementService = player.PlayerPawn.Value.MovementServices;
                    if (movementService != null)
                    {
                        //я пойду в магазин | i going shopping
                        new CCSPlayer_MovementServices(movementService.Handle).DuckSpeed = 6.023437f;
                    }
                }
            }
        });
    }
}
