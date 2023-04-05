using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
    public class ActivityRepository
    {
        InseparableEntities InseparableDb = new InseparableEntities();

        public IQueryable<Activities> Search(string ActivityID, string title) //, DateTime dateTime)
        {
            IQueryable<Activities> search = InseparableDb.Activities;

            if (ActivityID != string.Empty) { search = search.Where(o => o.ActivityID.ToString().Contains(ActivityID)); }
            if (string.IsNullOrEmpty(title) == false) { search = search.Where(o => o.ActivityTitle.Contains(title)); }

            // todo 用時間查詢未完成
            //if (dateTime < DateTime.Now) { search = search.Where( o => o.DateTime == dateTime ); }

            return search;
        }

        public IQueryable<Activities> GetActivity(int ActivityID)
        {
            var result = InseparableDb.Activities.Where(o => o.ActivityID == ActivityID);

            return result;
        }
    }
}
