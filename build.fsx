#r @"packages/FAKE/tools/FakeLib.dll"
open System.IO
open Fake
open Fake.FileSystemHelper
open Fake.FscHelper
let allDirs = 
    DirectoryInfo(__SOURCE_DIRECTORY__).GetDirectories "*"
        |> Array.collect(fun d -> filesInDirMatching "Example.fs" d)

let exampleFiles = allDirs |> Array.map(fun i -> i.FullName) |> Array.toList

Target "Default" (fun _ ->
    exampleFiles |> Fsc(fun param -> { param with FscTarget = Library
                                                  Output = "Example.dll" })
)

RunTargetOrDefault "Default"