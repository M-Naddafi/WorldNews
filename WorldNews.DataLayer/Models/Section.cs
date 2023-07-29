using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldNews.DataLayer.Models
{
    public class Section
    {
        public Section()
        {
        }


        [Key]
        public int SectionId { get; set; }

        
        public string SectionName { get; set; }


        #region Relations

        public virtual List<News> News { get; set; }

        #endregion
    }
}

