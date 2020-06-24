using System.Collections.Generic;
using Model;

namespace Service
{
    public interface IFootballService
    {
        IEnumerable<Standing> GetStandings(string country, string league, string team);
    }
}