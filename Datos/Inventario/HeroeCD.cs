using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Inventario;

namespace Datos.Inventario
{
    public class HeroeCD
    {

        public static List<ListarHeroesResult> Listar()
        {
            BDDataContext DB = new BDDataContext();
            try
            {

                using (BDDataContext bd = new BDDataContext())
                {
                    return DB.ListarHeroes().ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar desde la base de datos en CD", ex);
            }
            finally
            {
                DB = null;

            }
        }

        public static List<ListarHeroes_FiltroResult> Listar_Filro(string val)
        {
            BDDataContext DB = new BDDataContext();
            try
            {

                using (BDDataContext bd = new BDDataContext())
                {
                    return DB.ListarHeroes_Filtro(val).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar con filtro desde la base de datos en CD", ex);
            }
            finally
            {
                DB = null;

            }
        }

        public static List<ObtenerHeroe_IDResult> Obtener_Id(int id)
        {
            BDDataContext DB = null;
            try
            {
                using (DB = new BDDataContext())
                {
                    return DB.ObtenerHeroe_ID(id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al obtener por ID en CD", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void Insertar(Heroe obj)
        {
            BDDataContext DB = null;
            try
            {
                using (DB = new BDDataContext())
                {
                    DB.InsertarHeroe(obj.HeroID, obj.RealName, obj.Alias, 
                        obj.Abilities, obj.History, obj.Seasons, obj.ActorName);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar en CD", ex);
            }
            finally
            {
                DB = null;
            }
        }
        
        public static void Modificar(Heroe obj)
        {
            BDDataContext DB = null;
            try
            {
                using (DB = new BDDataContext())
                {
                    DB.ActualizarHeroe(obj.HeroID, obj.RealName, obj.Alias,
                        obj.Abilities, obj.History, obj.Seasons, obj.ActorName);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar en CD", ex);
            }
            finally
            {
                DB = null;
            }
        }
        
        public static void Eliminar(Heroe obj)
        {
            BDDataContext DB = null;
            try
            {
                using (DB = new BDDataContext())
                {
                    DB.EliminarHeroe(obj.HeroID);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar en CD", ex);
            }
            finally
            {
                DB = null;
            }
        }


    }
}
