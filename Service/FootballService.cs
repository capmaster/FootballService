using System.Collections.Generic;
using Model;
using System.Linq;
using System;

namespace Service
{
    public class FootballService : IFootballService
    {
       public IEnumerable<Standing> GetStandings(string country, string league, string team)
       {
           var url = "https://apiv2.apifootball.com/?action=get_standings&league_id=148&APIkey=9bb66184e0c8145384fd2cc0f7b914ada57b4e8fd2e4d6d586adcc27c257a978";
           var httpHelper =  new HttpHelper();
           var standings =  httpHelper.Get<List<Standing>>(url).Result; 

           var filteredStandings = standings.Where(s=> String.Equals(s.country_name, country , StringComparison.CurrentCultureIgnoreCase)  &&  
                                                        String.Equals(s.league_name, league , StringComparison.CurrentCultureIgnoreCase)  &&  
                                                        String.Equals(s.team_name, team , StringComparison.CurrentCultureIgnoreCase));
                                                  
           return filteredStandings;
       }
    }
}
