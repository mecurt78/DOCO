using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DOCO.ViewModels
{
    /// <summary>
    /// Contains the interaction logic for the main window.
    /// </summary>
    internal class MainWindow : DependencyObject
    {
        #region Dependency Properties
        /// <summary>
        /// The current status of the simulation.
        /// </summary>
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        private static DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(MainWindow), new PropertyMetadata("Loading..."));

        /// <summary>
        /// The width of the simulation world.
        /// </summary>
        public uint WorldWidth
        {
            get { return (uint)GetValue(WorldWidthProperty); }
            set { SetValue(WorldWidthProperty, value); }
        }
        private static DependencyProperty WorldWidthProperty = DependencyProperty.Register("WorldWidth", typeof(uint), typeof(MainWindow), new PropertyMetadata(20));

        /// <summary>
        /// The height of the simulation world.
        /// </summary>
        public uint WorldHeight
        {
            get { return (uint)GetValue(WorldHeightProperty); }
            set { SetValue(WorldHeightProperty, value); }
        }
        private static DependencyProperty WorldHeightProperty = DependencyProperty.Register("WorldHeight", typeof(uint), typeof(MainWindow), new PropertyMetadata(20));
        #endregion
    }
}
