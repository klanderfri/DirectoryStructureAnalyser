﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryStructureAnalyser
{
    /// <summary>
    /// Class for form showing a waiting dialog.
    /// </summary>
    /// <remarks>
    /// Implemented as suggested at
    /// https://www.youtube.com/watch?v=yZYAaScEsc0
    /// </remarks>
    public partial class WaitForm : Form
    {
        /// <summary>
        /// The action performed while the wait form is running.
        /// </summary>
        public Action Worker { get; private set; }

        /// <summary>
        /// Creates a form showing a waiting dialog.
        /// </summary>
        /// <param name="worker">The action to perform while the waiting form is showing.</param>
        public WaitForm(Action worker)
        {
            InitializeComponent();
            Worker = worker ?? throw new ArgumentNullException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory
                .StartNew(Worker)
                .ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
