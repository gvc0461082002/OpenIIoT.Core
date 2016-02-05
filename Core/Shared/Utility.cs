﻿using NLog;
using Symbiote.Core.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    class Utility
    {
        internal static void PrintConnectorPluginItemChildren(Logger logger, IConnector connector)
        {
            logger.Info(connector.Browse().FQN);
            PrintConnectorPluginItemChildren(logger, connector, connector.Browse(), 1);
        }

        internal static void PrintConnectorPluginItemChildren(Logger logger, IConnector connector, Item root, int indent)
        {
            foreach (Item i in connector.Browse(root))
            {
                if (i.HasChildren() == false)
                    logger.Info(new string('\t', indent) + i.FQN + " Value: " + connector.Read(i.FQN).ToString());
                else
                    logger.Info(new string('\t', indent) + i.FQN);
                PrintConnectorPluginItemChildren(logger, connector, i, indent + 1);
            }
        }

        internal static void PrintItemChildren(Logger logger, Item root, int indent)
        {
            logger.Info(new string('\t', indent) + root.FQN + " [" + root.SourceAddress + "] children: " + root.Children.Count());

            foreach (Item i in root.Children)
            {
                PrintItemChildren(logger, i, indent + 1);
            }
        }
    }
}
