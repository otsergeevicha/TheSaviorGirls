using Agava.YandexGames;
using CanvasesLogic.Authorization;
using CanvasesLogic.Menu;
using Plugins.MonoCache;
using Services.SaveLoad;
using UnityEngine;

namespace CanvasesLogic.LeaderboardModule
{
    public class LeaderboardScreen : MonoCache, IWindow
    {
        [SerializeField] private MemberLeaderboard[] _members;
        
        private ISave _save;
        private AuthorizationScreen _authorizationScreen;
        private MenuScreen _menuScreen;
        
        public void Inject(ISave save, AuthorizationScreen authorizationScreen, MenuScreen menuScreen)
        {
            _menuScreen = menuScreen;
            _authorizationScreen = authorizationScreen;
            _save = save;
        }
        
        public void OnActive()
        {
#if !UNITY_WEBGL || !UNITY_EDITOR
            if (PlayerAccount.IsAuthorized)
            {
                Leaderboard.SetScore(Constants.Leaderboard, _save.AccessProgress().DataWallet.Read());
                GetLeaderboardEntries();
                return;
            }

            if (!PlayerAccount.IsAuthorized)
                _authorizationScreen.OnActive();

#endif
            gameObject.SetActive(true);
        }
        
        public void GetLeaderboardEntries()
        {
            Leaderboard.GetEntries(Constants.Leaderboard, (result) =>
            {
                for (int i = 0; i < result.entries.Length; i++)
                    _members[i].UpdateData(result.entries[i].rank.ToString(), NameCorrector(result.entries[i].player.publicName),
                        result.entries[i].score.ToString());
            }, null, Constants.TopPlayersCount, Constants.CompletingPlayersCount);

            gameObject.SetActive(true);
        }
        
        public void SelectBack()
        {
            _menuScreen.OnActive();
            InActive();
        }

        public void InActive() => 
            gameObject.SetActive(false);
        
        private string NameCorrector(string nameMember)
        {
            if (string.IsNullOrEmpty(nameMember))
                nameMember = Constants.Anonymous;

            return nameMember;
        }
    }
}