using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities.Common
{
    /// <summary>
    /// Represents the base Entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// gets or sets Identifier of this Entity
        /// </summary>
        public int Id { get; set; }
    }
}
