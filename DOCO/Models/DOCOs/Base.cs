using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DOCO.Models.DOCOs
{
    /// <summary>
    /// Contains common values for DOCOs.
    /// </summary>
    [XmlRoot()]
    internal abstract class Base
    {
        #region Public Fields
        /// <summary>
        /// The GUID of the DOCO.
        /// </summary>
        public uint id;
        /// <summary>
        /// The current hunger of the DOCO. If it reaches 0, the DOCO will begin taking damage.
        /// </summary>
        public uint hunger;
        /// <summary>
        /// The maximum hunger of the DOCO. This is its stomach capacity.
        /// </summary>
        public uint maxHunger;
        /// <summary>
        /// The current health of the DOCO. If it reaches 0, the DOCO dies.
        /// </summary>
        public uint health;
        /// <summary>
        /// The maximum possible health of the DOCO.
        /// </summary>
        public uint maxHealth;
        /// <summary>
        /// The color for the DOCO.
        /// </summary>
        public System.Drawing.Color color;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a DOCO.
        /// </summary>
        /// <param name="id">The ID of the DOCO.</param>
        /// <param name="hunger">The starting hunger value of the DOCO. If greater than max, set to max.</param>
        /// <param name="maxHunger">The maximum possible hunger value of the DOCO.</param>
        /// <param name="health">The starting health value of the DOCO. If greater than max, set to max.</param>
        /// <param name="maxHealth">The maximum possible health value of the DOCO.</param>
        public Base(uint id, uint hunger = 100, uint maxHunger = 100, uint health = 10, uint maxHealth = 10)
        {
            if (hunger > maxHunger)
            {
                hunger = maxHunger;
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            this.id = id;
            this.hunger = hunger;
            this.maxHunger = maxHunger;
            this.health = health;
            this.maxHealth = maxHealth;
        }

        /// <summary>
        /// Parameterless constructor required for serialization.
        /// </summary>
        public Base()
        {
            hunger = 0;
            maxHunger = 0;
            health = 0;
            maxHealth = 0;
            id = 0;
        }
        #endregion

        #region Public Functions
        public virtual 
        #endregion
    }
}
