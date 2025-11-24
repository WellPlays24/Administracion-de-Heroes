using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Inventario;
using Entidades.Inventario;

namespace Logica.Inventario
{
    public class HeroeLN
    {

        public List<Heroe> ShowFiltro(string val)
        {
            List<Heroe> lista = new List<Heroe>();
            Heroe cli;

            try
            {
                var aux = HeroeCD.Listar_Filro(val);
                foreach (var h in aux)
                {
                    cli = new Heroe
                    {
                        HeroID = h.HeroID,
                        RealName = h.RealName,
                        Alias = h.Alias,
                        Abilities = h.Abilities,
                        History = h.History,
                        Seasons = h.Seasons,
                        ActorName = h.ActorName
                    };
                    lista.Add(cli);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error in show en LN", ex);
            }

            return lista;
        }

        public List<Heroe> Show()
        {
            List<Heroe> lista = new List<Heroe>();
            Heroe cli;

            try
            {
                var aux = HeroeCD.Listar();
                foreach (var h in aux)
                {
                    cli = new Heroe
                    {
                        HeroID = h.HeroID,
                        RealName = h.RealName,
                        Alias = h.Alias,
                        Abilities = h.Abilities,
                        History = h.History,
                        Seasons = h.Seasons,
                        ActorName = h.ActorName
                    };
                    lista.Add(cli);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar clientes para ComboBox en LN", ex);
            }

            return lista;
        }

        public Heroe GetById(int id)
        {
            try
            {
                var obj = HeroeCD.Obtener_Id(id).FirstOrDefault();
                if (obj != null)
                {
                    return new Heroe
                    {
                        HeroID = obj.HeroID,
                        RealName = obj.RealName,
                        Alias = obj.Alias,
                        Abilities = obj.Abilities,
                        History = obj.History,
                        Seasons = obj.Seasons,
                        ActorName = obj.ActorName
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener por ID en LN", ex);
            }
        }

        public bool Create(Heroe cli)
        {
            try
            {
                HeroeCD.Insertar(cli);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error in Create en LN", ex);
            }
        }

        public bool Update(Heroe cli)
        {
            try
            {
                HeroeCD.Modificar(cli);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar en LN", ex);
            }
        }

        public bool Delete(Heroe cli)
        {
            try
            {
                HeroeCD.Eliminar(cli);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar en LN", ex);
            }
        }

    }
}