using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
    public class MemberRepository
    {
        InseparableEntities InseparableDb = new InseparableEntities();

        public IQueryable<Members> Search(string memberID, string lastName, string firstName)
        {
            IQueryable<Members> search = InseparableDb.Members;

            if (memberID != string.Empty) { search = search.Where(o => o.MemberID.ToString().Contains(memberID)); }
            if (string.IsNullOrEmpty(lastName) == false) { search = search.Where(o => o.LastName.Contains(lastName)); }
            if (string.IsNullOrEmpty(firstName) == false) { search = search.Where(o => o.FirstName.Contains(firstName)); }

            return search;
        }

        public IQueryable<Members> GetMember(int memberID)
        {
            var result = InseparableDb.Members.Where(o => o.MemberID == memberID);

            return result;
        }

        public IQueryable<Members> GetMemberByEmail(string email)
        {
            var result = InseparableDb.Members.Where(o => o.Email == email);

            return result;
        }
    }
}
