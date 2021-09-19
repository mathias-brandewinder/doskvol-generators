module App

open System
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fulma
open Thoth.Fetch

type Attributes = {
    Category: string
    Choices: string []
    }

type Generator = {
    Names: Attributes
    Aliases: Attributes
    FamilyNames: Attributes
    Heritages: Attributes
    Professions: Attributes
    Looks: Attributes
    Styles: Attributes
    Goals: Attributes
    Methods: Attributes
    Traits: Attributes
    Interests: Attributes
    Quirks: Attributes
    }

type NPC = {
    Name: string
    Alias: Option<string>
    FamilyName: string
    Attributes: list<string * string>
    }

type Select (rng: Random) =
    new () = Select(Random())
    new (seed: int) = Select(Random(seed))
    member this.From (xs: 'T []) =
        let len = xs |> Array.length
        xs |> Array.item (rng.Next(0, len))
    member this.Maybe p x =
        let roll = rng.NextDouble()
        if roll <= p
        then Some x
        else None

let npc (generator: Generator) : NPC =

    let pick = Select()
    let select =
        fun (x: Attributes) ->
            x.Category, pick.From x.Choices

    {
        Name = generator.Names.Choices |> pick.From
        Alias = generator.Aliases.Choices |> pick.From |> pick.Maybe 0.2
        FamilyName = generator.FamilyNames.Choices |> pick.From
        Attributes = [
            generator.Heritages |> select
            generator.Professions |> select
            generator.Looks |> select
            generator.Styles |> select
            generator.Goals |> select
            generator.Methods |> select
            generator.Traits |> select
            generator.Interests |> select
            generator.Quirks |> select
            ]
    }

type Model = {
    Generator: Option<Generator>
    NPC: Option<NPC>
    }

type Msg =
    | Roll
    | DataReceived of Generator

let init() =
    let model : Model = {
        Generator = None
        NPC = None
        }

    let getCards () : Fable.Core.JS.Promise<Generator> =
        Fetch.get (@"https://doskvol.blob.core.windows.net/data/people.json")

    let cmd = Cmd.OfPromise.perform getCards () DataReceived

    model, cmd

let update (msg: Msg) (model: Model) =
    match msg with
    | Roll ->
        { model with NPC = model.Generator |> Option.map npc },
        Cmd.none
    | DataReceived generator ->
        {
            Generator = Some generator
            NPC = None
        },
        Cmd.ofMsg Roll

let capitalize (txt: string) =
  txt.Substring(0, 1).ToUpperInvariant () +
  txt.Substring(1)

let formatAlias (alias: Option<string>) =
  match alias with
  | None -> ""
  | Some alias -> sprintf "\u00AB%s\u00BB" alias

let renderTag (category: string, tagValue: string) =
  Control.div [ ]
    [
      Tag.list [ Tag.List.HasAddons; Tag.List.AreMedium ]
        [
          Tag.tag [ Tag.Color IsDark ] [ str (capitalize category) ]
          Tag.tag [ ]
            [
              str (capitalize tagValue)
              // Delete.delete [ Delete.Size IsMedium ] []
            ]
        ]
    ]

let view (model:Model) dispatch =

  Columns.columns [ Columns.IsCentered ]
    [
      Column.column [ Column.Width (Screen.All, Column.IsHalf) ]
        [
          Container.container []
            [
            Hero.hero []
                [ Hero.body []
                    [
                        Heading.h1 [] [ str "Citizens of Doskvol" ]
                        Heading.h4 [ Heading.IsSubtitle] [
                            str "Random denizens for "
                            a [ Href "https://bladesinthedark.com/"; Style [ Color "Red" ] ] [ str "Blades in the Dark"]
                            ]
                    ]
                ]
            ]

          Section.section [ ]
            [
              Box.box' [ ]
                [
                    Heading.h1 [ ]
                        [
                            match model.NPC with
                            | None -> str ""
                            | Some character ->
                                str (character.Name + " " + (formatAlias character.Alias) + " " + character.FamilyName)
                        ]

                    div []
                        [
                          Field.div [ Field.IsGroupedMultiline ]
                            [
                              match model.NPC with
                              | None -> ignore ()
                              | Some character ->
                                  for desc in character.Attributes ->
                                    renderTag desc
                            ]
                        ]
                ]
              Button.button [ Button.IsLight; Button.OnClick (fun _ -> dispatch Roll) ]
                [ str "Roll" ]
            ]
        ]
    ]


// App
Program.mkProgram init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.withConsoleTrace
|> Program.run
