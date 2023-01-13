using Codebase.Extensions;
using Codebase.Hero;
using Codebase.Services.HeroUpgradeService;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.UI
{
  public class HudScreen : MonoBehaviour
  {
    [field: SerializeField] private TextMeshProUGUI KillCountTxt { get; set; }
    [field: SerializeField] private TextMeshProUGUI DamageTxt { get; set; }
    [field: SerializeField] private TextMeshProUGUI AttackRangeTxt { get; set; }
    [field: SerializeField] private TextMeshProUGUI Speed { get; set; }
    [field: SerializeField] private Button UpgradeBtn { get; set; }

    private HeroModel _heroModel;
    private IHeroUpgradeService _upgradeService;

    [Inject]
    public void Construct(IHeroUpgradeService upgradeService)
    {
      _upgradeService = upgradeService;
    }

    public void Init(HeroModel heroModel)
    {
      _heroModel = heroModel;
      _heroModel.KillCount.SubscribeToText(KillCountTxt).AddTo(this);
      _heroModel.Attack.Damage.SubscribeToText(DamageTxt).AddTo(this);
      _heroModel.Attack.Range.SubscribeToText(AttackRangeTxt).AddTo(this);
      _heroModel.Speed.SubscribeToText(Speed).AddTo(this);
    }

    private void Start()
    {
      UpgradeBtn.onClick.AddListener(UpgradeRandom);
    }

    private void UpgradeRandom()
    {
      _upgradeService.UpgradeRandom(_heroModel);
    }
  }
}
