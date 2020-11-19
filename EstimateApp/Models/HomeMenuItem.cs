using System;
using System.Collections.Generic;
using System.Text;

namespace EstimateApp.Models
{
    public enum MenuItemType
    {
        Home,
        Browse,
        About,
        Eform,
        Eapp,
        CustomReport,
        ProfileProvider,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
