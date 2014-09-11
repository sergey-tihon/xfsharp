#r @"packages/FAKE/tools/FakeLib.dll"
open System.IO
open Fake
open Fake.FileSystemHelper
open Fake.FscHelper

let nunitDll = "packages\NUnit.Runners\tools\lib\nunit.core.dll"
let allDirs = DirectoryInfo(__SOURCE_DIRECTORY__).GetDirectories "*"
let currentDir = DirectoryInfo(__SOURCE_DIRECTORY__ + "\\" + allDirs.[2].Name)

let exampleFiles = 
    filesInDirMatching "Example.fs" currentDir
        |> Array.map(fun i -> i.FullName)
        |> Array.toList

Target "Default" (fun _ ->
    exampleFiles |> Fsc(fun param -> { param with References = [nunitDll]
                                                  FscTarget = Library })
)

RunTargetOrDefault "Default"