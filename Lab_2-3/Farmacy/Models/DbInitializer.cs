using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Farmacy.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<ItemContext>
    {
        protected override void Seed(ItemContext db)
        {
            db.Items.Add(new Item { Name = "Парацетамол", Company = "фарм",Description = "wefwbfiebfibf", Image="1.jpg", Price = 220 });
            db.Items.Add(new Item { Name = "Каметон", Company = "мраф", Description = "wefwbfiebfibf", Image = "2.jpg", Price = 180 });
            db.Items.Add(new Item { Name = "Анальгин", Company = "пром", Description = "wefwbfiebfibf", Image = "3.jpg", Price = 150 });
            db.Items.Add(new Item { Name = "Уголь акт.", Company = "Renewal", Description = "wefwbfiebfibf hfhf fhfhdhs dfjd fjjd", Image = "4.jpg", Price = 50 });
            db.Items.Add(new Item { Name = "Гексорал", Company = "Фарм Орлеан", Description = "wefwbfiebfibf ывп ынвра уоа агвга уу ", Image = "5.jpg", Price = 250 });
            db.Items.Add(new Item { Name = "Компливит", Company = "фарм", Description = "wefwbfiebfibf ввпв ррв вррв врруо оп в", Image = "6.jpg", Price = 300 });
            db.Items.Add(new Item { Name = "Перекись водорода", Company = "пром", Description = "wefwbfiebfibfп ппр пр п пппгпгп  пгп г ", Image = "7.jpg", Price = 30 });
            base.Seed(db);
        }
    }
}