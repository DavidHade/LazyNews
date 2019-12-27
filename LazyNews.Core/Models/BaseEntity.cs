using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LazyNews.Core.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public string id { get; set; }
        public string Headline { get; set; }

        public BaseEntity()
        {

        }
    }
}
