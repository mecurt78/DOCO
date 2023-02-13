using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DOCO.Models
{
    /// <summary>
    /// Contains the logic for running a simulation.
    /// </summary>
    [XmlRoot()]
    internal class Simulation
    {
        /// <summary>
        /// Status of a simulation tick.
        /// </summary>
        public enum TickReturnCode
        {
            /// <summary>
            /// The simulation tick finished without error.
            /// </summary>
            Success,
            /// <summary>
            /// The simulation is finished. All DOCOs have died.
            /// </summary>
            SimulationFinished,
            /// <summary>
            /// The DOCOs are not initialized.
            /// </summary>
            UninitializedDOCOs,
            /// <summary>
            /// The world is not initialized.
            /// </summary>
            UninitializedWorld,
            /// <summary>
            /// Encountered an exception.
            /// </summary>
            Exception
        }

        #region Public Fields
        /// <summary>
        /// The amount of time between simulation ticks.
        /// </summary>
        public int tickTime;
        /// <summary>
        /// The current tick number of the simulation.
        /// </summary>
        public int tick;
        /// <summary>
        /// The world of the simulation.
        /// </summary>
        public List<List<Cell>>? world;
        /// <summary>
        /// The current list of DOCOs.
        /// </summary>
        public List<DOCOs.Base>? docos;
        #endregion

        #region Constructors
        public Simulation(int tickTime, int worldWidth, int worldHeight)
        {
            world = new List<List<Cell>>(worldWidth);
            for (int i = 0; i < worldWidth; i++)
            {
                world[i] = new List<Cell>(worldHeight);
                for (int j = 0; j < worldHeight; j++)
                {
                    world[i][j] = new Cell(i, j);
                }
            }
            tick = 0;
            this.tickTime = tickTime;
        }

        /// <summary>
        /// Parameterless constructor required for serialization. Do NOT use for actual simulation setup.
        /// </summary>
        public Simulation()
        {

        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Attempt to place a DOCO into the simulation.
        /// </summary>
        /// <param name="x">The X coordinate of the world to place the DOCO in.</param>
        /// <param name="y">The Y coordinate of the world to place the DOCO in.</param>
        /// <param name="doco">The DOCO to place into the world.</param>
        /// <returns>True if placed successfully. False otherwise.</returns>
        public bool PlaceDOCO(uint x, uint y, DOCOs.Base doco)
        {
            if (world != null)
            {
                // The world is initialized.
                if (x < world.Count && y < world[0].Count)
                {
                    // The given coordinate is valid.
                    if (world[(int)x][(int)y].IsEmpty())
                    {
                        // The given cell is empty and capable of holding a DOCO.
                        world[(int)x][(int)y].InsertDOCO(doco);
                        return true;
                    }
                    else
                    {
                        Trace.WriteLine("Attempted to place a DOCO, but cell [" + x + ", " + y + "] is not empty.");
                    }
                }
                else
                {
                    Trace.WriteLine("Attempted to place a DOCO, but given coordinate [" + x + ", " + y + "] is not valid.");
                }
            }
            else
            {
                Trace.WriteLine("Attempted to place a DOCO, but world is not initialized.");
            }
            return false;
        }

        /// <summary>
        /// Increment the simulation by one tick.
        /// </summary>
        /// <returns>A return code marking the status of the tick. See DOCO.Models.Simulation.TickReturnCode for more information.</returns>
        public TickReturnCode Tick()
        {
            // Save the indentation level in case an exception is caught.
            int initialIndent = Trace.IndentLevel;
            if (docos == null)
            {
                return TickReturnCode.UninitializedDOCOs;
            }
            if (world == null)
            {
                return TickReturnCode.UninitializedWorld;
            }
            Trace.WriteLine("Running tick #" + ++tick);
            Trace.Indent();
            try
            {
                foreach (DOCOs.Base doco in docos)
                {
                    Trace.WriteLine("Ticking DOCO #" + docos.IndexOf(doco));
                    Trace.Indent();
                    Trace.Unindent();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                // Reset the indentation level before exiting.
                Trace.IndentLevel = initialIndent;
                return TickReturnCode.Exception;
            }
            Trace.Unindent();
            return TickReturnCode.Success;
        }
        #endregion
    }
}
