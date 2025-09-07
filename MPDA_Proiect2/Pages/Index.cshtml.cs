using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MPDA_Proiect2.Actions;
using MPDA_Proiect2.Factories;
using MPDA_Proiect2.Models.Interfaces;
using MPDA_Proiect2.Services;

public class IndexModel : PageModel
{
    private readonly GameEngine _engine;
    private static readonly Random rng = new(); 
    [BindProperty]
    public string Area { get; set; }
    [BindProperty]
    public int PlayerIndex { get; set; } = 0;

    [BindProperty]
    public string ActionType { get; set; }

    [BindProperty]
    public int TargetIndex { get; set; }
    public HashSet<int> PlayersActed { get; set; } = new();


    public List<ICharacter> Players => _engine.Players;
    public List<ICharacter> Enemies => _engine.Enemies;
    public List<string> BattleLog => _engine.BattleLog;

    public bool IsBattleOver => Players.All(p => p.Health <= 0) || Enemies.All(e => e.Health <= 0);

    public IndexModel(GameEngine engine)
    {
        _engine = engine;
        if (!_engine.Players.Any()) _engine.Initialize();
    }

    public void OnGet() { }
    public void OnPost(string selectArea, string updatePlayer, string performAction)
    {
        if (!string.IsNullOrEmpty(selectArea))
        {
            if (string.IsNullOrEmpty(Area)) return;

            _engine.Enemies.Clear();
            _engine.Enemies.AddRange(CharacterFactory.GetEnemiesForArea(Area));

            _engine.BattleLog.Clear();
            _engine.BattleLog.Add($"You entered the {Area}.");
            return;
        }

        if (Request.Form.ContainsKey("retryBattle"))
        {
            _engine.Initialize();
            return;
        }

        if (!string.IsNullOrEmpty(updatePlayer))
        {
            return;
        }

        if (!string.IsNullOrEmpty(performAction))
        {
            if (IsBattleOver) return;

            _engine.PlayerAction(PlayerIndex, ActionType, TargetIndex);
        }
    }

}
