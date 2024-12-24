using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud11.Models
{
    public partial class Client
    {
        public string SearchText
        {
            get
            {
                return (" " + Firstname + Lastname + Patronymic+Email+PhoneNumber).ToLower();
            }
        }
        public DateTime LastVisit
        {
            get
            {
                var listVisit = App.DB.Visit.Where(x => x.ClientId == this.Id).ToList();
                return listVisit.OrderByDescending(x=>x.Date).Last().Date;
            }
        }
        public int CounVisit
        {
            get
            {
                return App.DB.Visit.Where(x=>x.ClientId==this.Id).Count();
            }
        }
        public List<Tag> Tags
        {
            get
            {
                return App.DB.ClientTag.Where(x => x.ClientId == this.Id).Select(x=>x.Tag).ToList();
            }
        }
    }
}
