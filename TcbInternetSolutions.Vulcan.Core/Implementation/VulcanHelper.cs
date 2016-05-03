﻿using EPiServer.Core;
using EPiServer.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcbInternetSolutions.Vulcan.Core.Implementation
{
    public static class VulcanHelper
    {
        public static Type [] IgnoredTypes
        {
            get
            {
                return new Type[] {
                    typeof(PropertyDataCollection),
                    typeof(ContentArea),
                    typeof(CultureInfo),
                    typeof(IEnumerable<CultureInfo>),
                    typeof(PageType)
                };
            }
        }

        public static string GetAnalyzer(CultureInfo cultureInfo)
        {
            if (cultureInfo != CultureInfo.InvariantCulture) // check if we have non-language data
            {
                if (!cultureInfo.IsNeutralCulture)
                {
                    // try something specific first

                    switch (cultureInfo.Name.ToUpper())
                    {
                        case "PT-BR":
                            return "brazilian";
                    }
                }

                // nothing specific matched, go with generic

                switch (cultureInfo.TwoLetterISOLanguageName.ToUpper())
                {
                    case "AR":
                        return "arabic";                            
                    case "HY":
                        return "armenian";                            
                    case "EU":
                        return "basque";                            
                    case "BG":
                        return "bulgarian";                            
                    case "CA":
                        return "catalan";                            
                    case "ZH":
                        return "chinese";                            
                    case "KO":
                        return "cjk"; // generic chinese-japanese-korean                            
                    case "JP":
                        return "cjk"; // generic chinese-japanese-korean                            
                    case "CS":
                        return "czech";                            
                    case "DA":
                        return "danish";                            
                    case "NL":
                        return "dutch";                            
                    case "EN":
                        return "english";                            
                    case "FI":
                        return "finnish";                            
                    case "FR":
                        return "french";                            
                    case "GL":
                        return "galician";                            
                    case "DE":
                        return "german";                            
                    case "GR":
                        return "greek";                            
                    case "HI":
                        return "hindi";                            
                    case "HU":
                        return "hungarian";                            
                    case "ID":
                        return "indonesian";                            
                    case "GA":
                        return "irish";                            
                    case "IT":
                        return "italian";                            
                    case "LV":
                        return "latvian";                            
                    case "NO":
                        return "norwegian";                            
                    case "FA":
                        return "persian";                            
                    case "PT":
                        return "portuguese";                            
                    case "RO":
                        return "romanian";                            
                    case "RU":
                        return "russian";                            
                    case "KU":
                        return "sorani"; // Kurdish                            
                    case "ES":
                        return "spanish";                            
                    case "SV":
                        return "swedish";
                    case "TR":
                        return "turkish";
                    case "TH":
                        return "thai";
                }
            }

            // couldn't find a match (or invariant culture)
            return "standard";
        }
    }
}
