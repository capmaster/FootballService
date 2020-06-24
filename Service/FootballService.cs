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
           //todo: move this to separate class
           var httpHelper =  new HttpHelper();

           //todo: move this to appsetiings
           var url = "https://apiv2.apifootball.com/?action=get_standings&league_id=148&APIkey=9bb66184e0c8145384fd2cc0f7b914ada57b4e8fd2e4d6d586adcc27c257a978";
           
           List<Filter> filter = new List<Filter>();
           if(!string.IsNullOrEmpty(country)) 
           {
               country = country.ToLower();
               filter.Add(new Filter { PropertyName = "country_name", Operation = Op .Equals, Value = country });
           }
            if(!string.IsNullOrEmpty(league)) 
            {
                league = league.ToLower();
                filter.Add(new Filter { PropertyName = "league_name", Operation = Op .Equals, Value = league });
            }
            if(!string.IsNullOrEmpty(team)) 
            {
                team = team.ToLower();
                filter.Add(new Filter { PropertyName = "team_name", Operation = Op .Equals, Value = team });
            }
           var deleg = ExpressionBuilder.GetExpression<Standing>(filter).Compile();

           var standings =  httpHelper.Get<List<Standing>>(url).Result; 

           standings = standings.Select(s=> new Standing{ country_name=s.country_name.ToLower(),
                                                league_name=s.league_name.ToLower(),
                                                team_name=s.team_name.ToLower(),
                                                league_id = s.league_id,
                                                team_id=s.team_id,
                                                overall_league_position=s.overall_league_position
                                            }).ToList();

           var filteredStandings = standings.Where(deleg);
                                                  
           return filteredStandings;
       }
    }
}
