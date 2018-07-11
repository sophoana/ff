using System;
using FF.Data.Models;

namespace FF.Data.Helpers
{
    public class AuditHelper
    {
        public static void SetAuditFieldsOnSave(UpdateableModel model, DateTime now, int currentUserId)
        {
            model.UpdatedBy = currentUserId;
            model.UpdatedWhen = now;

            if (model.AddedBy == 0)
            {
                model.AddedBy = currentUserId;
                model.AddedWhen = now;
            }
            
        }
    }
}
