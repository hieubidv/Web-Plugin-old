
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;
namespace ICreative.Controllers
{
    public class SingletonRestrictionCollection
    {
        private static SingletonRestrictionCollection instance = null;
        private static Dictionary<string, string> restrictions = null;

        private static readonly object padlock = new object();

        private SingletonRestrictionCollection() { }

        public static SingletonRestrictionCollection Restrictions
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonRestrictionCollection();
                            restrictions = new Dictionary<string, string>();
                        }
                    }
                }
                return instance;
            }
        }

        public void LoadRestriction(IRestrictionService restrictionService)
        {
            IEnumerable<RestrictionView> restricts = restrictionService.GetAllRestrictions().Restrictions;
            restrictions.Clear();
            foreach (RestrictionView restrict in restricts)
            {
                if (!restrictions.ContainsKey(restrict.RestrictionName))
                    restrictions.Add(restrict.RestrictionName, restrict.RequirePermission);
            }
        }

        public string this[string key]
        {
            get
            {
                if (!restrictions.ContainsKey(key))
                    return string.Empty;
                return restrictions[key];
            }
        }


    }
}
