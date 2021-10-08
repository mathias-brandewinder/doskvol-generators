#r "nuget: Thoth.Json.Net"
open Thoth.Json.Net

type Distribution =
    | Flat of list<string>
    | Weighted of list<float * string>

type Source = {
    Name: string
    Items: Distribution
    }

[<CLIMutable>]
type Attributes = {
    Category: string
    Choices: list<string>
    }

module Blades =

    let looks = {
        Name = "look"
        Items = Flat [
            "large"
            "lovely"
            "weathered"
            "chiseled"
            "handsome"
            "slim"
            "dark"
            "fair"
            "stout"
            "delicate"
            "scarred"
            "bony"
            "worn"
            "rough"
            "plump"
            "wiry"
            "striking"
            "short"
            "tall"
            "sexy"
            "wild"
            "elegant"
            "stooped"
            "cute"
            "plain"
            "old"
            "young"
            "stylish"
            "strange"
            "disfigured"
            "maimed"
            "glasses"
            "monocle"
            "prosthetic"
            "crippled"
            "long hair"
            "beard"
            "wig"
            "shorn"
            "bald"
            "tattoed"
            ]
        }

    let goals = {
        Name = "goal"
        Items = Flat [
            "wealth"
            "power"
            "authority"
            "prestige"
            "fame"
            "control"
            "knowledge"
            "pleasure"
            "revenge"
            "freedom"
            "achievement"
            "happiness"
            "infamy"
            "fear"
            "respect"
            "love"
            "change"
            "chaos"
            "destruction"
            "justice"
            "cooperation"
            ]
        }

    let methods = {
        Name = "method"
        Items = Flat [
            "violence"
            "threats"
            "negotiation"
            "study"
            "manipulation"
            "strategy"
            "theft"
            "arcane"
            "commerce"
            "hardwork"
            "law"
            "politics"
            "sabotage"
            "subterfuge"
            "alchemy"
            "blackmail"
            "teamwork"
            "espionage"
            "chaos"
            ]
        }

    let styles = {
        Name = "style"
        Items = Flat [
            "tricorn hat"
            "long coat"
            "hood & veil"
            "short cloak"
            "knit cap"
            "slim jacket"
            "hooded coat"
            "tall boots"
            "work boots"
            "mask & robe"
            "suit & vest"
            "collared shirt"
            "suspenders"
            "rough tunic"
            "skirt & blouse"
            "wide belt"
            "fitted dress"
            "heavy cloak"
            "thick greatcoat"
            "soft boots"
            "loose silks"
            "sharp trousers"
            "waxed coat"
            "long scarf"
            "leathers"
            "eelskin bodysuit"
            "hide & furs"
            "uniform"
            "tatters"
            "fitted leggings"
            "apron"
            "heavy gloves"
            "face mask"
            "tool belt"
            "crutches"
            "cane"
            "wheelchair"
            ]
        }

    let traits = {
        Name = "trait"
        Items = Flat [
            "charming"
            "cold"
            "cavalier"
            "brash"
            "suspicious"
            "obsessive"
            "shrewd"
            "quiet"
            "moody"
            "fierce"
            "careless"
            "secretive"
            "ruthless"
            "calculating"
            "defiant"
            "gracious"
            "insightful"
            "dishonest"
            "patient"
            "vicious"
            "sophisticated"
            "paranoid"
            "enthusiastic"
            "elitist"
            "savage"
            "cooperative"
            "arrogant"
            "confident"
            "vain"
            "daring"
            "volatile"
            "candid"
            "subtle"
            "melancholy"
            "enigmatic"
            "calm"
            ]
        }

    let interests = {
        Name = "interest"
        Items = Flat [
            "fine whiskey"
            "fine wine"
            "fine beer"
            "fine food"
            "fine restaurants"
            "fine clothes"
            "fine jewelry"
            "fine furs"
            "fine arts"
            "opera"
            "theater"
            "painting"
            "drawing"
            "sculpture"
            "history"
            "legends"
            "architecture"
            "furnishings"
            "poetry"
            "novels"
            "writing"
            "pit fighting"
            "duels"
            "forgotten gods"
            "Church of Ecstasy"
            "Path of Echoes"
            "Weeping Lady"
            "charity"
            "antiques"
            "artifacts"
            "curios"
            "horses"
            "riding"
            "gadgets"
            "new technology"
            "weapons collector"
            "music"
            "music instruments"
            "dance"
            "hunting"
            "shooting"
            "cooking"
            "gardening"
            "gambling"
            "cards"
            "dice"
            "natural philosophy"
            "drugs"
            "essences"
            "tobacco"
            "lovers"
            "romance"
            "trysts"
            "parties"
            "social events"
            "exploration"
            "adventure"
            "pets"
            "crafts"
            "ships"
            "boating"
            "politics"
            "journalism"
            "arcane books"
            "arcane rituals"
            "spectrology"
            "electroplasm"
            "alchemy"
            "medicine"
            "demon lore"
            "pre cataclysm legends"
            ]
        }

    let quirks = {
        Name = "quirk"
        Items = Flat [
            "superstitious"
            "believes in signs"
            "believes in magic numbers"
            "devoted to family"
            "married into important family"
            "holds their position to spy for faction"
            "reclusive"
            "interacts via messengers"
            "massive debt"
            "blind to flaws in friends"
            "hollowed, then restored"
            "immune to ghosts"
            "chronic illness that requires care"
            "controlled by spirit"
            "serves demon's agenda"
            "proud of heritage"
            "concerned with appearances"
            "substance abuse, often impaired"
            "used blackmail to hold position"
            "relies on council to decide"
            "involved with war crimes from Unity War"
            "leads double life"
            "black sheep from family, faction"
            "in prison, house arrest"
            "well travelled and connected"
            "revolutionary, against Imperium"
            "inherited position"
            "celebrity"
            "scandalous reputation"
            "surrounded by sycophants"
            "spotless reputation, highly regarded"
            "bigoted"
            "visionary, radical views"
            "cursed, harassed by spirit or demon"
            "intense phobia"
            "extensive education"
            "keeps notes, ledgers"
            "blindly faithful to ideal"
            "deeply traditional, opposed to new ideas"
            "fraud, fabricated life"
            ]
        }

    let names = {
        Name = "name"
        Items = Flat [
            "Aldric"
            "Aldo"
            "Amosen"
            "Andrel"
            "Arden"
            "Arlyn"
            "Arquo"
            "Arvus"
            "Ashlyn"
            "Branon"
            "Brace"
            "Brance"
            "Brena"
            "Bricks"
            "Candra"
            "Carissa"
            "Carro"
            "Casslyn"
            "Cavelle"
            "Clave"
            "Corille"
            "Cross"
            "Crowl"
            "Cyrene"
            "Daphnia"
            "Drav"
            "Edlun"
            "Emeline"
            "Grine"
            "Helles"
            "Hix"
            "Holtz"
            "Kamelin"
            "Kelyr"
            "Kobb"
            "Kristov"
            "Laudius"
            "Lauria"
            "Lenia"
            "Lizete"
            "Lorette"
            "Lucella"
            "Lynthia"
            "Mara"
            "Milos"
            "Morlan"
            "Myre"
            "Narcus"
            "Naria"
            "Noggs"
            "Odrienne"
            "Orlan"
            "Phin"
            "Polonia"
            "Quess"
            "Remira"
            "Ring"
            "Roethe"
            "Sesereth"
            "Sethla"
            "Skannon"
            "Stavrul"
            "Stev"
            "Syra"
            "Talitha"
            "Tesslyn"
            "Thena"
            "Timoth"
            "Tocker"
            "Una"
            "Vaurin"
            "Veleris"
            "Veretta"
            "Vestine"
            "Vey"
            "Volette"
            "Vond"
            "Weaver"
            "Wester"
            "Zamira"
            ]
        }

    let familyNames = {
        Name = "family name"
        Items = Flat [
            "Ankhayat"
            "Arran"
            "Athanoch"
            "Basran"
            "Boden"
            "Booker"
            "Bowman"
            "Breakiron"
            "Brogan"
            "Clelland"
            "Clermont"
            "Coleburn"
            "Comber"
            "Daeva"
            "Dalmore"
            "Danfield"
            "Dunvil"
            "Farros"
            "Grine"
            "Haig"
            "Helker"
            "Helles"
            "Helyers"
            "Jayan"
            "Jeduin"
            "Kardera"
            "Karstas"
            "Keel"
            "Kessarin"
            "Kinclaith"
            "Lomond"
            "Maroden"
            "Michter"
            "Morriston"
            "Penderyn"
            "Prichard"
            "Rowan"
            "Sevoy"
            "Skekallan"
            "Skora"
            "Slane"
            "Strangford"
            "Strathmill"
            "Templeton"
            "Tyrconnel"
            "Vale"
            "Walund"
            "Welker"
            ]
        }

    let aliases = {
        Name = "Alias"
        Items = Flat [
            "Bell"
            "Birch"
            "Bricks"
            "Bug"
            "Chime"
            "Coil"
            "Cricket"
            "Cross"
            "Crow"
            "Echo"
            "Flint"
            "Frog"
            "Frost"
            "Grip"
            "Gunner"
            "Hammer"
            "Hook"
            "Junker"
            "Mist"
            "Moon"
            "Nail"
            "Needle"
            "Ogre"
            "Pool"
            "Ring"
            "Ruby"
            "Silver"
            "Skinner"
            "Song"
            "Spur"
            "Tackle"
            "Thisle"
            "Thorn"
            "Tick-Tock"
            "Twelves"
            "Vixen"
            "Whip"
            "Wicker"
            ]
        }

    let local = {
        Name = "local"
        Items = Flat [
            "Akorosi"
            ]
        }

    let foreigner = {
        Name = "foreigner"
        Items = Weighted [
            2.0, "Skovlander"
            1.0, "Iruvian"
            1.0, "Dagger Islander"
            1.0, "Severosi"
            1.0, "Tycherosi"
            ]
        }

    let commonProfessions = {
        Name = "profession, common"
        Items = Flat [
            "baker"
            "barber"
            "blacksmith"
            "brewer"
            "butcher"
            "carpenter"
            "cartwright"
            "chandler"
            "clerk"
            "cobbler"
            "cooper"
            "cultivator"
            "driver"
            "dyer"
            "embroiderer"
            "fishmonger"
            "gondolier"
            "guard"
            "leatherworker"
            "mason"
            "merchant"
            "roofer"
            "ropemaker"
            "rug maker"
            "servant"
            "shipwright"
            "criminal"
            "tailor"
            "tanner"
            "tinkerer"
            "vendor"
            "weaver"
            "woodworker"
            "goat heard"
            "messenger"
            "sailor"
            ]
        }

    let rareProfessions = {
        Name = "profession, rare"
        Items = Flat [
            "advocate"
            "architect"
            "artist"
            "author"
            "bailiff"
            "apiarist"
            "banker"
            "bounty hunter"
            "clockmaker"
            "courtesan"
            "furrier"
            "glass blower"
            "diplomat"
            "jailer"
            "jeweler"
            "leech"
            "locksmith"
            "magistrate"
            "musician"
            "physicker"
            "plumber"
            "printer"
            "scholar"
            "scribe"
            "sparkwright"
            "tax collector"
            "treasurer"
            "whisper"
            "composer"
            "steward"
            "captain"
            "spirit warden"
            "journalist"
            "explorer"
            "rail jack"
            "soldier"
            ]
        }

// type Sources = {
//     Names: Source
//     Aliases: Source
//     FamilyNames: Source
//     LocalHeritages: Source
//     ForeignHeritages: Source
//     CommonProfessions: Source
//     RareProfessions: Source
//     Looks: Source
//     Styles: Source
//     Goals: Source
//     Methods: Source
//     Traits: Source
//     Interests: Source
//     Quirks: Source
//     }

// let peopleSource: Sources = {
//     Names = Blades.names
//     Aliases = Blades.aliases
//     FamilyNames = Blades.familyNames
//     LocalHeritages = Blades.local
//     ForeignHeritages = Blades.foreigner
//     CommonProfessions = Blades.commonProfessions
//     RareProfessions = Blades.rareProfessions
//     Looks = Blades.looks
//     Styles = Blades.styles
//     Goals = Blades.goals
//     Methods = Blades.methods
//     Traits = Blades.traits
//     Interests = Blades.interests
//     Quirks = Blades.quirks
//     }

open System.IO

module DataModel =

    type Expression =
        | Source of string
        | Composite of string
        | Or of list<float * Expression>
        | Maybe of float * Expression

    type NamedDefinition = {
        Name: string
        Definition: Expression
        }

    type Model = {
        Sources: list<Source>
        Definitions: list<NamedDefinition>
        }

    let testModel =
        let sources = [
            Blades.names
            Blades.aliases
            Blades.familyNames
            Blades.local
            Blades.foreigner
            Blades.commonProfessions
            Blades.rareProfessions
            Blades.looks
            Blades.styles
            Blades.goals
            Blades.methods
            Blades.traits
            Blades.interests
            Blades.quirks
            ]
        let definitions = [
            {
                Name = "heritage"
                Definition =
                    Or [
                        0.5, Source Blades.local.Name
                        0.5, Source Blades.foreigner.Name
                        ]
            }
            {
                Name = "profession"
                Definition =
                    Or [
                        5.0, Source Blades.commonProfessions.Name
                        1.0, Source Blades.rareProfessions.Name
                        ]
            }
            {
                Name = "alias"
                Definition = Maybe (0.2, Source Blades.aliases.Name)
            }
            ]
        let model = {
            Sources = sources
            Definitions = definitions
            }
        model

DataModel.testModel
|> fun x -> Encode.Auto.toString(0, x)
|> fun x -> File.WriteAllText(Path.Combine(__SOURCE_DIRECTORY__, "test.json"), x)

#load @"../src/Combinators.fs"
open Doskvol

let pickers =
    Path.Combine(__SOURCE_DIRECTORY__, "test.json")
    |> File.ReadAllText
    |> Decode.Auto.fromString<Data.Model>
    |> fun x ->
        match x with
        | Ok data -> data |> Data.read
        | Error _ -> failwith "boom"

let rng: RNG =
    let x = System.Random ()
    fun () -> x.NextDouble ()

pickers.["heritage"] |> Picker.pick rng
pickers.["foreigner"] |> Picker.pick rng
pickers.["alias"] |> Picker.pick rng

Array.init 10000 (fun _ -> pickers.["heritage"] |> Picker.pick rng)
|> Array.countBy id

Array.init 10000 (fun _ -> pickers.["profession"] |> Picker.pick rng)
|> Array.countBy id
