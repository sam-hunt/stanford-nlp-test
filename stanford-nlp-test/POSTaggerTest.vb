Imports java.io
Imports java.util

Imports edu.stanford.nlp.ling
Imports edu.stanford.nlp.tagger.maxent

Imports Console = System.Console

Module POSTaggerTest

    Sub Main()
        Dim jarRoot = My.Application.Info.DirectoryPath + "\..\..\jar"
        'Dim jarRoot = "..\jar"
        Dim modelsDirectory = jarRoot + "\models"

        Console.WriteLine(jarRoot)

        'Loading POS Tagger
        Dim tagger = New MaxentTagger(modelsDirectory + "\english-bidirectional-distsim.tagger")

        Dim Text As String

        Do
            Text = Console.ReadLine()
            Dim sentences = MaxentTagger.tokenizeText(New StringReader(Text)).toArray()
            For Each sentence As ArrayList In sentences
                Dim taggedSentence = tagger.tagSentence(sentence)
                Console.WriteLine(SentenceUtils.listToString(taggedSentence, False))
            Next
        Loop While Text.Length() > 0

    End Sub

End Module
