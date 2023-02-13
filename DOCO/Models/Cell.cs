using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DOCO.Models
{
    /// <summary>
    /// A single cell of the simulation.
    /// </summary>
    [XmlRoot()]
    internal class Cell
    {
        #region Public Fields
        public int x;
        public int y;
        public DOCOs.Base occupant;
        #endregion

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #region Public Functions
        /// <summary>
        /// Check whether the cell is empty.
        /// </summary>
        /// <returns>True if the cell currently contains nothing.</returns>
        public bool IsEmpty()
        {
            if (occupant == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Attempt to insert a DOCO into the cell.
        /// </summary>
        /// <param name="doco">The DOCO to insert.</param>
        /// <returns>True on success, false otherwise.</returns>
        public bool InsertDOCO(DOCOs.Base doco)
        {
            if (occupant == null)
            {
                return false;
            }
            occupant = doco;
            return true;
        }
        #endregion
    }
}
