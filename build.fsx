#r @"packages/FAKE/tools/FakeLib.dll"

open System.IO
open Fake
open Fake.FileSystemHelper
open Fake.FscHelper

let allDirs = 
    DirectoryInfo(__SOURCE_DIRECTORY__).GetDirectories "*"
        |> Array.filter(fun i -> not(i.Name.Contains(".")) && i.Name <> "robot-name" && i.Name <> "gigasecond")
        |> Array.collect(fun d -> filesInDirMatching "Example.fs" d)

let exampleFiles = allDirs |> Array.map(fun i -> i.FullName) |> Array.toList

let first = [exampleFiles.Head]

Target "Default" (fun _ ->
    first |> Fsc(fun param -> { param with FscTarget = Library
                                           Output = "Example.dll" })
)

RunTargetOrDefault "Default"