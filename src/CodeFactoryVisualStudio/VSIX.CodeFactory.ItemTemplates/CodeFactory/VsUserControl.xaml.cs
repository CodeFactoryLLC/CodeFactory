using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeFactory.Logging;
using CodeFactory.VisualStudio;
using CodeFactory.VisualStudio.UI;

namespace $rootnamespace$
{
     /// <summary>
    /// Interaction logic for $safeitemrootname$.xaml
    /// </summary>
    public partial class $safeitemrootname$ : VsUserControl
    {
        /// <summary>
        /// Creates an instance of the user control.
        /// </summary>
        /// <param name="vsActions">The visual studio actions that are accessible by this user control.</param>
        /// <param name="logger">The logger used by this user control.</param>
        public $safeitemrootname$(IVsActions vsActions, ILogger logger) : base(vsActions,logger)
        {
            //Initializes the controls on the screen and subscribes to all control events (Required for the screen to run properly)
            InitializeComponent();
        }


    }
}
