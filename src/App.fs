namespace Doskvol

module App =

    open System
    open Elmish
    open Elmish.React
    open Fable.React
    open Fable.React.Props
    open Fulma
    open Thoth.Fetch
    open Doskvol
    open Doskvol.Data

    type Attributes = {
        Category: string
        Choices: list<string>
        }

    type NPC = {
        Name: string
        Alias: Option<string>
        FamilyName: string
        Attributes: list<string * string>
        }

    let rng =
        let random = Random ()
        fun () -> random.NextDouble()

    let attribute (pickers: Map<string,Picker>) name =
        name,
        pickers.[name]
        |> Picker.pick rng
        |> Option.get

    let npc (pickers: Map<string,Picker>) : NPC =
        {
            Name = pickers.["name"] |> Picker.pick rng |> Option.get //.From
            Alias = pickers.["alias"] |> Picker.pick rng
            FamilyName = pickers.["family name"] |> Picker.pick rng |> Option.get
            Attributes = [
                attribute pickers "heritage"
                attribute pickers "profession"
                attribute pickers "look"
                attribute pickers "style"
                attribute pickers "goal"
                attribute pickers "method"
                attribute pickers "trait"
                attribute pickers "interest"
                attribute pickers "quirk"
                ]
        }

    type Model = {
        Data: Option<Map<string, Picker>>
        NPC: Option<NPC>
        }

    type Msg =
        | Roll
        | DataReceived of Data.Model

    let init() =

        let model : Model = {
            Data = None
            NPC = None
            }

        let getModel () : Fable.Core.JS.Promise<Data.Model> =
            Fetch.get (@"https://doskvol.blob.core.windows.net/data/citizens.json")

        let cmd = Cmd.OfPromise.perform getModel () DataReceived

        model, cmd

    let update (msg: Msg) (model: Model) =
        match msg with
        | Roll ->
            { model with NPC = model.Data |> Option.map npc },
            Cmd.none
        | DataReceived data ->
            let pickers = data |> read
            {
                Data = Some pickers
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
                            ]
                    ]
            ]

    let hero () =
        Hero.hero []
            [ Hero.body []
                [
                    Heading.h1 [] [ str "Citizens of Doskvol" ]
                    Heading.h4 [ Heading.IsSubtitle] [
                        str "Random denizens for "
                        a [ Href "https://bladesinthedark.com/"; Style [ Color "Red" ] ]
                            [ str "Blades in the Dark"]
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
                                hero ()
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
