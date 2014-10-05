using System.Data.Entity;

namespace AngularWebApiGrid.Models
{
    public class DemoInitializer : DropCreateDatabaseIfModelChanges<DemoContext>
    {
        protected override void Seed(DemoContext context)
        {
            base.Seed(context);
        }
    }
}