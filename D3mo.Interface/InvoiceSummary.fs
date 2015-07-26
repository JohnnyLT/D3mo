namespace D3mo.Interface

module Invoice =

    let private convertToPostalCode (stateStr : string) = 
        match stateStr.ToLower() with
            | "alabama" | "ala." | "al"           -> "AL"
            | "alaska" | "ak"                     -> "AK"
            | "american samoa" | "as"             -> "AS"
            | "arizona" | "ariz." | "az"          -> "AZ"
            | "arkansas" | "ark." | "ar"          -> "AR"
            | "california" | "calif." | "ca"      -> "CA"
            | "colorado" | "colo." | "co"         -> "CO"
            | "connecticut" | "conn." | "ct"      -> "CT"
            | "delaware" | "del." | "de"          -> "DE"
            | "dist. of columbia" | "d.c." | "dc" -> "DC"
            | "florida" | "fla." | "fl"           -> "FL"
            | "georgia" | "ga." | "ga"            -> "GA"
            | "guam" | "gu"                       -> "GU"
            | "hawaii" | "hawaii" | "hi"          -> "HI"
            | "idaho" | "id"                      -> "ID"
            | "illinois" | "ill." | "il"          -> "IL"
            | "indiana" | "ind." | "in"           -> "IN"
            | "iowa" | "iowa" | "ia"              -> "IA"
            | "kansas" | "kans." | "ks"           -> "KS"
            | "kentucky" | "ky." | "ky"           -> "KY"
            | "louisiana" | "la." | "la"          -> "LA"
            | "maine" | "maine" | "me"            -> "ME"
            | "maryland" | "md." | "md"           -> "MD"
            | "marshall islands" | "mh"           -> "MH"
            | "massachusetts" | "mass." | "ma"    -> "MA"
            | "michigan" | "mich." | "mi"         -> "MI"
            | "micronesia" | "fm"                 -> "FM"
            | "minnesota" | "minn." | "mn"        -> "MN"
            | "mississippi" | "miss." | "ms"      -> "MS"
            | "missouri" | "mo." | "mo"           -> "MO"
            | "montana" | "mont." | "mt"          -> "MT"
            | "nebraska" | "nebr." | "ne"         -> "NE"
            | "nevada" | "nev." | "nv"            -> "NV"
            | "new hampshire" | "n.m." | "nh"     -> "NH"
            | "new jersey" | "n.j." | "nj"        -> "NJ"
            | "new mexico" | "n.m." | "nm"        -> "NM"
            | "new york" | "n.y." | "ny"          -> "NY"
            | "north carolina" | "n.c." | "nc"    -> "NC"
            | "north dakota" | "n.d." | "nd"      -> "ND"
            | "northern marianas" | "mp"          -> "MP"
            | "ohio" | "oh"                       -> "OH"
            | "oklahoma" | "okla." | "ok"         -> "OK"
            | "oregon" | "ore." | "or"            -> "OR"
            | "palau" | "pw"                      -> "PW"
            | "pennsylvania" | "pa." | "pa"       -> "PA"
            | "puerto rico" | "p.r." | "pr"       -> "PR"
            | "rhode island" | "r.i." | "ri"      -> "RI"
            | "south carolina" | "s.c." | "sc"    -> "SC"
            | "south dakota" | "s.d." | "sd"      -> "SD"
            | "tennessee" | "tenn." | "tn"        -> "TN"
            | "texas" | "tex." | "tx"             -> "TX"
            | "utah" | "ut"                       -> "UT"
            | "vermont" | "vt." | "vt"            -> "VT"
            | "virginia" | "va." | "va"           -> "VA"
            | "virgin islands" | "v.i." | "vi"    -> "VI"
            | "washington" | "wash." | "wa"       -> "WA"
            | "west virginia" | "w.va." | "wv"    -> "WV"
            | "wisconsin" | "wis." | "wi"         -> "WI"
            | "wyoming" | "wyo." | "wy"           -> "WY" 
            | _                                   -> ""

    let isUsState (code : string) =
        match code.ToUpper() with
        | "AL" | "AK" | "AS" | "AZ" | "AR" | "CA" | "CO" | "CT" | "DE" | "DC"
        | "FL" | "GA" | "GU" | "HI" | "ID" | "IL" | "IN" | "IA" | "KS" | "KY"
        | "LA" | "ME" | "MD" | "MH" | "MA" | "MI" | "FM" | "MN" | "MS" | "MO"
        | "MT" | "NE" | "NV" | "NH" | "NJ" | "NM" | "NY" | "NC" | "ND" | "MP"
        | "OH" | "OK" | "OR" | "PW" | "PA" | "PR" | "RI" | "SC" | "SD" | "TN"
        | "TX" | "UT" | "VT" | "VA" | "VI" | "WA" | "WV" | "WI"
        | "WY" -> true
        | _    -> false

    let isUsa (code : string) =
        match code.ToLower() with
        | "united states" | "us" | "usa" -> true
        | _                              -> false

    type Location(city : string, region : string, country : string, latitude : double, longitude : double) =
        let regionCode = convertToPostalCode region
        let countryCode = if isUsa country || isUsState regionCode then "US" else ""

        member __.City = city
        member __.Region = regionCode
        member __.Country = countryCode
        member __.Latitude = latitude
        member __.Longitude = longitude

    type Invoice(total : decimal, lastTwelve : decimal) =
        member __.Total = total
        member __.LastTwelve = lastTwelve

    type Summary(id : System.Guid, name : string, location : Location, invoice : Invoice) =
        member __.Id = id
        member __.Name = name
        member __.Location = location
        member __.Invoice = invoice

