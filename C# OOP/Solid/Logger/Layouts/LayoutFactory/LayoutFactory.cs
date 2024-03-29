﻿using Logger.Layouts.Contracts;
using Logger.Layouts.LayoutFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts.LayoutFactory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
