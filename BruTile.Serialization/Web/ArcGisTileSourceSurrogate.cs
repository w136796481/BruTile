// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.
using System.Reflection;
using System.Runtime.Serialization;

namespace BruTile.Web
{
    internal class ArcGisTileSourceSurrogate : ISerializationSurrogate
    {
        #region Implementation of ISerializationSurrogate

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var agts = (ArcGisTileSource) obj;
            
            // Provider
            var type = agts.Provider.GetType();
            info.AddValue("providerType", type);
            info.AddValue("provider", agts.Provider, type);

            //Schema
            type = agts.Schema.GetType();
            info.AddValue("schemaType", type);
            info.AddValue("schema", agts.Schema, type);

            //BaseUrl
            info.AddValue("baseUrl", agts.BaseUrl);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var agts = (ArcGisTileSource)obj;

            // Provider
            var type = (System.Type)info.GetValue("providerType", typeof(System.Type));
            Utility.SetPropertyValue(ref obj, "Provider", BindingFlags.NonPublic | BindingFlags.Instance, (ITileProvider)info.GetValue("provider", type));

            //Schema
            type = (System.Type) info.GetValue("schemaType", typeof (System.Type));
            Utility.SetPropertyValue(ref obj, "Schema", BindingFlags.NonPublic | BindingFlags.Instance, (ITileSchema)info.GetValue("schema", type));

            //BaseUrl
            Utility.SetPropertyValue(ref obj, "BaseUrl", BindingFlags.NonPublic | BindingFlags.Instance, info.GetString("baseUrl"));
            info.AddValue("baseUrl", agts.BaseUrl);

            return agts;
        }

        #endregion
    }
}