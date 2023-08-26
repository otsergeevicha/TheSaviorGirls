using Plugins.MonoCache;
using TMPro;
using UnityEngine;

namespace CanvasesLogic.LeaderboardModule
{
    public class MemberLeaderboard : MonoCache
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _score;

        public void UpdateData(string rank, string name, string score)
        {
            _rank.text = rank;
            _name.text = name;
            _score.text = score;
        }
    }
}