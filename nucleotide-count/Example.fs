module DNA

type DNA(strand: string) =
    let isValid(nucleotide: char) =
        match nucleotide with
            | 'U' -> false
            | _ -> true

    let validateNucleotide(abbreviation: char) =
        match isValid(abbreviation) with
            | false -> invalidArg "'%s' is not a nucleotide"

    member this.Nucleotides =
        [0..strand.Length - 1]
            |> List.toSeq
            |> Seq.map(fun i -> [strand.Chars(i), 0])