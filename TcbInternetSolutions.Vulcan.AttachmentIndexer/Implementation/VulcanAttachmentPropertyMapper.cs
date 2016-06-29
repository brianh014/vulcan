﻿using EPiServer.Core;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using TcbInternetSolutions.Vulcan.Core;
using TcbInternetSolutions.Vulcan.Core.Extensions;
using static TcbInternetSolutions.Vulcan.Core.VulcanFieldConstants;

namespace TcbInternetSolutions.Vulcan.AttachmentIndexer.Implementation
{    
    public class VulcanAttachmentPropertyMapper
    {
        private static ILogger _Logger = LogManager.GetLogger(typeof(VulcanAttachmentPropertyMapper));

        internal static List<string> AddedMappings = new List<string>();

        public static void AddMapping(IContent mediaType) => AddMapping(mediaType.GetTypeName());

        public static void AddMapping(Type mediaType) => AddMapping(mediaType.FullName);

        public static void AddMapping(string typeName)
        {
            if (AddedMappings?.Contains(typeName) == true) return;

            try
            {   
                IVulcanClient client = ServiceLocator.Current.GetInstance<IVulcanHandler>().GetClient();
                var response = client.Map<object>(m => m.
                    Index("_all").
                    Type(typeName).
                        Properties(props => props.
                            Attachment(s => s.Name(MediaContents)))
                    );

                if (!response.IsValid)
                {
                    throw new Exception(response.DebugInformation);
                }

                AddedMappings.Add(typeName);
            }
            catch (Exception ex)
            {
                _Logger.Error("Failed to map attachment field for type: " + typeName, ex);
            }
        }
    }
}
