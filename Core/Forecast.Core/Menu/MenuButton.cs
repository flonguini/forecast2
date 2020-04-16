using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Core.Menu
{
    public class MenuButton
    {
        /// <summary>
        /// Button text
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Button command
        /// </summary>
        public DelegateCommand<string> Command { get; set; }

        /// <summary>
        /// The underline button highlight
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Command parameter
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuButton()
        {
            IsVisible = false;
        }
    }
}
