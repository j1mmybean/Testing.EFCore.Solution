using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
    public class AdministratorRepository
    {
        InseparableEntities InseparableDb = new InseparableEntities();

        public IQueryable<Administrators> Search(string AdministratorID, string lastName, string firstName)
        {
            IQueryable<Administrators> search = InseparableDb.Administrators;

            if (AdministratorID != string.Empty)
            {
                search = search.Where(o => o.AdministratorID.ToString().Contains(AdministratorID));
            }
            else
            {

            }

            if (string.IsNullOrEmpty(lastName) == false) { search = search.Where(o => o.LastName.Contains(lastName)); }
            if (string.IsNullOrEmpty(firstName) == false) { search = search.Where(o => o.FirstName.Contains(firstName)); }

            return search;
        }

        public IQueryable<Administrators> GetAdministrator(int memberID)
        {
            var result = InseparableDb.Administrators.Where(o => o.AdministratorID == memberID);

            return result;
        }

        public IQueryable<Administrators> GetAdministratorByEmail(string email)
        {
            var result = InseparableDb.Administrators.Where(o => o.Email == email);

            return result;
        }
    }
}
