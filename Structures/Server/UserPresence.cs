using Komorebi.Objects;
using Komorebi.Packets;
using System;

namespace Komorebi.Structures.Server
{
    public class UserPresence : ISerializable
    {
        Player p;

        public UserPresence(Player _p) => p = _p;

        public void WriteToStream(PacketWriter w)
        {
            w.Write(p.UserId);
            w.Write(p.Username);
            w.Write((byte)(0 + 24));
            w.Write(getCountryId(p.Country));
            w.Write((byte)(((byte)p.Privileges & 0x1f) | (((byte)p.Mode & 0x7) << 5)));
            w.Write(0.0f);
            w.Write(0.0f);
            w.Write(p.GameRank);
        }

        public void ReadFromStream(PacketReader r)
        {
            throw new NotImplementedException();
        }

        private static byte getCountryId(string Country)
        {
            if (Country.Length != 2)
            {
                return 0;
            }

            byte CountryCode = 0;

            switch (Country.ToUpper())
            {
                case "OC":
                    CountryCode = 1;
                    break;
                case "EU":
                    CountryCode = 2;
                    break;
                case "AD": //Andorra
                    CountryCode = 3;
                    break;
                case "AE": //UAE
                    CountryCode = 4;
                    break;
                case "AF": //Afghanistan
                    CountryCode = 5;
                    break;
                case "AG": //Antigua
                    CountryCode = 6;
                    break;
                case "AI": //Anguilla
                    CountryCode = 7;
                    break;
                case "AL": //Albania
                    CountryCode = 8;
                    break;
                case "AM": //Armenia
                    CountryCode = 9;
                    break;
                case "AN": //Netherlands Antilles
                    CountryCode = 10;
                    break;
                case "AO": //Angola
                    CountryCode = 11;
                    break;
                case "AQ": //Antarctica
                    CountryCode = 12;
                    break;
                case "AR": //Argentina
                    CountryCode = 13;
                    break;
                case "AS": //American Samoa
                    CountryCode = 14;
                    break;
                case "AT": //Austria
                    CountryCode = 15;
                    break;
                case "AU": //Australia
                    CountryCode = 16;
                    break;
                case "AW": //Aruba
                    CountryCode = 17;
                    break;
                case "AZ": //Azerbaijan
                    CountryCode = 18;
                    break;
                case "BA": //Bosnia
                    CountryCode = 19;
                    break;
                case "BB": //Barbados
                    CountryCode = 20;
                    break;
                case "BD": //Bangladesh
                    CountryCode = 21;
                    break;
                case "BE": //Belgium
                    CountryCode = 22;
                    break;
                case "BF": //Burkina Faso
                    CountryCode = 23;
                    break;
                case "BG": //Bulgaria
                    CountryCode = 24;
                    break;
                case "BH": //Bahrain
                    CountryCode = 25;
                    break;
                case "BI": //Burundi
                    CountryCode = 26;
                    break;
                case "BJ": //Benin
                    CountryCode = 27;
                    break;
                case "BM": //Bermuda
                    CountryCode = 28;
                    break;
                case "BN": //Brunei Darussalam
                    CountryCode = 29;
                    break;
                case "BO": //Bolivia
                    CountryCode = 30;
                    break;
                case "BR": //Brazil
                    CountryCode = 31;
                    break;
                case "BS": //Bahamas
                    CountryCode = 32;
                    break;
                case "BT": //Bhutan
                    CountryCode = 33;
                    break;
                case "BV": //Bouvet Island
                    CountryCode = 34;
                    break;
                case "BW": //Botswana
                    CountryCode = 35;
                    break;
                case "BY": //Belarus
                    CountryCode = 36;
                    break;
                case "BZ": //Belize
                    CountryCode = 37;
                    break;
                case "CA": //Canada
                    CountryCode = 38;
                    break;
                case "CC": //Cocos Islands
                    CountryCode = 39;
                    break;
                case "CD": //Congo
                    CountryCode = 40;
                    break;
                case "CF": //Central African Republic
                    CountryCode = 41;
                    break;
                case "CG": //Congo
                    CountryCode = 42;
                    break;
                case "CH": //Switzerland
                    CountryCode = 43;
                    break;
                case "CI": //Cote D'Ivoire
                    CountryCode = 44;
                    break;
                case "CK": //Cook Islands
                    CountryCode = 45;
                    break;
                case "CL": //Chile
                    CountryCode = 46;
                    break;
                case "CM": //Cameroon
                    CountryCode = 47;
                    break;
                case "CN": //China
                    CountryCode = 48;
                    break;
                case "CO": //Colombia
                    CountryCode = 49;
                    break;
                case "CR": //Costa Rica
                    CountryCode = 50;
                    break;
                case "CU": //Cuba
                    CountryCode = 51;
                    break;
                case "CV": //Cape Verde
                    CountryCode = 52;
                    break;
                case "CX": //Christmas Island
                    CountryCode = 53;
                    break;
                case "CY": //Cyprus
                    CountryCode = 54;
                    break;
                case "CZ": //Czech Republic
                    CountryCode = 55;
                    break;
                case "DE": //Germany
                    CountryCode = 56;
                    break;
                case "DJ": //Djibouti
                    CountryCode = 57;
                    break;
                case "DK": //Denmark
                    CountryCode = 58;
                    break;
                case "DM": //Dominica
                    CountryCode = 59;
                    break;
                case "DO": //Dominican Republic
                    CountryCode = 60;
                    break;
                case "DZ": //Algeria
                    CountryCode = 61;
                    break;
                case "EC": //Ecuador
                    CountryCode = 62;
                    break;
                case "EE": //Estonia
                    CountryCode = 63;
                    break;
                case "EG": //Egypt
                    CountryCode = 64;
                    break;
                case "EH": //Western Sahara
                    CountryCode = 65;
                    break;
                case "ER": //Eritrea
                    CountryCode = 66;
                    break;
                case "ES": //Spain
                    CountryCode = 67;
                    break;
                case "ET": //Ethiopia
                    CountryCode = 68;
                    break;
                case "FI": //Finland
                    CountryCode = 69;
                    break;
                case "FJ": //Fiji
                    CountryCode = 70;
                    break;
                case "FK": //Falkland Islands
                    CountryCode = 71;
                    break;
                case "FM": //Micronesia, Federated States of
                    CountryCode = 72;
                    break;
                case "FO": //Faroe Islands
                    CountryCode = 73;
                    break;
                case "FR": //France
                    CountryCode = 74;
                    break;
                case "FX": //France, Metropolitan
                    CountryCode = 75;
                    break;
                case "GA": //Gabon
                    CountryCode = 76;
                    break;
                case "GB": //United Kingdom
                    CountryCode = 77;
                    break;
                case "GD": //Grenada
                    CountryCode = 78;
                    break;
                case "GE": //Georgia
                    CountryCode = 79;
                    break;
                case "GF": //French Guiana
                    CountryCode = 80;
                    break;
                case "GH": //Ghana
                    CountryCode = 81;
                    break;
                case "GI": //Gibraltar
                    CountryCode = 82;
                    break;
                case "GL": //Greenland
                    CountryCode = 83;
                    break;
                case "GM": //Gambia
                    CountryCode = 84;
                    break;
                case "GN": //Guinea
                    CountryCode = 85;
                    break;
                case "GP": //Guadeloupe
                    CountryCode = 86;
                    break;
                case "GQ": //Equatorial Guinea
                    CountryCode = 87;
                    break;
                case "GR": //Greece
                    CountryCode = 88;
                    break;
                case "GS": //South Georgia
                    CountryCode = 89;
                    break;
                case "GT": //Guatemala
                    CountryCode = 90;
                    break;
                case "GU": //Guam
                    CountryCode = 91;
                    break;
                case "GW": //Guinea-Bissau
                    CountryCode = 92;
                    break;
                case "GY": //Guyana
                    CountryCode = 93;
                    break;
                case "HK": //Hong Kong
                    CountryCode = 94;
                    break;
                case "HM": //Heard Island
                    CountryCode = 95;
                    break;
                case "HN": //Honduras
                    CountryCode = 96;
                    break;
                case "HR": //Croatia
                    CountryCode = 97;
                    break;
                case "HT": //Haiti
                    CountryCode = 98;
                    break;
                case "HU": //Hungary
                    CountryCode = 99;
                    break;
                case "ID": //Indonesia
                    CountryCode = 100;
                    break;
                case "IE": //Ireland
                    CountryCode = 101;
                    break;
                case "IL": //Israel
                    CountryCode = 102;
                    break;
                case "IN": //India
                    CountryCode = 103;
                    break;
                case "IO": //British Indian Ocean Territory
                    CountryCode = 104;
                    break;
                case "IQ": //Iraq
                    CountryCode = 105;
                    break;
                case "IR": //Iran, Islamic Republic of
                    CountryCode = 106;
                    break;
                case "IS": //Iceland
                    CountryCode = 107;
                    break;
                case "IT": //Italy
                    CountryCode = 108;
                    break;
                case "JM": //Jamaica
                    CountryCode = 109;
                    break;
                case "JO": //Jordan
                    CountryCode = 110;
                    break;
                case "JP": //Japan
                    CountryCode = 111;
                    break;
                case "KE": //Kenya
                    CountryCode = 112;
                    break;
                case "KG": //Kyrgyzstan
                    CountryCode = 113;
                    break;
                case "KH": //Cambodia
                    CountryCode = 114;
                    break;
                case "KI": //Kiribati
                    CountryCode = 115;
                    break;
                case "KM": //Comoros
                    CountryCode = 116;
                    break;
                case "KN": //St. Kitts and Nevis
                    CountryCode = 117;
                    break;
                case "KP": //Korea, Democratic People's Republic of
                    CountryCode = 118;
                    break;
                case "KR": //Korea
                    CountryCode = 119;
                    break;
                case "KW": //Kuwait
                    CountryCode = 120;
                    break;
                case "KY": //Cayman Islands
                    CountryCode = 121;
                    break;
                case "KZ": //Kazakhstan
                    CountryCode = 122;
                    break;
                case "LA": //Lao
                    CountryCode = 123;
                    break;
                case "LB": //Lebanon
                    CountryCode = 124;
                    break;
                case "LC": //St. Lucia
                    CountryCode = 125;
                    break;
                case "LI": //Liechtenstein
                    CountryCode = 126;
                    break;
                case "LK": //Sri Lanka
                    CountryCode = 127;
                    break;
                case "LR": //Liberia
                    CountryCode = 128;
                    break;
                case "LS": //Lesotho
                    CountryCode = 129;
                    break;
                case "LT": //Lithuania
                    CountryCode = 130;
                    break;
                case "LU": //Luxembourg
                    CountryCode = 131;
                    break;
                case "LV": //Latvia
                    CountryCode = 132;
                    break;
                case "LY": //Libyan Arab Jamahiriya
                    CountryCode = 133;
                    break;
                case "MA": //Morocco
                    CountryCode = 134;
                    break;
                case "MC": //Monaco
                    CountryCode = 135;
                    break;
                case "MD": //Moldova, Republic of
                    CountryCode = 136;
                    break;
                case "MG": //Madagascar
                    CountryCode = 137;
                    break;
                case "MH": //Marshall Islands
                    CountryCode = 138;
                    break;
                case "MK": //Macedonia, the Former Yugoslav Republic of
                    CountryCode = 139;
                    break;
                case "ML": //Mali
                    CountryCode = 140;
                    break;
                case "MM": //Myanmar
                    CountryCode = 141;
                    break;
                case "MN": //Mongolia
                    CountryCode = 142;
                    break;
                case "MO": //Macau
                    CountryCode = 143;
                    break;
                case "MP": //Northern Mariana Islands
                    CountryCode = 144;
                    break;
                case "MQ": //Martinique
                    CountryCode = 145;
                    break;
                case "MR": //Mauritania
                    CountryCode = 146;
                    break;
                case "MS": //Montserrat
                    CountryCode = 147;
                    break;
                case "MT": //Malta
                    CountryCode = 148;
                    break;
                case "MU": //Mauritius
                    CountryCode = 149;
                    break;
                case "MV": //Maldives
                    CountryCode = 150;
                    break;
                case "MW": //Malawi
                    CountryCode = 151;
                    break;
                case "MX": //Mexico
                    CountryCode = 152;
                    break;
                case "MY": //Malaysia
                    CountryCode = 153;
                    break;
                case "MZ": //Mozambique
                    CountryCode = 154;
                    break;
                case "NA": //Namibia
                    CountryCode = 155;
                    break;
                case "NC": //New Caledonia
                    CountryCode = 156;
                    break;
                case "NE": //Niger
                    CountryCode = 157;
                    break;
                case "NF": //Norfolk Island
                    CountryCode = 158;
                    break;
                case "NG": //Nigeria
                    CountryCode = 159;
                    break;
                case "NI": //Nicaragua
                    CountryCode = 160;
                    break;
                case "NL": //Netherlands
                    CountryCode = 161;
                    break;
                case "NO": //Norway
                    CountryCode = 162;
                    break;
                case "NP": //Nepal
                    CountryCode = 163;
                    break;
                case "NR": //Nauru
                    CountryCode = 164;
                    break;
                case "NU": //Niue
                    CountryCode = 165;
                    break;
                case "NZ": //New Zealand
                    CountryCode = 166;
                    break;
                case "OM": //Oman
                    CountryCode = 167;
                    break;
                case "PA": //Panama
                    CountryCode = 168;
                    break;
                case "PE": //Peru
                    CountryCode = 169;
                    break;
                case "PF": //French Polynesia
                    CountryCode = 170;
                    break;
                case "PG": //Papua New Guinea
                    CountryCode = 171;
                    break;
                case "PH": //Philippines
                    CountryCode = 172;
                    break;
                case "PK": //Pakistan
                    CountryCode = 173;
                    break;
                case "PL": //Poland
                    CountryCode = 174;
                    break;
                case "PM": //St. Pierre
                    CountryCode = 175;
                    break;
                case "PN": //Pitcairn
                    CountryCode = 176;
                    break;
                case "PR": //Puerto Rico
                    CountryCode = 177;
                    break;
                case "PS": //Palestinian Territory
                    CountryCode = 178;
                    break;
                case "PT": //Portugal
                    CountryCode = 179;
                    break;
                case "PW": //Palau
                    CountryCode = 180;
                    break;
                case "PY": //Paraguay
                    CountryCode = 181;
                    break;
                case "QA": //Qatar
                    CountryCode = 182;
                    break;
                case "RE": //Reunion
                    CountryCode = 183;
                    break;
                case "RO": //Romania
                    CountryCode = 184;
                    break;
                case "RU": //Russian Federation
                    CountryCode = 185;
                    break;
                case "RW": //Rwanda
                    CountryCode = 186;
                    break;
                case "SA": //Saudi Arabia
                    CountryCode = 187;
                    break;
                case "SB": //Solomon Islands
                    CountryCode = 188;
                    break;
                case "SC": //Seychelles
                    CountryCode = 189;
                    break;
                case "SS": //Sudan
                    CountryCode = 190;
                    break;
                case "SE": //Sweden
                    CountryCode = 191;
                    break;
                case "SG": //Singapore
                    CountryCode = 192;
                    break;
                case "SH": //St. Helena
                    CountryCode = 193;
                    break;
                case "SI": //Slovenia
                    CountryCode = 194;
                    break;
                case "SJ": //Svalbard and Jan Mayen
                    CountryCode = 195;
                    break;
                case "SK": //Slovakia
                    CountryCode = 196;
                    break;
                case "SL": //Sierra Leone
                    CountryCode = 197;
                    break;
                case "SM": //San Marino
                    CountryCode = 198;
                    break;
                case "SN": //Senegal
                    CountryCode = 199;
                    break;
                case "SO": //Somalia
                    CountryCode = 200;
                    break;
                case "SR": //Suriname
                    CountryCode = 201;
                    break;
                case "ST": //Sao Tome and Principe
                    CountryCode = 202;
                    break;
                case "SV": //El Salvador
                    CountryCode = 203;
                    break;
                case "SY": //Syrian Arab Republic
                    CountryCode = 204;
                    break;
                case "SZ": //Swaziland
                    CountryCode = 205;
                    break;
                case "TC": //Turks and Caicos Islands
                    CountryCode = 206;
                    break;
                case "TD": //Chad
                    CountryCode = 207;
                    break;
                case "TF": //French Southern Territories
                    CountryCode = 208;
                    break;
                case "TG": //Togo
                    CountryCode = 209;
                    break;
                case "TH": //Thailand
                    CountryCode = 210;
                    break;
                case "TJ": //Tajikistan
                    CountryCode = 211;
                    break;
                case "TK": //Tokelau
                    CountryCode = 212;
                    break;
                case "TM": //Turkmenistan
                    CountryCode = 213;
                    break;
                case "TN": //Tunisia
                    CountryCode = 214;
                    break;
                case "TO": //Tonga
                    CountryCode = 215;
                    break;
                case "TL": //Timor-Leste
                    CountryCode = 216;
                    break;
                case "TR": //Turkey
                    CountryCode = 217;
                    break;
                case "TT": //Trinidad and Tobago
                    CountryCode = 218;
                    break;
                case "TV": //Tuvalu
                    CountryCode = 219;
                    break;
                case "TW": //Taiwan
                    CountryCode = 220;
                    break;
                case "TZ": //Tanzania
                    CountryCode = 221;
                    break;
                case "UA": //Ukraine
                    CountryCode = 222;
                    break;
                case "UG": //Uganda
                    CountryCode = 223;
                    break;
                case "UI": //US (Island)
                    CountryCode = 224;
                    break;
                case "UM": //United States
                    CountryCode = 225;
                    break;
                case "UY": //Uruguay
                    CountryCode = 226;
                    break;
                case "UZ": //Uzbekistan
                    CountryCode = 227;
                    break;
                case "VA": //Holy See
                    CountryCode = 228;
                    break;
                case "VC": //St. Vincent
                    CountryCode = 229;
                    break;
                case "VE": //Venezuela
                    CountryCode = 230;
                    break;
                case "VG": //Virgin Islands, British
                    CountryCode = 231;
                    break;
                case "VI": //Virgin Islands, U.S.
                    CountryCode = 232;
                    break;
                case "VN": //Vietnam
                    CountryCode = 233;
                    break;
                case "VU": //Vanuatu
                    CountryCode = 234;
                    break;
                case "WF": //Wallis and Futuna
                    CountryCode = 235;
                    break;
                case "WS": //Samoa
                    CountryCode = 236;
                    break;
                case "YE": //Yemen
                    CountryCode = 237;
                    break;
                case "YT": //Mayotte
                    CountryCode = 238;
                    break;
                case "RS": //Serbia
                    CountryCode = 239;
                    break;
                case "ZA": //South Africa
                    CountryCode = 240;
                    break;
                case "ZM": //Zambia
                    CountryCode = 241;
                    break;
                case "ME": //Montenegro
                    CountryCode = 242;
                    break;
                case "ZW": //Zimbabwe
                    CountryCode = 243;
                    break;
                case "XX": //Unknown
                    CountryCode = 244;
                    break;
                case "A2": //Satellite Provider
                    CountryCode = 245;
                    break;
                case "O1": //Other
                    CountryCode = 246;
                    break;
                case "AX": //Aland Islands
                    CountryCode = 247;
                    break;
                case "GG": //Guernsey
                    CountryCode = 248;
                    break;
                case "IM": //Isle of Man
                    CountryCode = 249;
                    break;
                case "JE": //Jersey
                    CountryCode = 250;
                    break;
                case "BL": //St. Barthelemy
                    CountryCode = 251;
                    break;
                case "MF": //Saint Martin
                    CountryCode = 252;
                    break;
            }

            return CountryCode;
        }
    }
}
