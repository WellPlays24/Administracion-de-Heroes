using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Heroe
    {

        public int HeroID { get; set; }
        public string RealName { get; set; }

        public string Alias { get; set; }

        public string Abilities { get; set; }

        public string History { get; set; }

        public string Seasons { get; set; }

        public string ActorName { get; set; }

        public Heroe(int heroID, string realName, string alias, string abilities, string history, string seasons, string actorName)
        {
            HeroID = heroID;
            RealName = realName;
            Alias = alias;
            Abilities = abilities;
            History = history;
            Seasons = seasons;
            ActorName = actorName;
        }

        public Heroe() { }

    }
}
