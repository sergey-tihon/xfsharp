module School

type School() =
    member val Roster = Map.empty with get, set

    member this.add(grade: int, studentName: string) =
        let studentsOpt = this.Roster.TryFind(grade) 
        // If the result was 'None', then use empty list as the default 
        let students = defaultArg studentsOpt []
        // Create a new list with the new student at the front
        let newStudents = studentName::students
        // Create & save map with new/replaced mapping for 'grade'
        this.Roster <- this.Roster.Add(grade, newStudents)

    member this.grade(grade: int) =
        match this.Roster.TryFind(grade) with
            | Some students -> students |> List.sort
            | None -> List.empty